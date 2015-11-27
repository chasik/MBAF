using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels
{
    [POCOViewModel]
    public class PhoneViewModel
    {
        public virtual string Number { get; set; }

        public PhoneViewModel() { Number = ""; }

        public static PhoneViewModel Create()
        {
            return ViewModelSource.Create(() => new PhoneViewModel());
        }

        protected void OnNumberChanged(string oldValue)
        {
        }

        protected void OnNumberChanging(string newValue)
        {
        }
    }
}