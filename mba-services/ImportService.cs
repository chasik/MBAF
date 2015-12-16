using System.Linq;

using mba_model;
using mba_services.ServiceContracts;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

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

        public ColumnHeader[] AddColumnHeaders(string[] columnHeaders)
        {
            var columnHeaderCollection = new List<ColumnHeader>();
            foreach (var item in columnHeaders)
            {
                ColumnHeader addedColumnHeader;
                if (!dbContext.ColumnHeaders.Any(ch => ch.Name == item))
                    addedColumnHeader = dbContext.ColumnHeaders.Add(new ColumnHeader { Name = item });
                else
                    addedColumnHeader = dbContext.ColumnHeaders.Include("ColumnHeaderClients").Where(ch => ch.Name == item).FirstOrDefault();

                columnHeaderCollection.Add(addedColumnHeader);
            }
            dbContext.SaveChanges();

            return columnHeaderCollection.ToArray();
        }

        public void AddRelationColumnHeadersClient(ObservableCollection<ColumnHeader> columnHeaders, Client client)
        {
            Client clientInDB = dbContext.Clients.Include("ColumnHeaderClients").Where(c => c.Id == client.Id).FirstOrDefault();
            foreach (var ch in columnHeaders)
            {
                var newColumnHeaderClient = new ColumnHeaderClient { ClientId = client.Id, ColumnHeaderId = ch.Id, Changed = DateTime.Now };
                if (!clientInDB.ColumnHeaderClients.Any(colh => colh.ColumnHeaderId == newColumnHeaderClient.ColumnHeaderId && colh.ClientId == newColumnHeaderClient.ClientId))
                    clientInDB.ColumnHeaderClients.Add(newColumnHeaderClient);
            }
            dbContext.SaveChanges();
        }

        public Client[] Clients()
        {
            return (from client in dbContext.Clients
                    where client.Deleted == null
                    orderby client.Name
                    select client
                   ).ToArray();
        }

        public GoodColumn GoodColumn(string columnHeader)
        {
            return (from gc in dbContext.GoodColumns
                    //join ch in dbContext.ColumnHeaders on gc.Id equals ch.ColumnHeader_Client.GoodColumnId
                    //where ch.Name == columnHeader
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
