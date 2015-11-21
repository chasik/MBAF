using System.Linq;

using mba_model;
using mba_services.DataContracts;
using mba_services.ServiceContracts;
using System;

namespace mba_services
{
    public class ImportService : IImportService
    {
        private ModelContext dbContext;

        public ImportService()
        {
            dbContext = new ModelContext();
            dbContext.Configuration.ProxyCreationEnabled = false;
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

        public Client[] Clients()
        {
            return (from client in dbContext.Clients
                    where client.Deleted == null
                    select client
                   ).ToArray();
        }

        public GoodColumn GoodColumn(string columnHeader)
        {
            return (from gc in dbContext.GoodColumns
                    join ch in dbContext.ColumnHeaders on gc.Id equals ch.GoodColumnId
                    where ch.Name == columnHeader
                    select gc
                   ).FirstOrDefault() ?? new GoodColumn { Id = 0, Name = "Не определен" };
        }

        public GoodColumn[] GoodColumns()
        {
            return (from gc in dbContext.GoodColumns
                     where gc.Deleted == null
                     select gc
                   ).ToArray();
        }

    }
}
