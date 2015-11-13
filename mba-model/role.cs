using System.Collections.Generic;

namespace mba_model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScreenName{ get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
