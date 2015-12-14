namespace mba_model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ast_queues")]
    public partial class AsteriskQueue
    {
        [Key]
        public string Name { get; set; }
        public string MusicOnHold { get; set; }
        public string Announce { get; set; }
        public string Context { get; set; }
        public int? Timeout { get; set; }
        public string RinginUse { get; set; }
        public string setinterfacevar { get; set; }
        public string setqueuevar { get; set; }
        public string setqueueentryvar { get; set; }
        public string monitor_format { get; set; }
        public string membermacro { get; set; }
        public string membergosub { get; set; }
        public string queue_youarenext { get; set; }
        public string queue_thereare { get; set; }
        public string queue_callswaiting { get; set; }
        public string queue_quantity1 { get; set; }
        public string queue_quantity2 { get; set; }
        public string queue_holdtime { get; set; }
        public string queue_minutes { get; set; }
        public string queue_minute { get; set; }
        public string queue_seconds { get; set; }
        public string queue_thankyou { get; set; }
        public string queue_callerannounce { get; set; }
        public string queue_reporthold { get; set; }
        public int? announce_frequency { get; set; }
        public string announce_to_first_user { get; set; }
        public int? min_announce_frequency { get; set; }
        public int? announce_round_seconds { get; set; }
        public string announce_holdtime { get; set; }
        public string announce_position { get; set; }
        public int? announce_position_limit { get; set; }
        public string periodic_announce { get; set; }
        public int? periodic_announce_frequency { get; set; }
        public string relative_periodic_announce { get; set; }
        public string random_periodic_announce { get; set; }
        public int? retry { get; set; }
        public int? wrapuptime { get; set; }
        public int? penaltymemberslimit { get; set; }
        public string autofill { get; set; }
        public string monitor_type { get; set; }
        public string autopause { get; set; }
        public int? autopausedelay { get; set; }
        public string autopausebusy { get; set; }
        public string autopauseunavail { get; set; }
        public int? maxlen { get; set; }
        public int? servicelevel { get; set; }
        public string strategy { get; set; }
        public string joinempty { get; set; }
        public string leavewhenempty { get; set; }
        public string reportholdtime { get; set; }
        public int? memberdelay { get; set; }
        public int? weight { get; set; }
        public string timeoutrestart { get; set; }
        public string defaultrule { get; set; }
        public string timeoutpriority { get; set; }
    }
}
