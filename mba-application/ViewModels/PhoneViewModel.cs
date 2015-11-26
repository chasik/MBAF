using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels
{
    [POCOViewModel]
    public class PhoneViewModel
    {
        protected PhoneViewModel() { }

        public static PhoneViewModel Create()
        {
            return ViewModelSource.Create(() => new PhoneViewModel());
        }
    }
}