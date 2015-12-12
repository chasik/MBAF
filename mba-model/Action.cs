using System.Collections.Generic;

namespace mba_model
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserAction> UserActions { get; private set; }
    }
}
