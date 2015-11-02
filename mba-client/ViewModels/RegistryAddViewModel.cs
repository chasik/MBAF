using System;
using DevExpress.Mvvm;
using DevExpress.Xpf.Spreadsheet;
using mba_client.components;
using DevExpress.Spreadsheet;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace mba_client.ViewModels
{
    public class RegistryAddViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        public RegistryAddViewModel()
        {
            ShowProgressBar = "Collapsed";
            WorkSheetsCount = "Результаты парсинга документа ...";
            WorkSheetsInBook = new ObservableCollection<SheetInfo>();
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
                    sheetInfo.WorkSheetName = ws.Name;
                    for (int i = usedRange.TopRowIndex; i < usedRange.BottomRowIndex; i++)
                    {
                        sheetInfo.AddNewRow();
                        for (int j = usedRange.LeftColumnIndex; j < usedRange.RightColumnIndex; j++)
                            sheetInfo.CurrentRowInfo.AddCell(ws.Cells[i, j]);

                        sheetInfo.GetStatisticForRow();
                    }
                    WorkSheetsInBook.Add(sheetInfo);
                }
            }
            //ShowProgressBar = "Collapsed";
        }
    }

    public class RowStruct
    {
        private int columnsCount;
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
        private int columnsCount;
        public string WorkSheetName
        {
            get { return GetProperty(() => WorkSheetName); }
            set { SetProperty(() => WorkSheetName, value); }
        }
        public RowInfo CurrentRowInfo { get; private set; }

        public SheetInfo(int _columnsCount)
        {
            rangeRows = new List<RowInfo>();
            columnsCount = _columnsCount;
        }
        public void AddNewRow()
        {
            CurrentRowInfo = new RowInfo(columnsCount);
            rangeRows.Add(CurrentRowInfo);
        }
        internal void GetStatisticForRow()
        {
            foreach (var cellType in CurrentRowInfo.cellTypesDictionary)
            {

            }
        }
    }

    public class RowInfo
    {
        public Dictionary<CellValueType, RowStruct> cellTypesDictionary;
        private int columnsCount;
        public RowInfo(int _columnsCount)
        {
            columnsCount = _columnsCount;
            cellTypesDictionary = new Dictionary<CellValueType, RowStruct>();
        }
        internal void AddCell(Cell cell)
        {
            CellValueType cellType = cell.Value.Type;
            if (cellTypesDictionary.ContainsKey(cellType))
                cellTypesDictionary[cellType].Count += 1;
            else
                cellTypesDictionary.Add(cellType, new RowStruct(columnsCount));
        }
    }
}