using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace mba_application.ViewModels
{
    [POCOViewModel]
    public class FirstViewModel
    {
        protected FirstViewModel()
        {

        }

        public static FirstViewModel Create()
        {
            return ViewModelSource.Create(() => new FirstViewModel());
        }
    }
}