namespace mba_model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_extensions")]
    public partial class AsteriskExtension
    {
        [Key, Column(Order = 1)]
        public long id { get; set; }
        [Key, Column(Order = 2)]
        public string context { get; set; }
        [Key, Column(Order = 3)]
        public string exten { get; set; }
        [Key, Column(Order = 4)]
        public int priority { get; set; }

        public string app { get; set; }
        public string appdata { get; set; }
    }
}
