using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{
    public enum PaymentFeedBackTypes { Status,Good, Bad, Plice_Case, Doubtful_Debt, Bad_Debt,Average,Delayed,Legal_Case,Absconded };
    public class Customer
    {
        public int  CustomerId { get; set; }

        [Required]
        [Display(Name = "Customer Group")]
        public int CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroups { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }



        [Display(Name = "Industry")]
        public string Industry { get; set; }

        [Display(Name = "Nature Of Business")]
        public int? NatureOfBusinessId { get; set; }//(active, expired, terminated, suspend)
        public virtual NatureOfBusiness NatureOfBusinesses { get; set; }


        [Display(Name = "Customer Code ")]
        public int CustomerCode { get; set; }


        [Display(Name = "Trade Licence No ")]
        public string TradeLicenceNo { get; set; }
       
        [Display(Name = "TRN No")]
        [StringLength(15)]
        [MinLength(15)]
        [RegularExpression(@"^\(?([0-9]{15})$", ErrorMessage = "Only number")]
        public string TRNNo { get; set; }
        [Required]
        [Display(Name = "Office Address (H.O)")]
        public string OfficeAddressHO { get; set; }

        [Display(Name = "Contact Person")]
        public String ContactPerson { get; set; }

       // [Required(ErrorMessage = "You must provide a Mobile number in formate xxx-xxxxxxx")]
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0xx-xxxxxxx")]
        public String Mobile { get; set; }



       // [Required(ErrorMessage = "You must provide a phone number in formate xx-xxxxxxx")]
        [Display(Name = "LandLine Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0x-xxxxxxx")]

        public string CompanyTelNo { get; set; }

        [Display(Name = "Fax No")]
        public string CompanyFaxNo { get; set; }
        
        [Display(Name = "Company Email ID (admin / office Manager)")]
        [EmailAddress]
        public string CompanyEmailID { get; set; }

        [Display(Name = "Folder Location/Track")]
        public string FolederLocation { get; set; }


        public int? DocumentIdTrade { get; set; }

        public int? DocumentIdID { get; set; }
        public int? DocumentIdPass { get; set; }

      //  public int? DocumentIdVat { get; set; }

        [Display(Name = "Customer Sales Category")]
        public int CustomerSalesCategoryId { get; set; }
        public virtual CustomerSalesCategory CustomerSalesCategory { get; set; }

        [Display(Name = "Sales Person")]
        public int SalesManId { get; set; }
        public virtual SalesMan SalesMan { get; set; }

        public virtual ICollection<KYC> KYCs { get; set; }

        public virtual ICollection<CustomerFile> ClientsFiles { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<LPO> LPOs { get; set; }

        public virtual ICollection<CustomerCaller> CustomerCallers { get; set; }

        public virtual ICollection<CustomerFolderHandling> CustomerFolderHandlings { get; set; }

        public virtual ICollection<Enquery> Enqueries { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }

        public virtual ICollection<CustomerCancelation> CustomerCancelations { get; set; }

        [Display(Name = "Create Date")]
        public DateTime? CrerateDate { get; set; }

        [Display(Name = "Who Created")]
        public String UserCreate { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Who Last Update")]
        public String UserLastUpdate { get; set; }

        public bool isCancel { get; set; }


        [Display(Name = "Payment FeedBack")]
        public PaymentFeedBackTypes? PaymentFeedBack { get; set; }

        [Display(Name = "Stamp Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? StampDate { get; set; }

    }
}