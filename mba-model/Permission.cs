using System.Collections.Generic;

namespace mba_model
{
    public class Permission
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Tooltip { get; set; }
        public string ImageSource { get; set; }

        public virtual List<Role> Roles { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
