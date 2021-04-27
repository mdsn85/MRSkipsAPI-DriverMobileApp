using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSkipsAPI.Models
{

    public enum collectionfrequencyList {Fixed , Call_Basis, Daily, Alternative};

    //QTY balance  sum of qty balance of linked lpo 
    // lpo consumed first in first out
    //qty consumed  
    public class Contract
    {
        public int ContractId { get; set; }

        public int ContractCode { get; set; }


        [Display(Name = "Contract Code")]
        public String  Code { get; set; }

        [Display(Name = "Final document for customer?")]
        public QuotationDocList? docs { get; set; }
        [Display(Name = "Document to be attached in invoice?")]
        public QuotationAttachList? attachment { get; set; }


        public bool? ISLPOAvailable { get; set; }
    
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

        [Display(Name = "Contract Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ContractDate { get; set; }

        [Display(Name = "Contract End Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Valid1 { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LastStatusDate { get; set; }
        [Display(Name = "Who Last Change Stataus")]
        public String UserLastStatus { get; set; }
        [Required]
        [Display(Name = "Contact Person")]
        public String Attention { get; set; }


       // [Required(ErrorMessage = "You must provide a phone number in formate xx-xxxxxxx")]
        [Display(Name = "LandLine Phone")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0x-xxxxxxx")]
        public String TelNo { get; set; }


        [Display(Name = "Email Address")]
        public String EmailID { get; set; }


       // [Required(ErrorMessage = "You must provide a Mobile number in formate xxx-xxxxxxx")]
        [Display(Name = "Mobile No")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{7})$", ErrorMessage = "Not a valid phone number in formate 0xx-xxxxxxx")]

        public string MobileNo { get; set; }

        [Display(Name = "Fax No")]
        public string FaxNo { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Skip Location")]
        public String SkipLocation { get; set; }


        [Display(Name = "Area")]
        public int? AreaId { get; set; }
        public virtual Area Area { get; set; }


        [Display(Name = "Quotation")]
        public int? QuotationId { get; set; }
        public virtual Quotation Quotation { get; set; }

        [Display(Name = "Quotation Ref")]
        public String QuotationRef { get; set; }

        [Display(Name = "Quotation Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? QuotationDate { get; set; }

        [Display(Name = "Print Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PrintDate { get; set; }

        //lpo details
        [Display(Name = "Collection Frequency")]
        public collectionfrequencyList? collectionfrequencyGeneral { get; set; }

        [Display(Name = "LPO Ref No.")]
        public String LPORef { get; set; }

        [Display(Name = "LPO Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LPODate { get; set; }

        [Display(Name = "LPO Expiry")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? LPOExpiry { get; set; }
        

        [Display(Name = "LPO Quantity")]
        public int? LPOQty { get; set; }

        [Display(Name = "LPO Quantity")]
        public int? LPOQtyBalance { get; set; }
        /// 

        [Display(Name = "Balance Qty")]
        public int? BalanceQty { get; set; }//(Quantity Base)

        [Display(Name = "Balance Qty On Availed Trip")]
        public int? BalanceQtyOnAvailedTrip { get; set; }//(Quantity Base)

        [Display(Name = "Waste Type")]
        public int WasteTypeId { get; set; }
        public virtual WasteType WasteTypes { get; set; }

        [Display(Name = "Waste Description")]
        public String WasteDescription { get; set; }

        [Display(Name = "Truck Type")]
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


        //mrskip
        //deliver +
        //pullout -
        //client skip
        //NoOfSkips=SkipOnSite
        [Display(Name = "No. Skips on Site")]
        public int SkipOnSite { get; set; }

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
        [Display(Name = "Security Deposit Amount (CDC)")]
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

        [Display(Name = "Approval Date")]
        public DateTime? ApprovalDate { get; set; }
        //public virtual ICollection<ContractFile> ContractFiles { get; set; }


        [Display(Name = "Tally Name")]
        public string TallyName { get; set; }

        [Display(Name = "Tally Code")]
        public string TallyCode { get; set; }

        
        [Display(Name = "Restrict Sch.")]
        public bool RestrictSch { get; set; }

        public int? OrginalId { get; set; }

        public int? DocumentId { get; set; }

        public int  SalesManId { get; set; }
        public virtual SalesMan SalesMan { get; set; }

        [Display(Name = "Contract Status")]
        public int ContractStatusId { get; set; }//(active, expired, terminated, suspend)
        public virtual ContractStatus ContractStatuses { get; set; }


        [Display(Name = "Nature Of Business")]
        public int? NatureOfBusinessId { get; set; }//(active, expired, terminated, suspend)
        public virtual NatureOfBusiness NatureOfBusinesses { get; set; }

        [Display(Name = "Status Reason")]
        public String StatusReason { get; set; }


        [Display(Name = "Service Status Reason")]
        public String StatusServiceReason { get; set; }
        // public String StatusReason { get; set; }

        public int? RouteId { get; set; }
        public virtual Route Route { get; set; }

        [Display(Name = "Service Status")]
        public int ContractServiceStatusId { get; set; }
        public virtual ContractServiceStatus ContractServiceStatus { get; set; }

        //public virtual Schedule Schedule { get; set; }

        [Display(Name = "Schedule")]
        public int? Schedule1Id { get; set; }
        public virtual Schedule1 Schedule1 { get; set; }

        public virtual ICollection<EnrollmentContractSalesman> EnrollmentContractSalesmans { get; set; }

        public virtual ICollection<CustomerFile> CustomerFiles { get; set; }

        public virtual ICollection<CollectionDay> CollectionDays { get; set; }
        public virtual ICollection<CollectionDayMonthly> CollectionDayMonthlys { get; set; }
        


        public virtual ICollection<CollectionDate> CollectionDates { get; set; }
        public virtual ICollection<CollectionCanceledDate> CollectionCanceledDates { get; set; }
        public virtual ICollection<CallBased> CallBaseds { get; set; }

        public virtual ICollection<DoSheet> DoSheets { get; set; }

        public virtual ICollection<ContractSkip> ContractSkips { get; set; }

        public virtual ICollection<SecurityDeposit> SecurityDeposits { get; set; }

        public virtual ICollection<AnnualPaymentTerm> AnnualPaymentTerms { get; set; }

        public virtual ICollection<LPO> LPOs { get; set; }

        public virtual ICollection<CdcReceipt> CdcReceipts { get; set; }

        public virtual ICollection<ContractFile> ContractFiles { get; set; }


        public virtual ICollection<TripsSigner> TripsSigners { get; set; }
        //public int RouteId { get; set; }
        //public virtual Route Route { get; set; }


        [Display(Name = "Create Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Who Created")]
        public String  UserCreate { get; set; }

        [Display(Name = "Last Update Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Who Last Update")]
        public String UserLastUpdate { get; set; }


        [Display(Name = "Who Last Update Service Status")]
        public String UserServiceLastStatus { get; set; }

        [Display(Name = "Date Update Service Status")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:dd}", ApplyFormatInEditMode = true)]
        public DateTime? ServiceLastStatusDate { get; set; }



        public int? Sequense { get; set; }

        public virtual ICollection<TermsAndCondition> TermsAndConditions { get; set; }

        public virtual ICollection<RecycleSource> RecycleSources { get; set; }
        public virtual ICollection<RecycleType> RecycleTypes { get; set; }
        public string RecycleRemarks { get; set; }
        public bool isLock { get; set; }

        [Display(Name = "Stamp Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? StampDate { get; set; }

        [Display(Name = "Extra Emails")]
        public string ExtraEmail { get; set; }
    }
}