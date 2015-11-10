using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserAction> UserActions { get; private set; }
    }

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
