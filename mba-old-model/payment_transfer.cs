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
    
    public partial class payment_transfer
    {
        public int payment_transfer_id { get; set; }
        public Nullable<byte> payment_transfer_reason_id { get; set; }
        public string payment_transfer_description { get; set; }
        public Nullable<int> loosing_case_id { get; set; }
        public Nullable<int> loosing_bank_statement_id { get; set; }
        public Nullable<int> loosing_bank_statement_breakdown_id { get; set; }
        public Nullable<int> loosing_bank_statement_breakdown_item_id { get; set; }
        public Nullable<int> loosing_bank_statement_breakdown_item_breakdown_id { get; set; }
        public Nullable<int> loosing_payment_id { get; set; }
        public Nullable<int> new_case_id { get; set; }
        public Nullable<int> new_bank_statement_id { get; set; }
        public Nullable<int> new_bank_statement_breakdown_id { get; set; }
        public Nullable<int> new_bank_statement_breakdown_item_id { get; set; }
        public Nullable<int> new_bank_statement_breakdown_item_breakdown_id { get; set; }
        public Nullable<int> new_payment_id { get; set; }
        public string capital { get; set; }
        public string delay_charge { get; set; }
        public string administrative_assessment { get; set; }
        public string payed_plus_money { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<byte> Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
    }
}
