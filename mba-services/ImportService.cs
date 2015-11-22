using System;
using System.Linq;

using mba_model;
using mba_services.ServiceContracts;

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

        public ImportType[] ImportTypes()
        {
            return (from it in dbContext.ImportTypes select it).ToArray();
        }
    }
}
