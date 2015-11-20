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
<<<<<<< HEAD
        GoodColumn[] GoodColumns();
=======
        GoodColumnsListDC GetGoodColumnList();
>>>>>>> 6ffeacc5dd44d3de79ee0143d8c9452c1a7cc2bb

        [OperationContract]
        bool AddGoodColumnRelation(GoodColumnAddRelationParamDC param);
    }
}
