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
    
    public partial class sms_templates
    {
        public int sms_templates_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public string sms_templates_name { get; set; }
        public Nullable<byte> sms_templates_language { get; set; }
        public string sms_templates_text { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public int Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public Nullable<byte> sms_template_type_id { get; set; }
        public Nullable<int> eqvId { get; set; }
    }
}
