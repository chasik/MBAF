using System.ServiceModel;
using mba_model;
using System.Collections.Generic;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IImportService
    {
        [OperationContract]
        GoodColumn GoodColumn(string columnHeader);

        [OperationContract]
        GoodColumn[] GoodColumns();

        [OperationContract]
        Client[] Clients();

        [OperationContract]
        ImportType[] ImportTypes();

        [OperationContract]
        Client AnalyzeColumnHeaders(ColumnHeader[] columnHeaders);
    }
}
