using mba_model;
using System.ServiceModel;

namespace mba_services.ServiceContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAsteriskService" in both code and config file together.
    [ServiceContract]
    public interface IAsteriskService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        AsteriskSipPeer[] GetAllSipPeers();
    }
}
