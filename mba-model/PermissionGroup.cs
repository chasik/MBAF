using System.Collections.Generic;

namespace mba_model
{
    public class PermissionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Tooltip { get; set; }
        public string ImageSource { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
