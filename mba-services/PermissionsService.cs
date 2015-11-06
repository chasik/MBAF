using mba_services.DataContracts;
using mba_services.ServiceContracts;

using mba_model;
using System.ServiceModel;

namespace mba_services
{
    public class PermissionsService : IPermissionsService
    {
        public PermissionsType GetPermission()
        {
            PermissionsType permission = new PermissionsType();
            permission.UserName = ServiceSecurityContext.Current.WindowsIdentity.Name;


            using (ModelContext mcontext = new ModelContext())
            {
                Role r = new Role { Name = "operator", ScreenName = "Оператор" };
                mcontext.Roles.Add(r);
                mcontext.SaveChanges();
            }


            return permission;
        }
    }
}
