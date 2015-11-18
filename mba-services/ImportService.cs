using System;
using System.Linq;

using mba_model;
using mba_services.DataContracts;
using mba_services.ServiceContracts;

namespace mba_services
{
    public class ImportService : IImportService
    {
        private ModelContext dbContext;
        public ImportService()
        {
            dbContext = new ModelContext();
        }

        public GoodColumnDC GetGoodColumn(string columnHeader)
        {
            GoodColumnDC goodCol = (from gc in dbContext.GoodColumns
                                    join ch in dbContext.ColumnHeaders on gc.Id equals ch.GoodColumnId
                                    where ch.Name == columnHeader
                                    select new GoodColumnDC { GoodColumnId = gc.Id, GoodColumnName = gc.Name }
                                   ).FirstOrDefault();

            return goodCol ?? new GoodColumnDC { GoodColumnId = 0, GoodColumnName = "Не определен" };
        }

        public GoodColumnsListDC GetGoodColumnList()
        {
            GoodColumnsListDC result = new GoodColumnsListDC();

            var goodColumnList = dbContext.GoodColumns.Where(gc => gc.Deleted == null).ToList();
            foreach (var gc in goodColumnList)
            {
                result.Add(new GoodColumnDC { GoodColumnId = gc.Id,  GoodColumnName = gc.ScreenName});
            }
            return result;
        }
    }
}
