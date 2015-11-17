using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class Client
    {
        public int Id { get; set; }
        public int InnerId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ScreenName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Deleted { get; set; }
        public int? DeletedBy { get; set; }
    }
}
