using mba_model;
using System.Runtime.Serialization;

namespace mba_services.DataContracts
{
    [DataContract]
    public class PermissionDC
    {
        [DataMember] public int Id;
        [DataMember] public int PermissionGroupId;
        [DataMember] public string GroupName;
        [DataMember] public string Name;
        [DataMember] public string ScreenName;
        [DataMember] public string Tooltip;
        [DataMember] public string Description;
        [DataMember] public string ImageSource;
        [DataMember] public string CommandParam;
    }

    [DataContract]
    public class PermissionsDC
    {
        public PermissionsDC()
        {
        }

        [DataMember] public Permission[] Permissions;
        [DataMember] public string Login;
    }
}
