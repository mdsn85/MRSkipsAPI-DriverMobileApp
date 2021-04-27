using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class TripsSigner
    {
        public int TripsSignerId { get; set; }

        [MaxLength(150)]
        public String Name { get; set; }
        [MaxLength(30)]
        public String Tel { get; set; }
        [MaxLength(30)]
        public String Mobile { get; set; }

        public int ContractId { get; set; }
        public virtual Contract contract { get; set; }
    }
}