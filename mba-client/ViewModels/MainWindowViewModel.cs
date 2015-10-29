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
    class Employee
    {
        public string Name { get; set; }
    }
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand<string> AutoUpdateCommand { get; private set; }
        private INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
        public MainWindowViewModel()
        {
            AutoUpdateCommand = new DelegateCommand<string>(AutoUpdateCommandExecute);
        }
        public void OnViewLoaded()
        {
            NavigationService.Navigate("OperatorWorkFlowView", null, this);
        }
        void AutoUpdateCommandExecute(string parameter)
        {
            NavigationService.Navigate(parameter, null, this);
        }
    }
}
