using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class ColumnHeaderClient
    {
        public int ColumnHeaderId { get; set; }
        public int ClientId { get; set; }

        // additional info
        [Column(TypeName = "datetime2")]
        public DateTime Changed { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
