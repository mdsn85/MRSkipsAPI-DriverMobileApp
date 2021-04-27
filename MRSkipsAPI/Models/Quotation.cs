using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{



    public enum QuotationStatusList { Open /*when create */, Closed  /*when create contract*/ , Rejected /*Manually*/,Client_Contract };

    public enum QuotationDocList { AMC /*when create */, LPO  /*when create contract*/ , BOTH /*Manually*/ ,ClientContract};
    public enum QuotationAttachList { LPO /*when create */, AMC  /*when create contract*/ , NONE /*Manually*/,ClientContract };
    public class Quotation
    {

        public int QuotationId { get; set; }

        public int QuotationCode { get; set; }

        [Display(Name = "Final document for customer?")]
        public QuotationDocList docs { get; set; }
        [Display(Name = "Document to be attached in invoice?")]
        public QuotationAttachList attachment { get; set; }

        [Display(Name = "Customer")]
        public String CustomerName { get; set; }
        //[Display(Name = "Customer")]
        //public String CustomerName { get; set; }


        [Display(Name = "Quotation Code")]
        public String  Code { get; set; }

        [Display(Name = "Quotation Type")]
        public int? QuotationTypeId { get; set; }
        public virtual QuotationType QuotationType { get; set; }


        [Display(Name = "Recycables Available ?")]
        public bool IsRecycables { get; set; }

        public string QuoteType { get; set; }
        
        [Display(Name = "SERVICE TYPE")]
        public int ContractTypeId { get; set; }
        public virtual ContractType ContractTypes { get; set; }

        [Display(Name = "Contract Type")]
        public int ContractDurationId { get; set; }
        public virtual ContractDuration ContractDurations { get; set; }

        [Display(Name = "OwnerShip Of Skip")]
        public int OwnerShipOfSkipId { get; set; }
        public virtual OwnerShipOfSkip OwnerShipOfSkips { get; set; }

        public virtual Customer Customer { get; set; }
        public int? CustomerId { get; set; }

        public virtual KYC KYC { get; set; }
        public int? KYCId { get; set; }

        [Display(Name = "Quotation Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime QuotationDate { get; set; }

        [Display(Name = "Quotation Validity")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public int QuotationValidityId { get; set; }
        public virtual QuotationValidity QuotationValidity { get; set; }

        [Required]
        [Display(Name = "Contact Person")]
        public String Attention { get; set; }

        [Display(Name = "LandLine Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0x-xxxxxxx")]
        public String TelNo { get; set; }

        [Display(Name = "email address")]
        public String EmailID { get; set; }

        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0xx-xxxxxxx")]
        public string MobileNo { get; set; }

        [Display(Name = "Fax No")]
        public string FaxNo { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Skip Location")]
        public String SkipLocation { get; set; }

        [Display(Name = "Area")]
        public int? AreaId { get; set; }
        public virtual Area Area { get; set; }

        //lpo details
        [Display(Name = "Collection Frequency")]
        public collectionfrequencyList? collectionfrequencyGeneral { get; set; }

        [Display(Name = "Waste Type")]
        public int WasteTypeId { get; set; }
        public virtual WasteType WasteTypes { get; set; }

        [Display(Name = "Waste Description")]
        public String WasteDescription { get; set; }

        [Display(Name = "TruckT ype")]
        public int? TruckTypeId { get; set; }
        public virtual TruckType TruckTypes { get; set; }

        [Display(Name = "Skip Type 1")]
        public int SkipTypeId { get; set; }
        public virtual SkipType SkipTypes { get; set; }
        
        [Display(Name = "Skip Type ")]
        public int? SkipType1Id { get; set; }
        public virtual SkipType1 SkipTypes1 { get; set; }

        [Required]
        [Display(Name = "Skip Size")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        [Display(Name = "Collection Frequency")]
        public int? CollectionFrequencyId { get; set; }
        public virtual  CollectionFrequency CollectionFrequency { get; set; }

        [Required]
        [Display(Name = "No. Of Skips")]
        public int NoOfSkips { get; set; }

        [Required]
        [Display(Name = "Service Charges")]
        public float ServiceCharges { get; set; }

        [Display(Name = "No of Visits Required (Per Month)")]
        public float? NoOfVisitsRequiered{ get; set; }

        [Display(Name = "No of Visits Required (Per Year)")]
        public float? NoOfVisitsRequieredYearly { get; set; }

        [Display(Name = "Free trips in a Month")]
        public float MinimumTripsRequiredPerMonth { get; set; }

        [Display(Name = "Free trips in a Year")]
        public float MinimumTripsRequiredPerYear { get; set; }

        [Display(Name = "Monthly Rental Value")]
        public float MinimumInvoiceMonthlyRental { get; set; }


        [Display(Name = "Minimum Yearly Invoice (Including 5% VAT)")]
        public float MinimumInvoiceYearlyRental { get; set; }


        //here we separated
        //DMLandfillFee
        [Required]
        [Display(Name = "DM Land fill Entry Fee: (Per Skip Collection)")]
        public float DMDisposalTippingFeeCharges { get; set; }

        //tipping fee
        [Display(Name = "DM Tipping Fee Charges (Per Skip Collection)")]
        public float? TippingFee { get; set; }

        [Required]
        [Display(Name = "Security Deposit Amount CDC")]
        public float SecurityDepositAmount { get; set; }


        [Required]
        [Display(Name = "Payment Term")]
        public int PaymentTermId { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }

        [Display(Name = "REMARK")]
        public String REMARK { get; set; }

        [Display(Name = "REMARK Internal")]
        public String REMARKInternal { get; set; }

        [Display(Name = "Is Yearly Daily Service")]
        public bool IsDailyService { get; set; }

        [Display(Name = "Is Yearly Weekly Service")]
        public bool IsYearlyWeeklyService { get; set; }

        [Display(Name = "Is Yearly Alternate Service")]
        public bool IsYearlyAlternateService { get; set; }

        [Display(Name = "Approval")]
        public bool Approved { get; set; }

        [Display(Name = "Apploval Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ApprovalDate { get; set; }
        //public virtual ICollection<ContractFile> ContractFiles { get; set; }
        
        [Display(Name = "Restrict Sch.")]
        public bool RestrictSch { get; set; }

        public int  SalesManId { get; set; }
        public virtual SalesMan SalesMan { get; set; }

        [Display(Name = "Quotation Status")]
        public int QuotationStatusId { get; set; }//(active, expired, terminated, suspend)
        public virtual QuotationStatus QuotationStatuses { get; set; }

        [Display(Name = "Last Status Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? LastStatusDate { get; set; }

        [Display(Name = "Who Last Change Stataus")]
        public String UserLastStatus { get; set; }


        public String StatusReason { get; set; }



        [Display(Name = "Nature Of Business")]
        public int? NatureOfBusinessId { get; set; }//(active, expired, terminated, suspend)
        public virtual NatureOfBusiness NatureOfBusinesses { get; set; }

 //       public virtual ICollection<EnrollmentQuotationtSalesman> EnrollmentQuotationSalesmans { get; set; }

            public virtual ICollection<QuotationStatusAudit1> QuotationStatusAudit1s { get; set; }

        public virtual ICollection<CustomerFile> CustomerFiles { get; set; }

        public virtual ICollection<SecurityDeposit> SecurityDeposits { get; set; }

        public virtual ICollection<AnnualPaymentTerm> AnnualPaymentTerms { get; set; }

        public virtual ICollection<QuotationFile> QuotationFiles { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public int? EnqueryId { get; set; }
        public virtual Enquery Enquery { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Stamp Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime?  StampDate { get; set; }

        [Display(Name = "Who Created")]
        public String  UserCreate { get; set; }

        [Display(Name = "Last Update Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Who Last Update")]
        public String UserLastUpdate { get; set; }

        public int? OrginalId { get; set; }

     
        public int? Sequense { get; set; }

        public bool isLock { get; set; }

        public virtual ICollection<TermsAndConditionQuta> TermsAndConditionQutas { get; set; }

        [Display(Name = "Opportuinty")]
        public int? LeadId { get; set; }
        public virtual Lead Lead { get; set; }
    }
}