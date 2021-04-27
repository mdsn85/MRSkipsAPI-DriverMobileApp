using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerCaller
    {
        public int CustomerCallerId { get; set; }
        [Display(Name = "Caller Name")]
        public String CallerName { get; set; }

        [Display(Name = "Tel. Number")]
        public String CallerNymber { get; set; }

        [Display(Name = "Email")]
        public String  Email { get; set; }

        [Display(Name = "Location")]
        public String location { get; set; }

        public virtual Customer Customer { get; set; }
        [Display(Name = "Company Name")]
        public int? CustomerId { get; set; }
    }
}