namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_musiconhold")]
    public partial class AsteriskMusicOnHold
    {
        [Key]
        public string name { get; set; }
        public string mode { get; set; }
        public string directory { get; set; }
        public string application { get; set; }
        public string digit { get; set; }
        public string sort { get; set; }
        public string format { get; set; }
        public DateTime? stamp { get; set; }
    }
}
