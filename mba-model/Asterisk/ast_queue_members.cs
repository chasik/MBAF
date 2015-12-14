namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_queue_members")]
    public partial class AsteriskQueueMember
    {
        [Key, Column(Order = 1)]
        public string queue_name { get; set; }
        [Key, Column(Order = 2)]
        public string @interface { get; set; }
        public string membername { get; set; }
        public string state_interface { get; set; }
        public int? penalty { get; set; }
        public int? paused { get; set; }
        public int uniqueid { get; set; }
    }
}
