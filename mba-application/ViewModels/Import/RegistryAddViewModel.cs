using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

using DevExpress.Mvvm;
using DevExpress.Spreadsheet;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Charts;

using mba_application.MBAComponents;
using mba_application.MBAImportService;
using mba_application.ViewModels.Dialogs;

using mba_model;
using WordsMatching;

namespace mba_application.ViewModels.Import
{
    [POCOViewModel]
    public class RegistryAddViewModel
    {
        protected RegistryAddViewModel()
        {
            WorkSheetsInBook = new ObservableCollection<SheetInfo>();

            ImportService = new MBAImportService.ImportServiceClient();
            ImportService.GoodColumnsCompleted += ImportService_GoodColumnsCompleted;
            ImportService.ClientsCompleted += ImportService_ClientsCompleted;
            ImportService.ImportTypesCompleted += ImportService_ImportTypesCompleted;
            ImportService.AddColumnHeadersCompleted += ImportService_AddColumnHeadersCompleted;

            ImportService.GoodColumnsAsync();
            ImportService.ClientsAsync();
            ImportService.ImportTypesAsync();
        }

        #region Async call to Service completed events
        private void ImportService_AddColumnHeadersCompleted(object sender, AddColumnHeadersCompletedEventArgs e)
        {
            var sheetInfo = e.UserState as SheetInfo;
            sheetInfo.ColumnHeaders = new List<ColumnHeader>(e.Result);

            // производим сопоставление собранных столбцов с Клиентами для определения вероятности принадлежности
            var temporaryClients = new List<RelatedClientInfo>();
            foreach (var ch in sheetInfo.ColumnHeaders)
            {
                if (ch.ColumnHeaderClients == null)
                    continue;

                foreach (var chcRelation in ch.ColumnHeaderClients)
                {
                    foreach (var client in Clients)
                    {
                        if (client.Id != chcRelation.ClientId)
                            continue;
                        var addedClient = sheetInfo.RelatedClientsContainClient(chcRelation.Client, temporaryClients);
                        if (addedClient != null)
                            addedClient.RelatedColumnHeaderCount++;
                        else
                        { 
                            temporaryClients.Add(new RelatedClientInfo { Client = chcRelation.Client, RelatedColumnHeaderCount = 1, ColumnHeaderCount = sheetInfo.ColumnHeaders.Count });
                        }
                    }
                }
            }
            sheetInfo.RelatedClients = new ObservableCollection<RelatedClientInfo>();
            temporaryClients.Sort((one, two) => { if (one.RelatedPercent > two.RelatedPercent) return -1; else return 1; });
            foreach (var item in temporaryClients)
            {
                if (item.RelatedPercent > 0)
                    sheetInfo.RelatedClients.Add(item);
            }
            temporaryClients.Clear();
            if (sheetInfo.RelatedClients.Count > 0)
                sheetInfo.SelectedRelatedClient = sheetInfo.RelatedClients[0];
        }

        private void ImportService_ImportTypesCompleted(object sender, ImportTypesCompletedEventArgs e)
        {
            ImportTypes = new ObservableCollection<ImportType>(e.Result);
        }

        private void ImportService_ClientsCompleted(object sender, ClientsCompletedEventArgs e)
        {
            Clients = new ObservableCollection<Client>(e.Result);
        }

        private void ImportService_GoodColumnsCompleted(object sender, GoodColumnsCompletedEventArgs e)
        {
            GoodColumns = new ObservableCollection<GoodColumn>(e.Result);
        }
        #endregion

        public RegistryAddViewModel Create()
        {
            return ViewModelSource.Create(() => new RegistryAddViewModel());
        }

        public ImportServiceClient ImportService;
        public virtual ObservableCollection<GoodColumn> GoodColumns { get; set; }
        public virtual ObservableCollection<Client> Clients { get; set; }
        public virtual ObservableCollection<ImportType> ImportTypes { get; set; }

        public virtual ObservableCollection<SheetInfo> WorkSheetsInBook { get; set; }

        private ChartHitInfo SelectedHitInfo;
        private DateTime MouseDownTime, MouseUpTime;

        public virtual IDialogService DialogService { get { return null; } }

        public virtual int SelectedWorkSheetIndex { get; set; }
        public virtual string SourceFilePath { get; set; }

