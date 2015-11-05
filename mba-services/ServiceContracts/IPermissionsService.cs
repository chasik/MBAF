using System.ServiceModel;
using mba_services.DataContracts;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IPermissionsService
    {
        [OperationContract]
        PermissionsType GetPermission();
    }
}
