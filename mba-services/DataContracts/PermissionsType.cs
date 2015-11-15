using System.Collections.Generic;
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
            PermissionsHashSet = new HashSet<PermissionDC>();
        }

        [DataMember] public IEnumerable<PermissionDC> PermissionsHashSet;
        [DataMember] public string Login;
    }
}
