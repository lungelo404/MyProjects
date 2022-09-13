using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreAppWeb.Models
{
    public class Shippingdetails
    {
        public int ShippingDetails { get; set; }
        [Required]
        public Nullable<int> CustomerId { get; set; }
        [Required]
        public string addressName { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string statename { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public Nullable<int> OrderId { get; set; }
        [Required]
        public Nullable<decimal> AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }

    }
}