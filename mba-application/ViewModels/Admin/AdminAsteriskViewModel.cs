using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels.Admin
{
    [POCOViewModel]
    public class AdminAsteriskViewModel
    {
        protected AdminAsteriskViewModel()
        {
        }

        public AdminAsteriskViewModel Create()
        {
            return ViewModelSource.Create(() => new AdminAsteriskViewModel());
        }
    }
}