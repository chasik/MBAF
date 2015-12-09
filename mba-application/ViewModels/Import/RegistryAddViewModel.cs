using System;
using DevExpress.Mvvm;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Spreadsheet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mba_application.MBAComponents;
using mba_application.MBAImportService;
using WordsMatching;
using mba_model;
using DevExpress.Xpf.Grid;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System.Windows;
using DevExpress.Xpf.Editors;

namespace mba_application.ViewModels.Import
{
    [POCOViewModel]
    public class RegistryAddViewModel
    {
        protected RegistryAddViewModel()
        {
            WorkSheetsInBook = new ObservableCollection<SheetInfo>();
            SelectedColumnMatches = new ObservableCollection<GoodColumnWithPercentMathces>();

            ImportService = new MBAImportService.ImportServiceClient();

            GoodColumns = new ObservableCollection<GoodColumn>(ImportService.GoodColumns());
            Clients = new ObservableCollection<Client>(ImportService.Clients());
            ImportTypes = new ObservableCollection<ImportType>(ImportService.ImportTypes());
        }

        public RegistryAddViewModel Create()
        {
            return ViewModelSource.Create(() => new RegistryAddViewModel());
        }

        public ImportServiceClient ImportService;

        public virtual string SourceFilePath { get; set; }

        public ObservableCollection<GoodColumnWithPercentMathces> SelectedColumnMatches { get; set; }
        public ObservableCollection<SheetInfo> WorkSheetsInBook { get; set; }
        public ObservableCollection<GoodColumn> GoodColumns { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<ImportType> ImportTypes { get; set; }

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
        public void SelectionChangedAtColumnsList(object eventArgs)
        {
            var selectedItem = ((eventArgs as RoutedEventArgs).Source as ListBoxEdit).SelectedItem;
            SelectedColumnMatches.Clear();

            foreach (var item in (selectedItem as ColumnCaption).GoodColumnWithPercentMatches)
            {
                SelectedColumnMatches.Add(item);
            }
        }

        public void DocumentLoaded(object _spreadSheet)
        {
            if (!(_spreadSheet is SpreadsheetControl))
                return;
            IWorkbook WorkBook = (_spreadSheet as SpreadsheetControl).Document;
            foreach (Worksheet ws in WorkBook.Worksheets)
            {
                DevExpress.Spreadsheet.Range usedRange = ws.GetUsedRange();

                SheetInfo sheetInfo = new SheetInfo(usedRange.RightColumnIndex - usedRange.LeftColumnIndex);
                sheetInfo.WorkSheetName = ws.Name + " (" + sheetInfo.ColumnsCount.ToString() + " столбцов)";
                for (int i = usedRange.TopRowIndex; i < usedRange.BottomRowIndex; i++)
                {
                    sheetInfo.AddNewRow();
                    for (int j = usedRange.LeftColumnIndex; j < usedRange.RightColumnIndex; j++)
                        sheetInfo.CurrentRowInfo.AddCell(ws.Cells[i, j]);

                    if (sheetInfo.GetStatisticForRow())
                    {
                        for (int j = usedRange.LeftColumnIndex; j < usedRange.RightColumnIndex; j++)
                        {
                            if (ws.Cells[i, j].Value.Type == CellValueType.Text)
                            {
                                var captionValue = new ColumnCaption {
                                        Caption = ws.Cells[i, j].Value.ToString().ToLower()
                                                    .Replace(":", " ").Replace("_", " ").Replace(".", " ").Replace(",", " ").Replace("/", " ").Replace("\\", " ")
                                                    .Replace("\n", "").Replace("  ", " ")
                                    };

                                if (!sheetInfo.ColumnCaptionList.Exists(c => c.Caption == captionValue.Caption))
                                {
                                    captionValue.CompareWithGoodColumns(GoodColumns);
                                    sheetInfo.ColumnCaptionList.Add(captionValue);
                                }
                            }
                        }
                    }
                }
                WorkSheetsInBook.Add(sheetInfo);
            }
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

    public class SheetInfo : BindableBase
    {
        private List<RowInfo> rangeRows;
        public int ColumnsCount { get; set; }
        public string WorkSheetName { get; set; }

        public RowInfo CurrentRowInfo { get; private set; }

        public Dictionary<string, int> SummRowsInfo { get; set; }

        public List<ColumnCaption> ColumnCaptionList { get; set; }

        public SheetInfo(int _columnsCount)
        {
            rangeRows = new List<RowInfo>();
            ColumnsCount = _columnsCount;

            SummRowsInfo = new Dictionary<string, int>();
            ColumnCaptionList = new List<ColumnCaption>();
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
    }

    public class ColumnCaption
    {
        public string Caption { get; set; }
        public GoodColumnWithPercentMathces BestValue { get; set; }
        public List<GoodColumnWithPercentMathces> GoodColumnWithPercentMatches { get; set; }

        public ColumnCaption()
        {
            GoodColumnWithPercentMatches = new List<GoodColumnWithPercentMathces>();
            BestValue = new GoodColumnWithPercentMathces { Percent = 0 };
        }

        internal void CompareWithGoodColumns(ObservableCollection<GoodColumn> goodColumns)
        {
            foreach (var item in goodColumns)
            {
                var percent = (float)Math.Round((new MatchsMaker(item.Name, Caption)).Score * 100);
                GoodColumnWithPercentMatches.Add(new GoodColumnWithPercentMathces { GoodColumnId = item.Id, GoodColumnName = item.Name, Percent = percent });
                if (percent > BestValue.Percent)
                {
                    BestValue.Percent = percent;
                    BestValue.GoodColumnId = item.Id;
                    BestValue.GoodColumnName = item.Name;
                }
            }
            GoodColumnWithPercentMatches.Sort((one, two) => { if (one.Percent > two.Percent) return -1; else return 1; });
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