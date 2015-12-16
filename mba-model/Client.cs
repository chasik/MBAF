using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract()]
    public class Client
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public int? ParentId { get; set; }
        [DataMember()]
        public int InnerId { get; set; }
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public string FullName { get; set; }
        [DataMember()]
        public string Image { get; set; }
        [DataMember(), Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        
        [DataMember()]
        public int CreatedBy { get; set; }
        [DataMember(), Column(TypeName = "datetime2")]
        public DateTime? Deleted { get; set; }
        [DataMember()]
        public int? DeletedBy { get; set; }

        [DataMember()]
        public virtual ICollection<ColumnHeaderClient> ColumnHeaderClients { get; set; }
    }
}
