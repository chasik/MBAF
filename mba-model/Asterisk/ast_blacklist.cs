namespace mba_model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_blacklist")]
    public partial class AsteriskBlacklist
    {
        [Key]
        public int Id { get; set; }
        public long? PhoneNumber { get; set; }
        public DateTime? Created { get; set; }
        public string UserName { get; set; }
    }
}
