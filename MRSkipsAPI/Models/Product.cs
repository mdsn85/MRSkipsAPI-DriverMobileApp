using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
  

        [Display(Name = "Product Key")]
        public String ProductKey { get; set; }

        [Display(Name = "Skip Size")]
        public String Name { get; set; }

        public int Category_ProductId { get; set; }
        public virtual Category_Product Category_Products { get; set; }

        public int Unit_ProductId { get; set; }
        public virtual Unit_Product Unit_Products { get; set; }

        public int Type_ProductId { get; set; }
        public virtual Type_Product Type_Products { get; set; }

        [Display(Name = "TruckT type")]
        public int? TruckTypeId { get; set; }


        [Display(Name = "DM Landfill entry Fee")]
        public float? DMLandfillFee { get; set; }

        [Display(Name = "DM Tipping Fee Charges")]
        public float? TippingFee { get; set; }

        [Display(Name = "DM Tipping Fee Charges NextYear")]
        public float? TippingFeeNext { get; set; }

        [Display(Name = "price of Cat 1")]
        public float? PriceCat1 { get; set; }

        [Display(Name = "price of Cat 1 - Client Skip")]
        public float? PriceCat1Client { get; set; }
        
        [Display(Name = "Max Qty Cat 1")]
        public float? MaxQtyCat1 { get; set; }

        [Display(Name = "price of Cat 2")]
        public float? PriceCat2 { get; set; }

        [Display(Name = "price of Cat 2 - Client Skip")]
        public float? PriceCat2Client { get; set; }

        [Display(Name = "Max Qty Cat 2")]
        public float? MaxQtyCat2 { get; set; }

        [Display(Name = "price of Cat 3")]
        public float? PriceCat3 { get; set; }

        [Display(Name = "price of Cat 3 - Client Skip")]
        public float? PriceCat3Client { get; set; }

        [Display(Name = "Max Qty Cat 3")]
        public float? MaxQtyCat3 { get; set; }

        [Display(Name = "price of Cat 4")]
        public float? PriceCat4 { get; set; }

        [Display(Name = "price of Cat 4 - Client Skip")]
        public float? PriceCat4Client { get; set; }

        [Display(Name = "Max Qty Cat 4")]
        public float? MaxQtyCat4 { get; set; }

        public virtual TruckType TruckTypes { get; set; }

        public virtual ICollection<TripSheetDaetails> TripSheetDaetails { get; set; }

        public virtual ICollection<LPO> LPOs { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<EnqueryProduct> EnqueryProducts { get; set; }

    }
}