using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mba_model
{
    public class ColumnHeader
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ColumnHeaderClient> ColumnHeaderClients { get; set; }
    }
}
