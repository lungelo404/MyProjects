using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAppWeb.Models
{
    public class ProductModelView
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CatergoryId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> isFeatured { get; set; }
        public Nullable<int> Quanitity { get; set; }
        public Nullable<System.DateTime> Discription { get; set; }
        public Nullable<decimal> Price { get; set; }

        public ProductModelView()
        {
            List<ProductModelView> products = new List<ProductModelView>();
        }
      
    }
}