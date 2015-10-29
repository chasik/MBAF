using System;
using DevExpress.Mvvm;

namespace mba_client.ViewModels
{
    public class RegistryAddViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
    }
}