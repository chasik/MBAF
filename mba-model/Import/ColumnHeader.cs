using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract]
    public class ColumnHeader
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<ColumnHeaderClient> ColumnHeader_Client { get; set; }
    }
}
