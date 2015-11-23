using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels.Manager
{
    [POCOViewModel]
    public class ManagerAutoTasksViewModel
    {
        protected ManagerAutoTasksViewModel() { }

        public static ManagerAutoTasksViewModel Create()
        {
            return ViewModelSource.Create(() => new ManagerAutoTasksViewModel());
        }
    }
}