        public void DblClickExplorer(TreeListNode focusedNode)
        {
            FileSystemItem nodeContent = focusedNode.Content as FileSystemItem;
            if (nodeContent.FullName.IndexOf(".xls", 0, StringComparison.InvariantCultureIgnoreCase) > -1
                    || nodeContent.FullName.IndexOf(".xlsx", 0, StringComparison.InvariantCultureIgnoreCase) > -1
               )
            {
                WorkSheetsInBook.Clear();
                SourceFilePath = nodeContent.FullName;
            }
        }
        public void MouseLeftButtonDown(object eventArgs)
        {
            MouseDownTime = DateTime.Now;
            var e = eventArgs as MouseButtonEventArgs;
        }
        public void MouseLeftButtonUp(object eventArgs)
        {
            MouseUpTime = DateTime.Now;
            var e = eventArgs as MouseButtonEventArgs;
            var sender = e.Source;

            ChartControl chart;
            if (sender is ChartControl)
                chart = sender as ChartControl;
            else 
                chart = (sender as SimpleDiagram2D).Parent as ChartControl;

            ChartHitInfo hitInfo = chart.CalcHitInfo(e.GetPosition(chart));

            if (hitInfo == null || hitInfo.SeriesPoint == null || (MouseUpTime - MouseDownTime).TotalMilliseconds > 180)
                return;

            if (SelectedHitInfo != null)
            {
                double dist = PieSeries.GetExplodedDistance(SelectedHitInfo.SeriesPoint);
                Storyboard selectedStoryBoard = new Storyboard();
                DoubleAnimation selectedAnimation = new DoubleAnimation();
                selectedAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 400));
                selectedAnimation.To = 0;
                selectedStoryBoard.Children.Add(selectedAnimation);
                Storyboard.SetTarget(selectedAnimation, SelectedHitInfo.SeriesPoint);
                Storyboard.SetTargetProperty(selectedAnimation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
                selectedStoryBoard.Begin();
            }

