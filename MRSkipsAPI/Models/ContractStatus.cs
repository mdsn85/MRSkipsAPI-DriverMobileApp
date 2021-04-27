using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    ////public enum StatusName { Active, Hold,Canceled,Under_Discussion, Terminated, Expired , Under_Renewal}
    public class ContractStatus
    {
        public int ContractStatusId { get; set; }

        [Display(Name = "Contract Status")]
        public String Name { get; set; }

        public int order1 { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}