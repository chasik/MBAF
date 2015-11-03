using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mba_model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScreenName{ get; set; }

        public virtual List<User> Users { get; set; }
    }
}
