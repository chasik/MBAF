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
    
    public partial class PxT
    {
        public int PxT_id { get; set; }
        public int Persons_id { get; set; }
        public int Telecom_id { get; set; }
        public Nullable<short> Type { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<byte> Source { get; set; }
        public string Insert_user { get; set; }
        public System.DateTime Insert_date { get; set; }
        public string Update_user { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public string Delete_user { get; set; }
        public Nullable<System.DateTime> Delete_date { get; set; }
        public byte Delete_statute { get; set; }
        public Nullable<System.DateTime> Update_date_dbo { get; set; }
        public byte priority { get; set; }
        public Nullable<int> telecom_id_old { get; set; }
        public Nullable<int> persons_id_old { get; set; }
        public Nullable<int> PxT_id_dedupl { get; set; }
        public string description { get; set; }
    
        public virtual Persons Persons { get; set; }
        public virtual Telecom Telecom { get; set; }
    }
}
