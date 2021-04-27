using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractDuration
    {
        public int ContractDurationId { get; set; }


        [Display(Name = "Contract Type")]
        public String Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}