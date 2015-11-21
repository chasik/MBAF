using System.ServiceModel;
using mba_services.DataContracts;
using mba_model;

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
        bool AddGoodColumnRelation(GoodColumnAddRelationParamDC param);
    }
}
