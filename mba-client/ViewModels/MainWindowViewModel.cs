using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace mba_client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand<string> MenuItemClick { get; private set; }
        private INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
        public MainWindowViewModel()
        {
            MenuItemClick = new DelegateCommand<string>(MenuItemClickExecute);
        }
        public void OnViewLoaded()
        {
            NavigationService.Navigate("RegistryAddView", null, this);
        }
        void MenuItemClickExecute(string parameter)
        {
            NavigationService.Navigate(parameter, null, this);
        }
    }
}
