namespace mba_model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_queue_rules")]
    public partial class AsteriskQueueRule
    {
        [Key]
        public string rule_name { get; set; }
        public string time { get; set; }
        public string min_penalty { get; set; }
        public string max_penalty { get; set; }
    }
}
