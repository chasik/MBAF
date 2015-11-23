using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels.Manager
{
    [POCOViewModel]
    public class ManagerTasksViewModel
    {
        protected ManagerTasksViewModel() { }

        public static ManagerTasksViewModel Create()
        {
            return ViewModelSource.Create(() => new ManagerTasksViewModel());
        }
    }
}