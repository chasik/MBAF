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
    
    public partial class view_provision
    {
        public int Provision_id { get; set; }
        public Nullable<int> Provision_package_id { get; set; }
        public Nullable<short> Provision_type_id { get; set; }
        public Nullable<short> Provision_item_id { get; set; }
        public Nullable<int> Provision_settings_id { get; set; }
        public Nullable<int> Provision_main_id { get; set; }
        public Nullable<int> payment_reported_id { get; set; }
        public Nullable<int> credit_note_reported_id { get; set; }
        public Nullable<int> contact_reported_id { get; set; }
        public Nullable<int> Provision_client_id { get; set; }
        public Nullable<int> Provision_contract_id { get; set; }
        public Nullable<int> Provision_CasePackage_id { get; set; }
        public Nullable<int> Provision_Case_id { get; set; }
        public Nullable<int> Provision_invoice_id { get; set; }
        public decimal provision { get; set; }
        public string Provision_invoice_to_client { get; set; }
        public string Provision_invoice_text { get; set; }
        public Nullable<short> Provision_users_id { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    }
}
