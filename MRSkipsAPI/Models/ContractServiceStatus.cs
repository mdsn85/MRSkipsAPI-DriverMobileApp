using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractServiceStatus
    {
        public int ContractServiceStatusId { get; set; }

        [Display(Name = "Service Status")]
        public String Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}