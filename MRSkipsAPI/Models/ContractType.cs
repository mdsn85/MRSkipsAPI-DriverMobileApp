using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ContractType
    {
        public int ContractTypeId { get; set; }

        [Display(Name = "SERVICE TYPE")]
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}