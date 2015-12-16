using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    public class Permission
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }

        public string Tooltip { get; set; }
        public string Image { get; set; }
        public string CommandParam { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
