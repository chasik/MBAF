namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_cdr")]
    public partial class AsteriskCallDetail
    {
        [Key, Column(Order = 1, TypeName = "datetime2")]
        public DateTime date { get; set; }
        [Key, Column(Order = 2)]
        public long abonent { get; set; }

        public short? mbanumber { get; set; }
        public byte type { get; set; }
        public short oper { get; set; }
        public string queue_name { get; set; }
        public short duration { get; set; }
        public short billsec { get; set; }
        public byte disposition { get; set; }
        public long uniqueid { get; set; }
    }
}
