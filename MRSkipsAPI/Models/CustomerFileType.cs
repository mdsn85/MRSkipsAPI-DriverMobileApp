using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerFileType
    {
        public int CustomerFileTypeId { get; set; }
        [Display(Name = "File Type")]
        public String Name { get; set; }

        public virtual ICollection<CustomerFile> CustomerFiles { get; set; }
    }
}