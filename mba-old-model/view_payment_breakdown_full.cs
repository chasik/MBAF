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
    
    public partial class view_payment_breakdown_full
    {
        public Nullable<int> payment_id { get; set; }
        public Nullable<int> invoice_id { get; set; }
        public Nullable<int> case_id { get; set; }
        public Nullable<int> bank_statement_id { get; set; }
        public Nullable<byte> payment_type_id { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public Nullable<System.DateTime> bank_statement_date { get; set; }
        public string bank_statement_number { get; set; }
        public Nullable<short> bank_id { get; set; }
        public Nullable<int> bank_account_id { get; set; }
        public string account_number { get; set; }
        public Nullable<byte> currency_id { get; set; }
        public string currency_text { get; set; }
        public Nullable<decimal> payed_capital { get; set; }
        public Nullable<decimal> original_exchange_rate { get; set; }
        public Nullable<decimal> payed_capital_czk { get; set; }
        public Nullable<decimal> payed_delay_charge { get; set; }
        public Nullable<decimal> payed_administrative_assessment { get; set; }
        public Nullable<decimal> payed_plus_money { get; set; }
        public string description { get; set; }
        public string Insert_user { get; set; }
        public Nullable<System.DateTime> Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public Nullable<byte> Delete_statute { get; set; }
        public int payment_breakdown_id { get; set; }
    }
}
