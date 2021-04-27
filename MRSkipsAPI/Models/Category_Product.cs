using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Category_Product
    {
        public int Category_ProductId { get; set; }

        [Display(Name = "Category")]
        public String Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }

    }
}