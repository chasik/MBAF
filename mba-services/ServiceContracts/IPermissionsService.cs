using System.ServiceModel;
using mba_model;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Permission[] Permissions();
        [OperationContract]
        User[] Users();
    }
}
