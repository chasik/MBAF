using mba_services.DataContracts;
using mba_services.ServiceContracts;

namespace mba_services
{
    public class PermissionsService : IPermissionsService
    {
        public PermissionsType GetPermission()
        {
            PermissionsType permission = new PermissionsType();

            return permission;
        }
    }
}
