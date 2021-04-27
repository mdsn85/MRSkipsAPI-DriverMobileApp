using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class OwnerShipOfSkip
    {
        public int OwnerShipOfSkipId { get; set; }

        [Display(Name = "OwnerShip Of Skip")]
        public string Name { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}