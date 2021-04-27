using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class ShiftHelperLink
    {

        public int ShiftId { get; set; }
        [Display(Name = "Helper Name")]
        public int HelperId { get; set; }

        //-----------------------------
        //Relationships

        public Shift Shift { get; set; }
        public Helper Helper { get; set; }
    }
}