using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract(), Table("User_Action")]
    public class UserAction
    {
        [DataMember(), Key, Column(Order = 0)]
        public int UserId { get; set; }
        [DataMember(), Key, Column(Order = 1)]
        public int ActionId { get; set; }

        // additional info
        [DataMember(), Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [DataMember()]
        public virtual User User { get; set; }
        [DataMember()]
        public virtual Action Action { get; set; }
    }
}
