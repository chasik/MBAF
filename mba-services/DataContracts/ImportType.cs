using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace mba_services.DataContracts
{
    [DataContract]
    public class GoodColumnDC
    {
        [DataMember] public int GoodColumnId;
        [DataMember] public string GoodColumnName;
    }

    [DataContract]
    public class GoodColumnAddRelationParamDC
    {
        [DataMember] public GoodColumnDC GoodColumn;
        [DataMember] public string ColumnHeader;
    }

    [CollectionDataContract]
    public class GoodColumnsListDC : ObservableCollection<GoodColumnDC> { }

    [DataContract]
    public class ClientDC
    {
        [DataMember] public int ClientId;
        [DataMember] public string Name;
    }

    [CollectionDataContract]
    public class ClientsCollectionDC : ObservableCollection<ClientDC> { }
}
