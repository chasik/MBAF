using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels
{
    [POCOViewModel]
    public class PhoneViewModel
    {
        public virtual string Number { get; set; }

        public PhoneViewModel() { }

        protected void OnNumberChanged(string oldValue)
        {
        }

        protected void OnNumberChanging(string newValue)
        {
        }

        [Command(CanExecuteMethodName = "CanPhoneButtonClick",
                 Name = "PhoneButtonClickCommand",
                 UseCommandManager = true)]
        public void PhoneButtonClick(string param)
        {
            var z = param;
        }
        public bool CanPhoneButtonClick(string param)
        {
            return true;
        }
    }
}