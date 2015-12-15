using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract]
    public class Action
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public virtual ICollection<UserAction> UserActions { get; set; }
    }
}
