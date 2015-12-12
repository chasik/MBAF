using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class UserAction
    {
        public int UserId { get; set; }
        public int ActionId { get; set; }

        // additional info
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
        public virtual Action Action { get; set; }
    }
}
