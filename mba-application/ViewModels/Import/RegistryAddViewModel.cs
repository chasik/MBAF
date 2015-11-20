using System;
using DevExpress.Mvvm;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Spreadsheet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mba_application.MBAComponents;
using mba_application.MBAImportService;

namespace mba_application.ViewModels.Import
{
    public class RegistryAddViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        public MBAImportService.ImportServiceClient ImportService;
        public RegistryAddViewModel()
        {
            ShowProgressBar = "Collapsed";
            WorkSheetsCount = "Результаты парсинга документа ...";
            WorkSheetsInBook = new ObservableCollection<SheetInfo>();

            //GoodColumnsNames = new Dictionary<int, string>();

            ImportService = new MBAImportService.ImportServiceClient();
            GoodColumns = ImportService.GetGoodColumnList();
        }

        public string SourceFilePath
        {
            get { return GetProperty(() => SourceFilePath); }
            set { SetProperty(() => SourceFilePath, value); }
        }
        public string ShowProgressBar
        {
            get { return GetProperty(() => ShowProgressBar); }
            set { SetProperty(() => ShowProgressBar, value); }
        }
        public string WorkSheetsCount
        {
            get { return GetProperty(() => WorkSheetsCount); }
            set { SetProperty(() => WorkSheetsCount, value); }
        }

        public ObservableCollection<SheetInfo> WorkSheetsInBook
        {
            get { return GetProperty(() => WorkSheetsInBook); }
            set { SetProperty(() => WorkSheetsInBook, value); }
        }

        public GoodColumn[] GoodColumns
        {
            get { return GetProperty(() => GoodColumns); }
            set {
                SetProperty(() => GoodColumns, value);
                //GoodColumnsNames.Clear();
                foreach (var item in value)
                {
                    //GoodColumnsNames.Add(item.GoodColumnId, item.GoodColumnName);
                }
            }
        }

<<<<<<< HEAD
        public Client[] ClientsCollection
        {
            get { return GetProperty(() => ClientsCollection); }
            set { SetProperty(() => ClientsCollection, value); }
        }
=======
        //public Dictionary<int, string> GoodColumnsNames { get; private set; }
>>>>>>> 6ffeacc5dd44d3de79ee0143d8c9452c1a7cc2bb

        public void DblClickExplorer(FileSystemItem focusedNode)
        {
            // TODO: сделать проверку через регулярное выражение
            if (focusedNode.FullName.IndexOf(".xls", 0, StringComparison.InvariantCultureIgnoreCase) > -1
                    || focusedNode.FullName.IndexOf(".xlsx", 0, StringComparison.InvariantCultureIgnoreCase) > -1
               )
            {
                WorkSheetsInBook.Clear();
                SourceFilePath = focusedNode.FullName;
            }
        }

        public void DocumentLoaded(object _spreadSheet)
        {
            //ShowProgressBar = "Visible";
            if (_spreadSheet is SpreadsheetControl)
            {
                IWorkbook WorkBook = (_spreadSheet as SpreadsheetControl).Document;
                WorkSheetsCount = "Найдено листов: " + WorkBook.Worksheets.Count.ToString();
                foreach (Worksheet ws in WorkBook.Worksheets)
                {
                    Range usedRange = ws.GetUsedRange();

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
                                    var captionValue = new ColumnCaption
                                    {
                                        Caption = ws.Cells[i, j].Value.ToString().ToLower()
                                            .Replace(":", " ").Replace("_", " ").Replace(".", " ").Replace(",", " ").Replace("/", " ").Replace("\\", " ")
                                            .Replace("\n", "").Replace("  ", " ")
                                    };
                                    if (!sheetInfo.ColumnCaptionList.Exists(c => c.Caption == captionValue.Caption))
                                    {
                                        captionValue.GoodColumnRef = ImportService.GetGoodColumn(captionValue.Caption);
                                        captionValue.GoodColumnListRef = new GoodColumnsListDC();
                                        captionValue.GoodColumnListRef.Add(captionValue.GoodColumnRef);
                                        captionValue.GoodColumnListRef.AddRange(GoodColumns);
                                        sheetInfo.ColumnCaptionList.Add(captionValue);
                                    }
                                }
                            }
                        }
                    }
                    WorkSheetsInBook.Add(sheetInfo);
                }
            }
            //ShowProgressBar = "Collapsed";
        }

        public void ChangeGoodColumn(object param)
        {
            ImportService.AddGoodColumnRelation(param as GoodColumnAddRelationParamDC);
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
        public ColumnCaption()
        {
        }
        public string Caption { get; set; }
        public GoodColumnDC GoodColumnRef { get; set; }
        public GoodColumnsListDC GoodColumnListRef { get; set; }
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