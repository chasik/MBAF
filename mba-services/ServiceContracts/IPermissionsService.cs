using System.ServiceModel;
using mba_model;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IPermissionsService
    {
        [OperationContract]
        Permission[] Permissions();
    }
}
