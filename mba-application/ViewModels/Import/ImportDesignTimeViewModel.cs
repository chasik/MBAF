using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Spreadsheet;
using mba_model;

namespace mba_application.ViewModels.Import
{
    public class ImportDesignTimeViewModel
    {
        public ImportDesignTimeViewModel()
        {
            var sheet1 = new SheetInfo
            {
                RelatedClients = new ObservableCollection<RelatedClientInfo>
                {
                    new RelatedClientInfo
                    { 
                        Client = new Client { Id = 17, ParentId = null, InnerId = 240, Name = "Траст", FullName = "ПАО НБ \"Траст\"", Image = "240-bank-trast.png" },
                    }, 
                    new RelatedClientInfo
                    {
                        Client = new Client { Id = 25, ParentId = null, InnerId = 251, Name = "Сбербанк", FullName = "ПАО «Сбербанк России»", Image = "251-sber-bank.png"}
                    }
                },
                ColumnHeaderList = new List<ColumnHeaderValue>
                {
                    new ColumnHeaderValue {Caption = "TEST COLUMN HEADER"},
                    new ColumnHeaderValue {Caption = "TEST COLUMN HEADER 2"}
                }
            };
            WorkSheetsInBook = new ObservableCollection<SheetInfo> {sheet1, new SheetInfo()};
        }

        public ObservableCollection<SheetInfo> WorkSheetsInBook { get; set; }
    }
}
