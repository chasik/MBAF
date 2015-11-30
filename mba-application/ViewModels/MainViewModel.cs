using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using mba_application.MBAComponents;
using mba_application.MBAComponents.MBAMessages;
using System.Collections.ObjectModel;

namespace mba_application.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Employee CurrentEmployee { get; set; }

        public ObservableCollection<PermissionGroup> UserPermissionGroups
        {
            get { return GetProperty(() => UserPermissionGroups); }
            set { SetProperty(() => UserPermissionGroups, value); }
        }

        public DelegateCommand<string> MenuItemClickCommand { get; private set; }

        private INavigationService NavigationService { get { return GetService<INavigationService>(); } }

        public MainViewModel()
        {
            CurrentEmployee = new Employee();

            MenuItemClickCommand = new DelegateCommand<string>(MenuItemClick);
        }

        public void OnInitMainView()
        {
            if (CurrentEmployee.TryEnter())
            {
                UserPermissionGroups = new ObservableCollection<PermissionGroup>(CurrentEmployee.PermissionGroups);

                NavigationService.Navigate("RegistryAddView", null, this);
            }
            else
            {
                NavigationService.Navigate("TryEnterError", null, this);
            }
        }
        public void MenuItemClick(string frameName)
        {
            NavigationService.Navigate(frameName);
        }

        [Command]
        public void CloseMainWindow()
        {
            Messenger.Default.Send(new CloseProgramMessage());
        }
    }
}