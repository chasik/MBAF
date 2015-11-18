using System.ServiceModel;
using mba_services.DataContracts;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IImportService
    {
        [OperationContract]
        GoodColumnDC GetGoodColumn(string columnHeader);

        [OperationContract]
        GoodColumnsListDC GetGoodColumnList();
    }
}
