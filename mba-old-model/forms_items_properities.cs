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
    
    public partial class forms_items_properities
    {
        public int forms_items_properities_id { get; set; }
        public Nullable<int> forms_items_id { get; set; }
        public Nullable<int> forms_parts_id { get; set; }
        public Nullable<int> forms_events_id { get; set; }
        public Nullable<int> forms_list_id { get; set; }
        public string properity_name { get; set; }
        public string properity_values { get; set; }
        public string properity_data_type { get; set; }
        public Nullable<int> properity_data_type_size { get; set; }
    
        public virtual forms_events forms_events { get; set; }
        public virtual forms_items forms_items { get; set; }
        public virtual forms_list forms_list { get; set; }
        public virtual forms_parts forms_parts { get; set; }
    }
}
