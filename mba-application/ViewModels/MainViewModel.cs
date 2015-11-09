using DevExpress.Mvvm;

namespace mba_application.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        public MainViewModel()
        {

        }
        public void OnViewLoaded()
        {
            NavigationService.Navigate("FirstView", null, this);
        }
    }
}