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
    
    public partial class view_case_x_debtor_full
    {
        public int case_id { get; set; }
        public Nullable<int> CasePackage_id { get; set; }
        public Nullable<int> Contract_id { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> debtor_id { get; set; }
        public Nullable<int> debtor_category_id { get; set; }
        public Nullable<int> guarantor_id { get; set; }
        public Nullable<long> ref_number { get; set; }
        public string client_ref_number { get; set; }
        public string payment_var_symbol { get; set; }
        public string payment_specific_symbol { get; set; }
        public Nullable<int> bank_account_id { get; set; }
        public Nullable<int> operator1_id { get; set; }
        public Nullable<int> operator2_id { get; set; }
        public Nullable<int> operator_group_id { get; set; }
        public Nullable<decimal> administrative_assessment { get; set; }
        public Nullable<byte> invoice { get; set; }
        public Nullable<int> date_issued { get; set; }
        public Nullable<int> due_date { get; set; }
        public Nullable<byte> currency_id { get; set; }
        public Nullable<decimal> original_exchange_rate { get; set; }
        public string original_capital { get; set; }
        public Nullable<decimal> original_capital_czk { get; set; }
        public Nullable<decimal> actual_capital { get; set; }
        public Nullable<decimal> delay_charge_to_date_of_delivery { get; set; }
        public Nullable<decimal> delay_charge_actual { get; set; }
        public string case_text { get; set; }
        public string description { get; set; }
        public Nullable<byte> case_statute_id { get; set; }
        public string case_statute_text { get; set; }
        public string department { get; set; }
        public Nullable<byte> department_id { get; set; }
        public Nullable<System.DateTime> mba_delivery_date { get; set; }
    }
}
