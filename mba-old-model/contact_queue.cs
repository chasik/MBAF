//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mba_old_model
{
    using System;
    using System.Collections.Generic;
    
    public partial class contact_queue
    {
        public int contact_queue_id { get; set; }
        public int case_id { get; set; }
        public int contact_type_id { get; set; }
        public int status_type_id { get; set; }
        public string contact_text { get; set; }
        public string insert_user { get; set; }
        public System.DateTime insert_date { get; set; }
        public int status { get; set; }
    }
}
