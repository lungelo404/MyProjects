//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StopAppAPI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShippingDetail
    {
        public int ShippingDetails { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string addressName { get; set; }
        public string city { get; set; }
        public string statename { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }
    
        public virtual Custemer Custemer { get; set; }
    }
}
