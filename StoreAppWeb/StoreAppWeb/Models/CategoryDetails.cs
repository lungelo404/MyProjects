using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAppWeb.Models
{
    public class CategoryDetails
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Requeird!!")]
        [StringLength(100, ErrorMessage = "Min Char")]
        public string CategoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }

    public class ProductDetails
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Requiredd")]
        public string ProductName { get; set; }
        public Nullable<int> CatergoryId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> isFeatured { get; set; }
        [Required]
        [Range(typeof(int), "1","500", ErrorMessage ="Invalida Qauntity")]
        public Nullable<int> Quanitity { get; set; }

        public Nullable<System.DateTime> Discription { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "200000" , ErrorMessage ="Invalid Price")]
        public Nullable<decimal> Price { get; set; }

        public SelectList Categories { get; set; }

    }
}