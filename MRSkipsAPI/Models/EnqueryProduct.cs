using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class EnqueryProduct
    {
        public int EnqueryId { get; set; }

        public virtual Enquery Enquery { get; set; }

        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Skip Size")]
        public String SkipSize { get; set; }

        [Display(Name = "Bin Type")]
        public int? SkipType1Id { get; set; }
        public virtual SkipType1 SkipType1s { get; set; }

        [Display(Name = "Waste Type")]
        public int WasteTypeId { get; set; }
        public virtual WasteType WasteTypes { get; set; }

        [Display(Name = "Collection Frequency")]
        public int NoOfSkips { get; set; }

        [Display(Name = "Collection Frequency")]
        public int? CollectionFrequencyId { get; set; }
        public virtual CollectionFrequency CollectionFrequency { get; set; }

        [Display(Name = "Current Price")]
        public double charges { get; set; }

        public String Description { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vendor Expiry Date")]
        public DateTime? VendorExpiryDate { get; set; }

    }
}

