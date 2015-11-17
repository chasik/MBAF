using System.ServiceModel;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IImportService
    {
        [OperationContract]
        void DoWork();
    }
}
