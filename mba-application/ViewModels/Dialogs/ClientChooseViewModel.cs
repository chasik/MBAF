using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using mba_model;

namespace mba_application.ViewModels.Dialogs
{
    [POCOViewModel]
    public class ClientChooseViewModel
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<ImportType> ImportTypes { get; set; }

        public ClientChooseViewModel()
        {
            Clients = new ObservableCollection<Client>();
            ImportTypes = new ObservableCollection<ImportType>();
        }
    }
}