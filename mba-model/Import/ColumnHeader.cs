using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int GoodColumnId { get; set; }

        [DataMember]
        public virtual GoodColumn GoodColumn { get; set; }
    }
}
