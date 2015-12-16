using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract()]
    public class Role
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public string ScreenName{ get; set; }

        [DataMember()]
        public virtual ICollection<User> Users { get; set; }
        [DataMember()]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
