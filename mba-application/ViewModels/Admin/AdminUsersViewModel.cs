using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using mba_model;
using System.Collections.Generic;

namespace mba_application.ViewModels.Admin
{
    [POCOViewModel]
    public class AdminUsersViewModel
    {
        protected AdminUsersViewModel()
        {
        }

        public static AdminUsersViewModel Create()
        {
            return ViewModelSource.Create(() => new AdminUsersViewModel());
        }

        public virtual List<User> Users { get; set; }

        public void GetUsers()
        {
            Users = new List<User>((new MBAPermissionsService.PermissionsServiceClient()).Users());
        }
    }
}