            double distance = PieSeries.GetExplodedDistance(hitInfo.SeriesPoint);
            Storyboard storyBoard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 400));
            animation.To = distance > 0 ? 0 : 0.4;
            storyBoard.Children.Add(animation);
            Storyboard.SetTarget(animation, hitInfo.SeriesPoint);
            Storyboard.SetTargetProperty(animation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
            storyBoard.Begin();

            SelectedHitInfo = hitInfo;
        }

        public void DocumentLoaded(object _spreadSheet)
        {
            if (!(_spreadSheet is SpreadsheetControl))
                return;
            IWorkbook WorkBook = (_spreadSheet as SpreadsheetControl).Document;
            foreach (Worksheet itemWorkSheet in WorkBook.Worksheets)
            {
                SheetInfo sheetInfo = new SheetInfo { WorkSheet = itemWorkSheet, GoodColumns = GoodColumns };

                sheetInfo.ParseWorkSheet();

                List<string> columnHeaders = new List<string>();
                foreach (var item in sheetInfo.ColumnHeaderList)
                { 
                    columnHeaders.Add(item.Caption);
                }
                WorkSheetsInBook.Add(sheetInfo);
                ImportService.AddColumnHeadersAsync(columnHeaders.ToArray(), sheetInfo);
           }
        }

        public void SpreadSheetSelectionChanged(object _spreadSheet)
        {
            if (WorkSheetsInBook.Count < 1)
                return;
            var spreadSheet = _spreadSheet as SpreadsheetControl;
            var currentSheetInfo = WorkSheetsInBook[SelectedWorkSheetIndex];

            int selectedColumn = spreadSheet.Selection.LeftColumnIndex;

            foreach (var item in currentSheetInfo.ColumnHeaderList)
            {
                if (item.RangeInWorksheet.Left == selectedColumn)
                    currentSheetInfo.SelectedColumnHeaderValue = item;
            }
        }

        public void ShowClientChooseDialog()
        {
            ClientChooseViewModel clientChooseViewModel = new ClientChooseViewModel();
            clientChooseViewModel.Clients = Clients;
            clientChooseViewModel.ImportTypes = ImportTypes;

            UICommand selectClientCommand = new UICommand()
            {
                Caption = "Выбрать",
                IsCancel = false,
                IsDefault = false,
                Command = new DelegateCommand<CancelEventArgs>(
                    x => 
                    {
                        var currentSheetInfo = WorkSheetsInBook[SelectedWorkSheetIndex];
                        if (currentSheetInfo.RelatedClientsContainClient(clientChooseViewModel.SelectedClient, currentSheetInfo.RelatedClients) == null)
                        {
                            var relatedClientInfo = new RelatedClientInfo
                            {
                                Client = clientChooseViewModel.SelectedClient,
                                RelatedColumnHeaderCount = currentSheetInfo.ColumnHeaders.Count,
                                ColumnHeaderCount = currentSheetInfo.ColumnHeaders.Count
                            };
                            currentSheetInfo.RelatedClients.Add(relatedClientInfo);
                            currentSheetInfo.SelectedRelatedClient = relatedClientInfo;
                        }
                        ImportService.AddRelationColumnHeadersClient(currentSheetInfo.ColumnHeadersToArray, clientChooseViewModel.SelectedClient);
                    },
                    x => true
                )
            };
            UICommand cancelCommand = new UICommand()
            {
                Id = MessageBoxResult.Cancel,
                Caption = "Отменить",
                IsCancel = true,
                IsDefault = true
            };

            DialogService.ShowDialog(
                dialogCommands: new List<UICommand>() { selectClientCommand, cancelCommand },
                title: "Выбор Клиента...",
                viewModel: clientChooseViewModel
            );
        }
    }

    public class RowStruct
    {
        internal int columnsCount;
        private int count;
        internal int Count { get { return count; } set { Percent = value * 100 / columnsCount; count = value; } }
        internal float Percent;
        internal RowStruct(int _columnsCount)
        {
            columnsCount = _columnsCount;
            count = 1;
        }
    }

    public class RelatedClientInfo
    {
        public Client Client { get; set; }
        public int RelatedColumnHeaderCount;
        public int ColumnHeaderCount;

        public string RelatedColumnHeaderPercentStr { get { return RelatedColumnHeaderCount.ToString() + " - " + RelatedPercent.ToString() + "%"; } }
        public int RelatedPercent { get { return (int)Math.Round(100F * RelatedColumnHeaderCount / ColumnHeaderCount); } }
    }

    public class SheetInfo : ViewModelBase
    {
        public ICollection<GoodColumn> GoodColumns { get; set; }
        public Worksheet WorkSheet
        {
            get { return GetProperty(() => WorkSheet); }
            set { SetProperty(() => WorkSheet, value); }
        }
        public ObservableCollection<RelatedClientInfo> RelatedClients
        {
            get { return GetProperty(() => RelatedClients); }
            set { SetProperty(() => RelatedClients, value); }
        }
        public List<ColumnHeaderValue> ColumnHeaderList
        {
            get { return GetProperty(() => ColumnHeaderList); }
            set { SetProperty(() => ColumnHeaderList, value); }
        }
        public ColumnHeaderValue SelectedColumnHeaderValue
        {
            get { return GetProperty(() => SelectedColumnHeaderValue); }
            set { SetProperty(() => SelectedColumnHeaderValue, value); }
        }
        public ObservableCollection<GoodColumnWithPercentMathces> SelectedColumnMatches
        {
            get { return GetProperty(() => SelectedColumnMatches); }
            set { SetProperty(() => SelectedColumnMatches, value); }
        }

public List<ColumnHeader> ColumnHeaders { get; set; }
        public ColumnHeader[] ColumnHeadersToArray
        {
            get
            {
                List<ColumnHeader> chList = new List<ColumnHeader>(ColumnHeaders);
                return chList.ToArray();
            }
        }

        public RelatedClientInfo SelectedRelatedClient
        {
            get { return GetProperty(() => SelectedRelatedClient); }
            set { SetProperty(() => SelectedRelatedClient, value); }
        }

        public SheetInfo()
        {
            SelectedColumnMatches = new ObservableCollection<GoodColumnWithPercentMathces>();
            rangeRows = new List<RowInfo>();
            SummRowsInfo = new Dictionary<string, int>();
            ColumnHeaderList = new List<ColumnHeaderValue>();
        }

        [Command]
        public void SelectionChangedAtColumnsList(object eventArgs)
        {
            if (WorkSheet.Selection.LeftColumnIndex != SelectedColumnHeaderValue.RangeInWorksheet.Left)
                WorkSheet.ScrollTo(SelectedColumnHeaderValue.HeaderTableRowIndex, (int)SelectedColumnHeaderValue.RangeInWorksheet.Left);

            WorkSheet.Columns[(int)SelectedColumnHeaderValue.RangeInWorksheet.Left].AutoFit();

            WorkSheet.Selection = WorkSheet.Range.FromLTRB(
                    (int)SelectedColumnHeaderValue.RangeInWorksheet.Left,
                    (int)SelectedColumnHeaderValue.RangeInWorksheet.Top,
                    (int)SelectedColumnHeaderValue.RangeInWorksheet.Right,
                    (int)SelectedColumnHeaderValue.RangeInWorksheet.Bottom
                );

            SelectedColumnMatches.Clear();
            foreach (var item in SelectedColumnHeaderValue.GoodColumnWithPercentMatches)
            {
                SelectedColumnMatches.Add(item);
            }

            var listBox = (eventArgs as RoutedEventArgs).Source as ListBoxEdit;
            listBox.ScrollIntoView(SelectedColumnHeaderValue);
        }

        [Command]
        public void ListBoxLoaded(object eventArgs)
        {
            var loadedListBox = (eventArgs as RoutedEventArgs).Source as ListBoxEdit;

            if (loadedListBox.SelectedIndex == -1)
                loadedListBox.SelectedIndex = 0;
        }

        [Command]
        public void RelatedClientSelectedIndexChanged(object eventArgs)
        {
            var loadedListBox = (eventArgs as RoutedEventArgs).Source as ListBoxEdit;
            foreach (var columnHeader in ColumnHeaderList)
            {
                ColumnHeader tmpColumnHeader = null;
                foreach (var item in ((loadedListBox.SelectedItem as RelatedClientInfo).Client.ColumnHeaderClients))
                {
                    if (columnHeader.Caption == item.ColumnHeader.Name)
                    {
                        tmpColumnHeader = item.ColumnHeader;
                        break;
                    }
                }
                columnHeader.RelatedColumnHeader = tmpColumnHeader;
            }
            return;
        }

        public void AddNewRow()
        {
            CurrentRowInfo = new RowInfo(ColumnsCount);
            rangeRows.Add(CurrentRowInfo);
        }
        internal bool GetStatisticForRow()
        {
            bool isShapka = false;
            CurrentRowInfo.RowInfoStr = string.Empty;
            var countTypes = CurrentRowInfo.cellTypesDictionary.Count;
            foreach (var cellType in CurrentRowInfo.cellTypesDictionary)
            {
                //CurrentRowInfo.RowInfoStr += "Тип: " + cellType.Key.ToString() + " - " + cellType.Value.Percent.ToString() + "% (" + cellType.Value.Count + "/" + cellType.Value.columnsCount + ") || ";
                //CurrentRowInfo.RowInfoStr += cellType.Key.ToString() + " " + cellType.Value.Percent.ToString() + "% || ";
                CurrentRowInfo.RowInfoStr += cellType.Key.ToString() + " || ";

                // есть ли признаки, указывающие на то, что данная строка "шапка"
                if ((cellType.Key == CellValueType.Text && cellType.Value.Percent > 95 && countTypes < 3 && ColumnsCount > 2)
                    || (cellType.Key == CellValueType.Text && cellType.Value.Percent > 10 && countTypes == 1))
                    isShapka = true;
            }

            if (SummRowsInfo.ContainsKey(CurrentRowInfo.RowInfoStr))
                SummRowsInfo[CurrentRowInfo.RowInfoStr] += 1;
            else
                SummRowsInfo.Add(CurrentRowInfo.RowInfoStr, 1);

            return isShapka;
        }

        internal RelatedClientInfo RelatedClientsContainClient(Client client, ICollection<RelatedClientInfo> clientList)
        {
            foreach (var item in clientList)
            {
                if (client.Id == item.Client.Id)
                    return item;
            }
            return null;
        }

        internal void CompareWithGoodColumns(ColumnHeaderValue _columnHeader)
        {
            foreach (var item in GoodColumns)
            {
                var percent = (float)Math.Round((new MatchsMaker(item.Name, _columnHeader.Caption)).Score * 100);
                if (percent == 0)
                    percent = 0.01F;
                _columnHeader.GoodColumnWithPercentMatches.Add(new GoodColumnWithPercentMathces { GoodColumnId = item.Id, GoodColumnName = item.Name, Percent = percent });
                if (percent > _columnHeader.BestValue.Percent)
                {
                    _columnHeader.BestValue.Percent = percent;
                    _columnHeader.BestValue.GoodColumnId = item.Id;
                    _columnHeader.BestValue.GoodColumnName = item.Name;
                }
            }
            _columnHeader.GoodColumnWithPercentMatches.Sort((one, two) => { if (one.Percent > two.Percent) return -1; else return 1; });
        }

        internal void ParseWorkSheet()
        {
            bool headerTableFound = false;
            var usedRange = WorkSheet.GetUsedRange();
            ColumnsCount = usedRange.RightColumnIndex - usedRange.LeftColumnIndex;

            for (int rowIndex = usedRange.TopRowIndex; rowIndex < usedRange.BottomRowIndex; rowIndex++)
            {
                AddNewRow();
                for (int columnIndex = usedRange.LeftColumnIndex; columnIndex <= usedRange.RightColumnIndex; columnIndex++)
                    CurrentRowInfo.AddCell(WorkSheet.Cells[rowIndex, columnIndex]);

                if (!headerTableFound && GetStatisticForRow()) // метод взращает bool со значение true если "диагностирует" что данная строка - шапка
                {
                    headerTableFound = true;
                    for (int headerColumnIndex = usedRange.LeftColumnIndex; headerColumnIndex <= usedRange.RightColumnIndex; headerColumnIndex++)
                    {
                        if (WorkSheet.Cells[rowIndex, headerColumnIndex].Value.Type == CellValueType.Text)
                        {
                            var cellValue = WorkSheet.Cells[rowIndex, headerColumnIndex].Value.ToString().ToLower();
                            var columnRange = new Thickness { Left = headerColumnIndex, Top = usedRange.TopRowIndex, Right = headerColumnIndex, Bottom = usedRange.BottomRowIndex };

                            Regex pattern = new Regex("[:_,.\\*/\n]|[ ]{2,}");
                            cellValue = pattern.Replace(cellValue, " ");

                            var columnHeaderValue = new ColumnHeaderValue { HeaderTableRowIndex = rowIndex, Caption = cellValue, RangeInWorksheet = columnRange };

                            if (!ColumnHeaderList.Exists(c => c.Caption == columnHeaderValue.Caption))
                            {
                                CompareWithGoodColumns(columnHeaderValue);
                                ColumnHeaderList.Add(columnHeaderValue);
                            }
                        }
                    }
                }
            }
        }

        private List<RowInfo> rangeRows;
        internal int ColumnsCount { get; set; }
        public RowInfo CurrentRowInfo { get; private set; }
        public Dictionary<string, int> SummRowsInfo { get; set; }
    }

    public class ColumnHeaderValue : BindableBase
    {
        public Thickness RangeInWorksheet { get; set; }
        public int HeaderTableRowIndex { get; set; }
        public string Caption { get; set; }
        public ColumnHeader RelatedColumnHeader
        {
            get { return GetProperty(() => RelatedColumnHeader); }
            set { SetProperty(() => RelatedColumnHeader, value); }
        }
        public GoodColumnWithPercentMathces BestValue { get; set; }
        public List<GoodColumnWithPercentMathces> GoodColumnWithPercentMatches { get; set; }

        public ColumnHeaderValue()
        {
            GoodColumnWithPercentMatches = new List<GoodColumnWithPercentMathces>();
            BestValue = new GoodColumnWithPercentMathces { Percent = 0.01F };
        }
   }

    public class GoodColumnWithPercentMathces
    {
        public float Percent { get; set; }
        public int GoodColumnId { get; set; }
        public string GoodColumnName { get; set; }

        public string PercentString { get { return Percent.ToString() + "%"; }  }
        public bool IsGoodPercent { get { return Percent > 80; } }
    }

    public class RowInfo
    {
        public Dictionary<CellValueType, RowStruct> cellTypesDictionary;
        private int columnsCount;
        public string RowInfoStr;
        public RowInfo(int _columnsCount)
        {
            columnsCount = _columnsCount;
            cellTypesDictionary = new Dictionary<CellValueType, RowStruct>();
        }
        internal void AddCell(Cell cell)
        {
            CellValueType cellType = cell.Value.Type;
            if (cellType == CellValueType.None)
                return;

            if (cellTypesDictionary.ContainsKey(cellType))
                cellTypesDictionary[cellType].Count += 1;
            else
                cellTypesDictionary.Add(cellType, new RowStruct(columnsCount));
        }
    }
}