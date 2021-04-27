using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class CustomerFolderHandling
    {
        public int CustomerFolderHandlingId { get; set; }

        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Employee")]
        public string  Username { get; set; }

        [Display(Name = "Given To")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Display(Name = "Handover Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TakenDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnDate { get; set; }

        public String Remarks { get; set; }

    }
}