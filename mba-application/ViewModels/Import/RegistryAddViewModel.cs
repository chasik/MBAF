using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using DevExpress.Mvvm;
using DevExpress.Spreadsheet;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Charts;
using DevExpress.XtraPrinting.Native;
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

            ImportService = new ImportServiceClient();
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
            var sheetInfo = (SheetInfo) e.UserState;
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

            temporaryClients.Sort((one, two) =>
            {
                if (one.RelatedPercent > two.RelatedPercent) return -1;
                return 1;
            });
            temporaryClients.Where(c => c.RelatedPercent > 0).ForEach(c => sheetInfo.RelatedClients.Add(c));
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
            SourceFilePath = "D:\\251_Batch_251040_received_30.11.2015.xlsx";
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

        public ObservableCollection<SheetInfo> WorkSheetsInBook { get; set; }

        private ChartHitInfo _selectedHitInfo;
        private DateTime _mouseDownTime, _mouseUpTime;

        public virtual IDialogService DialogService => null;

        public virtual int SelectedWorkSheetIndex { get; set; }
        public virtual string SourceFilePath { get; set; }

        public void DblClickExplorer(TreeListNode focusedNode)
        {
            var nodeContent = (FileSystemItem) focusedNode.Content;
            if (nodeContent.FullName.IndexOf(".xls", 0, StringComparison.InvariantCultureIgnoreCase) < 0 &&
                    nodeContent.FullName.IndexOf(".xlsx", 0, StringComparison.InvariantCultureIgnoreCase) < 0)
                return;
            WorkSheetsInBook.Clear();
            SourceFilePath = nodeContent.FullName;
        }
        public void MouseLeftButtonDown(object eventArgs)
        {
            _mouseDownTime = DateTime.Now;
            var e = eventArgs as MouseButtonEventArgs;
        }
        public void MouseLeftButtonUp(object eventArgs)
        {
            _mouseUpTime = DateTime.Now;
            var e = eventArgs as MouseButtonEventArgs;
            var sender = e.Source;

            ChartControl chart;
            if (sender is ChartControl)
                chart = sender as ChartControl;
            else 
                chart = ((SimpleDiagram2D) sender).Parent as ChartControl;

            var hitInfo = chart.CalcHitInfo(e.GetPosition(chart));

            if (hitInfo?.SeriesPoint == null || (_mouseUpTime - _mouseDownTime).TotalMilliseconds > 180)
                return;

            if (_selectedHitInfo != null)
            {
                PieSeries.GetExplodedDistance(_selectedHitInfo.SeriesPoint);
                var selectedStoryBoard = new Storyboard();
                var selectedAnimation = new DoubleAnimation
                {
                    Duration = new Duration(new TimeSpan(0, 0, 0, 0, 400)),
                    To = 0
                };
                selectedStoryBoard.Children.Add(selectedAnimation);
                Storyboard.SetTarget(selectedAnimation, _selectedHitInfo.SeriesPoint);
                Storyboard.SetTargetProperty(selectedAnimation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
                selectedStoryBoard.Begin();
            }

            var distance = PieSeries.GetExplodedDistance(hitInfo.SeriesPoint);
            var storyBoard = new Storyboard();
            var animation = new DoubleAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 400)),
                To = distance > 0 ? 0 : 0.4
            };
            storyBoard.Children.Add(animation);
            Storyboard.SetTarget(animation, hitInfo.SeriesPoint);
            Storyboard.SetTargetProperty(animation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
            storyBoard.Begin();

            _selectedHitInfo = hitInfo;
        }

        public void DocumentLoaded(object spreadSheet)
        {
            if (!(spreadSheet is SpreadsheetControl))
                return;
            var workBook = ((SpreadsheetControl) spreadSheet).Document;
            foreach (var itemWorkSheet in workBook.Worksheets)
            {
                var sheetInfo = new SheetInfo { WorkSheet = itemWorkSheet, GoodColumns = GoodColumns };

                sheetInfo.ParseWorkSheet();

                var columnHeaders = new List<string>();

                sheetInfo.ColumnHeaderList.ForEach(ch => columnHeaders.Add(ch.Caption));

                WorkSheetsInBook.Add(sheetInfo);
                ImportService.AddColumnHeadersAsync(columnHeaders.ToArray(), sheetInfo);
           }
        }

        public void SpreadSheetSelectionChanged(object spreadSheetObject)
        {
            if (spreadSheetObject == null || WorkSheetsInBook.Count < 1)
                return;
            var spreadSheet = (SpreadsheetControl) spreadSheetObject;
            var currentSheetInfo = WorkSheetsInBook[SelectedWorkSheetIndex];

            var selectedColumn = spreadSheet.Selection.LeftColumnIndex;

            currentSheetInfo.SelectedColumnHeaderValue = currentSheetInfo.ColumnHeaderList.FirstOrDefault(chi => (int)chi.RangeInWorksheet.Left == selectedColumn);
        }

        public void ShowClientChooseDialog()
        {
            var clientChooseViewModel = new ClientChooseViewModel
            {
                Clients = Clients,
                ImportTypes = ImportTypes
            };

            var selectClientCommand = new UICommand()
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
            var cancelCommand = new UICommand()
            {
                Id = MessageBoxResult.Cancel,
                Caption = "Отменить",
                IsCancel = true,
                IsDefault = true
            };

            DialogService.ShowDialog(new List<UICommand>() { selectClientCommand, cancelCommand }, "Выбор Клиента...", clientChooseViewModel);
        }
    }

    public class RowStruct
    {
        internal int ColumnsCount;
        private int _count;
        internal int Count { get { return _count; } set { Percent = value * 100 / (float) ColumnsCount; _count = value; } }
        internal float Percent;
        internal RowStruct(int columnsCount)
        {
            ColumnsCount = columnsCount;
            _count = 1;
        }
    }

    public class RelatedClientInfo
    {
        public Client Client { get; set; }
        public int RelatedColumnHeaderCount;
        public int ColumnHeaderCount;

        public string RelatedColumnHeaderPercentStr => RelatedColumnHeaderCount + " - " + RelatedPercent + "%";
        public int RelatedPercent => (int)Math.Round(100F * RelatedColumnHeaderCount / ColumnHeaderCount);
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
                var chList = new List<ColumnHeader>(ColumnHeaders);
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
            _rangeRows = new List<RowInfo>();
            SummRowsInfo = new Dictionary<string, int>();
            ColumnHeaderList = new List<ColumnHeaderValue>();
        }

        [Command]
        public void RelatedClientSelectedIndexChanged(object eventArgs)
        {
            var loadedListBox = (eventArgs as RoutedEventArgs)?.Source as ListBoxEdit;
            if (loadedListBox == null)
                return;
            foreach (var columnHeader in ColumnHeaderList)
            {
                ColumnHeader tmpColumnHeader = null;
                var client = ((RelatedClientInfo) loadedListBox.SelectedItem).Client;

                client?.ColumnHeaderClients?.Where(chc => chc.ColumnHeader.Name == columnHeader.Caption).ForEach(chc => tmpColumnHeader = chc.ColumnHeader);

                columnHeader.RelatedColumnHeader = tmpColumnHeader;
            }
        }

        [Command]
        public void RelatedClientMouseLeftButtonDown(object eventArgs)
        {
            SelectedColumnHeaderValue = null;
        }

        public void AddNewRow()
        {
            CurrentRowInfo = new RowInfo(ColumnsCount);
            _rangeRows.Add(CurrentRowInfo);
        }
        internal bool GetStatisticForRow()
        {
            var isShapka = false;
            CurrentRowInfo.RowInfoStr = string.Empty;
            var countTypes = CurrentRowInfo.CellTypesDictionary.Count;
            foreach (var cellType in CurrentRowInfo.CellTypesDictionary)
            {
                //CurrentRowInfo.RowInfoStr += "Тип: " + cellType.Key.ToString() + " - " + cellType.Value.Percent.ToString() + "% (" + cellType.Value.Count + "/" + cellType.Value.ColumnsCount + ") || ";
                //CurrentRowInfo.RowInfoStr += cellType.Key.ToString() + " " + cellType.Value.Percent.ToString() + "% || ";
                CurrentRowInfo.RowInfoStr += cellType.Key + " || ";

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
            return clientList.FirstOrDefault(c => c.Client.Id == client.Id);
        }

        internal void CompareWithGoodColumns(ColumnHeaderValue columnHeader)
        {
            foreach (var item in GoodColumns)
            {
                var percent = (float)Math.Round((new MatchsMaker(item.Name, columnHeader.Caption)).Score * 100);
                if (Math.Abs(percent) < 0.01F)
                    percent = 0.01F;
                columnHeader.GoodColumnWithPercentMatches.Add(new GoodColumnWithPercentMathces { GoodColumnId = item.Id, GoodColumnName = item.Name, Percent = percent });
                if (percent <= columnHeader.BestValue.Percent)
                    continue;
                columnHeader.BestValue.Percent = percent;
                columnHeader.BestValue.GoodColumnId = item.Id;
                columnHeader.BestValue.GoodColumnName = item.Name;
            }
            columnHeader.GoodColumnWithPercentMatches.Sort((one, two) => { if (one.Percent > two.Percent) return -1; else return 1; });
        }

        internal void ParseWorkSheet()
        {
            var headerTableFound = false;
            var usedRange = WorkSheet.GetUsedRange();
            ColumnsCount = usedRange.RightColumnIndex - usedRange.LeftColumnIndex;

            for (var rowIndex = usedRange.TopRowIndex; rowIndex < usedRange.BottomRowIndex; rowIndex++)
            {
                AddNewRow();
                for (var columnIndex = usedRange.LeftColumnIndex; columnIndex <= usedRange.RightColumnIndex; columnIndex++)
                    CurrentRowInfo.AddCell(WorkSheet.Cells[rowIndex, columnIndex]);

                if (headerTableFound || !GetStatisticForRow())
                    continue;

                headerTableFound = true;
                for (var headerColumnIndex = usedRange.LeftColumnIndex; headerColumnIndex <= usedRange.RightColumnIndex; headerColumnIndex++)
                {
                    if (WorkSheet.Cells[rowIndex, headerColumnIndex].Value.Type != CellValueType.Text)
                        continue;
                    var cellValue = WorkSheet.Cells[rowIndex, headerColumnIndex].Value.ToString().ToLower();
                    var columnRange = new Thickness { Left = headerColumnIndex, Top = usedRange.TopRowIndex, Right = headerColumnIndex, Bottom = usedRange.BottomRowIndex };

                    var pattern = new Regex("[:_,.\\*/\n]|[ ]{2,}");
                    cellValue = pattern.Replace(cellValue, " ");

                    var columnHeaderValue = new ColumnHeaderValue { HeaderTableRowIndex = rowIndex, Caption = cellValue, RangeInWorksheet = columnRange };

                    if (ColumnHeaderList.Exists(c => c.Caption == columnHeaderValue.Caption))
                        continue;
                    CompareWithGoodColumns(columnHeaderValue);
                    ColumnHeaderList.Add(columnHeaderValue);
                }
            }
        }

        private readonly List<RowInfo> _rangeRows;
        internal int ColumnsCount { get; set; }
        public RowInfo CurrentRowInfo { get; private set; }
        public Dictionary<string, int> SummRowsInfo { get; set; }
    }

    public class ColumnHeaderValue : BindableBase
    {
        public FrameworkElement ParentFrameworkElement { get; set; }
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

        public string PercentString => Percent + "%";
        public bool IsGoodPercent => Percent > 80;
    }

    public class RowInfo
    {
        public Dictionary<CellValueType, RowStruct> CellTypesDictionary;
        private readonly int _columnsCount;
        public string RowInfoStr;
        public RowInfo(int columnsCount)
        {
            _columnsCount = columnsCount;
            CellTypesDictionary = new Dictionary<CellValueType, RowStruct>();
        }
        internal void AddCell(Cell cell)
        {
            var cellType = cell.Value.Type;
            if (cellType == CellValueType.None)
                return;

            if (CellTypesDictionary.ContainsKey(cellType))
                CellTypesDictionary[cellType].Count += 1;
            else
                CellTypesDictionary.Add(cellType, new RowStruct(_columnsCount));
        }
    }
}