namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_inbound")]
    public partial class AsteriskInbound
    {
        public short ID { get; set; }
        [Key]
        public long DID { get; set; }
        public string Queue { get; set; }
        public string voice_announce { get; set; }
        public string email { get; set; }
        public string priority_trunk { get; set; }
        public string work_time { get; set; }
        public string voice_announce_not_work { get; set; }
        public string voice_announce_busy { get; set; }
        public string cname { get; set; }
        public int? queue_timeout { get; set; }
        public byte hot_line { get; set; }
        public byte region_number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? deleted { get; set; }
    }
}
