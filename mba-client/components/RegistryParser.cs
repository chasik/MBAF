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
        private IWorkbook workBook;
        public IWorkbook WorkBook { get; set; }

        internal void Analysis()
        {
            //foreach (Worksheet ws in excelControl.Document.Worksheets)
            //{
            //    Range usedRange = ws.GetUsedRange();
            //    for (int i = 0; i<usedRange.RowCount; i++)
            //    {

            //    }
            //}
        }
    }
}
