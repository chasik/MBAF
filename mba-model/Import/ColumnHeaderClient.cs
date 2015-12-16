using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract(IsReference = true), Table("ColumnHeader_Client")]
    public class ColumnHeaderClient
    {
        [DataMember(), Key, Column(Order = 0)]
        public int ColumnHeaderId { get; set; }
        [DataMember(), Key, Column(Order = 1)]
        public int ClientId { get; set; }
        [DataMember()]
        public int? GoodColumnId { get; set; }

        [DataMember()]
        public virtual GoodColumn GoodColumn { get; set; }
        [DataMember()]
        public virtual ColumnHeader ColumnHeader { get; set; }
        [DataMember()]
        public virtual Client Client { get; set; }

        // additional info
        [DataMember()]
        public bool SaveToDB { get; set; }
        [DataMember(), Column(TypeName = "datetime2")]
        public DateTime Changed { get; set; }
    }
}
