using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract]
    public class Permission
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ParentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ScreenName { get; set; }
        [DataMember]
        public string Tooltip { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string CommandParam { get; set; }

        [DataMember]
        public virtual ICollection<Role> Roles { get; set; }
        [DataMember]
        public virtual ICollection<User> Users { get; set; }
    }
}
