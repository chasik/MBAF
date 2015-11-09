using mba_services.DataContracts;
using mba_services.ServiceContracts;

using mba_model;
using System.ServiceModel;

namespace mba_services
{
    public class PermissionsService : IPermissionsService
    {
        public PermissionsType GetPermissions()
        {
            PermissionsType permission = new PermissionsType();
            //permission.UserName = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            permission.UserName = ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType;
            //permission.UserName = ServiceSecurityContext.Current.WindowsIdentity.Name;


            using (ModelContext mcontext = new ModelContext())
            {
                
            }

            return permission;
        }
    }
}
