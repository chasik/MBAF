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

        public bool AddGoodColumnRelation(GoodColumnAddRelationParamDC param)
        {
            ColumnHeader colHeader = (from ch in dbContext.ColumnHeaders
                                      where ch.Name == param.ColumnHeader
                                      select ch
                                      ).FirstOrDefault() ?? dbContext.ColumnHeaders.Add(new ColumnHeader { Name = param.ColumnHeader });

            colHeader.GoodColumn = (from gc in dbContext.GoodColumns
                                    where gc.Id == param.GoodColumn.GoodColumnId
                                    select gc
                                   ).FirstOrDefault();

            dbContext.SaveChanges();
            return true;
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

        public GoodColumn[] GoodColumns()
        {
            var z = dbContext.GoodColumns.Where(gc => gc.Deleted == null).ToArray();
            return z;
        }
    }
}
