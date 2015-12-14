namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_mtt_codes")]
    public partial class AsteriskMttCode
    {
        [Key]
        public int id { get; set; }
        public short @operator { get; set; }
        public byte region { get; set; }
        public short def { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public DateTime date { get; set; }
    }
}
