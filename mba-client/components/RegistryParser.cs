using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;

namespace mba_client.components
{
    class RegistryParser
    {
        public IWorkbook WorkBook { get; set; }

        internal void Analysis()
        {
            RangeInfo rangeInfo;
            foreach (Worksheet ws in WorkBook.Worksheets)
            {
                Range usedRange = ws.GetUsedRange();
                rangeInfo = new RangeInfo(usedRange.RightColumnIndex - usedRange.LeftColumnIndex);
                for (int i = usedRange.TopRowIndex; i < usedRange.BottomRowIndex; i++)
                {
                    rangeInfo.AddNewRow();
                    for (int j = usedRange.LeftColumnIndex; j < usedRange.RightColumnIndex; j++)
                    {
                        rangeInfo.CurrentRowInfo.AddCell(ws.Cells[j, i]);
                    }
                    rangeInfo.GetStatisticForRow();
                }
            }
        }
    }

    class RangeInfo
    {
        private List<RowInfo> rangeRows;
        private int columnsCount;
        public RowInfo CurrentRowInfo { get; private set; }
        public RangeInfo(int _columnsCount)
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
        }
    }

    class RowInfo
    {
        private Dictionary<CellValueType, RowStruct> cellTypesDictionary;
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
                cellTypesDictionary[cellType].Count = 2;
            else
                cellTypesDictionary.Add(cellType, new RowStruct(columnsCount));

        }
    }

    internal class RowStruct
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
}
