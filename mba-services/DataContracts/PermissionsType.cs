using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_services.DataContracts
{
    [DataContract]
    public class PermissionsType
    {
        public PermissionsType()
        {
            Permissions = new List<string>();
        }
        [DataMember]
        public List<string> Permissions;
    }
}
