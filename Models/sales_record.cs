//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PcHut.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sales_record
    {
        public int sales_record_id { get; set; }
        public int user_id { get; set; }
        public System.DateTime date { get; set; }
        public int product_id { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}