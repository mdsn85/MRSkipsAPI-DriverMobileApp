using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Unit_Product
    {

        public int Unit_ProductId { get; set; }

        [Display(Name = "Unit")]
        public String Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}