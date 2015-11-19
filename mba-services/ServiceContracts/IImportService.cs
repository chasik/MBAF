using System.ServiceModel;
using mba_services.DataContracts;
using mba_model;

namespace mba_services.ServiceContracts
{
    [ServiceContract]
    public interface IImportService
    {
        [OperationContract]
        GoodColumnDC GetGoodColumn(string columnHeader);

        [OperationContract]
        GoodColumn[] GoodColumns();

        [OperationContract]
        bool AddGoodColumnRelation(GoodColumnAddRelationParamDC param);
    }
}
