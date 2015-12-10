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
    
    public partial class view_invoice
    {
        public int invoice_id { get; set; }
        public Nullable<int> case_id { get; set; }
        public Nullable<int> CasePackage_id { get; set; }
        public Nullable<int> Contract_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public string invoice_name { get; set; }
        public string invoice_number { get; set; }
        public Nullable<int> date_issued { get; set; }
        public Nullable<int> due_date { get; set; }
        public Nullable<byte> currency_id { get; set; }
        public Nullable<decimal> original_exchange_rate { get; set; }
        public Nullable<decimal> original_capital { get; set; }
        public Nullable<decimal> original_capital_czk { get; set; }
        public Nullable<decimal> actual_capital { get; set; }
        public Nullable<decimal> delay_charge_to_date_of_delivery { get; set; }
        public Nullable<decimal> delay_charge { get; set; }
        public Nullable<decimal> delay_charge_actual { get; set; }
        public string invoice_text { get; set; }
        public string description { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public byte invoice_item_type_id { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    }
}
