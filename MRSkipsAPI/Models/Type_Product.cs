using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Type_Product
    {
        public int Type_ProductId { get; set; }

        [Display(Name = "Type")]
        public String Name { get; set; }


        public virtual ICollection<Product> Product { get; set; }
    }

}