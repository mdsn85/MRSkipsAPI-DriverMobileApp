namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publish : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ActualDuties",
            //    c => new
            //        {
            //            ActualDutyId = c.Int(nullable: false, identity: true),
            //            RouteId = c.Int(nullable: false),
            //            DriverId = c.Int(nullable: false),
            //            VehicleId = c.Int(nullable: false),
            //            ActualDutyDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ActualDutyId)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
            //    .Index(t => t.RouteId)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId);
            
            //CreateTable(
            //    "dbo.Drivers",
            //    c => new
            //        {
            //            DriverId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Mobile = c.String(),
            //            EmployeeId = c.Int(nullable: false),
            //            AppUserName = c.String(),
            //            AppPassWard = c.String(),
            //        })
            //    .PrimaryKey(t => t.DriverId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
            //    .Index(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.CdcReceipts",
            //    c => new
            //        {
            //            CdcReceiptId = c.Int(nullable: false, identity: true),
            //            ReceiptDate = c.DateTime(nullable: false),
            //            ServiceCharges = c.Single(nullable: false),
            //            AmountCollected = c.Single(nullable: false),
            //            DriverId = c.Int(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CdcReceiptId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.Contracts",
            //    c => new
            //        {
            //            ContractId = c.Int(nullable: false, identity: true),
            //            ContractCode = c.Int(nullable: false),
            //            Code = c.String(),
            //            docs = c.Int(),
            //            attachment = c.Int(),
            //            ISLPOAvailable = c.Boolean(),
            //            IsRecycables = c.Boolean(nullable: false),
            //            QuoteType = c.String(),
            //            ContractTypeId = c.Int(nullable: false),
            //            ContractDurationId = c.Int(nullable: false),
            //            OwnerShipOfSkipId = c.Int(nullable: false),
            //            CustomerId = c.Int(),
            //            KYCId = c.Int(),
            //            ContractDate = c.DateTime(nullable: false),
            //            Valid1 = c.DateTime(nullable: false),
            //            LastStatusDate = c.DateTime(nullable: false),
            //            UserLastStatus = c.String(),
            //            Attention = c.String(nullable: false),
            //            TelNo = c.String(),
            //            EmailID = c.String(),
            //            MobileNo = c.String(),
            //            FaxNo = c.String(),
            //            ProjectName = c.String(),
            //            SkipLocation = c.String(nullable: false),
            //            AreaId = c.Int(),
            //            QuotationId = c.Int(),
            //            QuotationRef = c.String(),
            //            QuotationDate = c.DateTime(),
            //            PrintDate = c.DateTime(),
            //            collectionfrequencyGeneral = c.Int(),
            //            LPORef = c.String(),
            //            LPODate = c.DateTime(),
            //            LPOExpiry = c.DateTime(),
            //            LPOQty = c.Int(),
            //            LPOQtyBalance = c.Int(),
            //            BalanceQty = c.Int(),
            //            BalanceQtyOnAvailedTrip = c.Int(),
            //            WasteTypeId = c.Int(nullable: false),
            //            WasteDescription = c.String(),
            //            TruckTypeId = c.Int(),
            //            SkipTypeId = c.Int(nullable: false),
            //            SkipType1Id = c.Int(),
            //            ProductId = c.Int(nullable: false),
            //            CollectionFrequencyId = c.Int(),
            //            NoOfSkips = c.Int(nullable: false),
            //            SkipOnSite = c.Int(nullable: false),
            //            ServiceCharges = c.Single(nullable: false),
            //            NoOfVisitsRequiered = c.Single(),
            //            NoOfVisitsRequieredYearly = c.Single(),
            //            MinimumTripsRequiredPerMonth = c.Single(nullable: false),
            //            MinimumTripsRequiredPerYear = c.Single(nullable: false),
            //            MinimumInvoiceMonthlyRental = c.Single(nullable: false),
            //            MinimumInvoiceYearlyRental = c.Single(nullable: false),
            //            DMDisposalTippingFeeCharges = c.Single(nullable: false),
            //            TippingFee = c.Single(),
            //            SecurityDepositAmount = c.Single(nullable: false),
            //            PaymentTermId = c.Int(nullable: false),
            //            REMARK = c.String(),
            //            REMARKInternal = c.String(),
            //            IsDailyService = c.Boolean(nullable: false),
            //            IsYearlyWeeklyService = c.Boolean(nullable: false),
            //            IsYearlyAlternateService = c.Boolean(nullable: false),
            //            Approved = c.Boolean(nullable: false),
            //            ApprovalDate = c.DateTime(),
            //            TallyName = c.String(),
            //            TallyCode = c.String(),
            //            RestrictSch = c.Boolean(nullable: false),
            //            OrginalId = c.Int(),
            //            DocumentId = c.Int(),
            //            SalesManId = c.Int(nullable: false),
            //            ContractStatusId = c.Int(nullable: false),
            //            NatureOfBusinessId = c.Int(),
            //            StatusReason = c.String(),
            //            StatusServiceReason = c.String(),
            //            RouteId = c.Int(),
            //            ContractServiceStatusId = c.Int(nullable: false),
            //            Schedule1Id = c.Int(),
            //            CreateDate = c.DateTime(),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            UserServiceLastStatus = c.String(),
            //            ServiceLastStatusDate = c.DateTime(),
            //            Sequense = c.Int(),
            //            RecycleRemarks = c.String(),
            //            isLock = c.Boolean(nullable: false),
            //            StampDate = c.DateTime(),
            //            ExtraEmail = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractId)
            //    .ForeignKey("dbo.Areas", t => t.AreaId)
            //    .ForeignKey("dbo.KYCs", t => t.KYCId)
            //    .ForeignKey("dbo.Routes", t => t.RouteId)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.CollectionFrequencies", t => t.CollectionFrequencyId)
            //    .ForeignKey("dbo.SkipType1", t => t.SkipType1Id)
            //    .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
            //    .ForeignKey("dbo.ContractDurations", t => t.ContractDurationId, cascadeDelete: true)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId)
            //    .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId)
            //    .ForeignKey("dbo.OwnerShipOfSkips", t => t.OwnerShipOfSkipId, cascadeDelete: true)
            //    .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId, cascadeDelete: true)
            //    .ForeignKey("dbo.SkipTypes", t => t.SkipTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.ContractServiceStatus", t => t.ContractServiceStatusId, cascadeDelete: true)
            //    .ForeignKey("dbo.ContractStatus", t => t.ContractStatusId, cascadeDelete: true)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .Index(t => t.ContractTypeId)
            //    .Index(t => t.ContractDurationId)
            //    .Index(t => t.OwnerShipOfSkipId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.KYCId)
            //    .Index(t => t.AreaId)
            //    .Index(t => t.QuotationId)
            //    .Index(t => t.WasteTypeId)
            //    .Index(t => t.TruckTypeId)
            //    .Index(t => t.SkipTypeId)
            //    .Index(t => t.SkipType1Id)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.CollectionFrequencyId)
            //    .Index(t => t.PaymentTermId)
            //    .Index(t => t.SalesManId)
            //    .Index(t => t.ContractStatusId)
            //    .Index(t => t.NatureOfBusinessId)
            //    .Index(t => t.RouteId)
            //    .Index(t => t.ContractServiceStatusId);
            
            //CreateTable(
            //    "dbo.AnnualPaymentTerms",
            //    c => new
            //        {
            //            AnnualPaymentTermId = c.Int(nullable: false, identity: true),
            //            AmountPaid = c.Double(nullable: false),
            //            ModeOfPaymentName = c.Int(nullable: false),
            //            DateOfPayment = c.DateTime(nullable: false),
            //            Balance = c.Double(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //            Quotation_QuotationId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.AnnualPaymentTermId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.Quotations", t => t.Quotation_QuotationId)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.Quotation_QuotationId);
            
            //CreateTable(
            //    "dbo.Areas",
            //    c => new
            //        {
            //            AreaId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.AreaId);
            
            //CreateTable(
            //    "dbo.Enqueries",
            //    c => new
            //        {
            //            EnqueryId = c.Int(nullable: false, identity: true),
            //            Sequense = c.Int(nullable: false),
            //            Code = c.String(),
            //            EnqueryStatus = c.Int(),
            //            EnqueryStatusId = c.Int(),
            //            StatusReason = c.String(),
            //            NextDateFollowup = c.DateTime(nullable: false),
            //            IsNewCustomer = c.Boolean(nullable: false),
            //            NoticePeriod = c.Int(nullable: false),
            //            ExpectedClosureDate = c.DateTime(),
            //            CustomerId = c.Int(),
            //            CustomerName = c.String(nullable: false),
            //            ContactPerson = c.String(nullable: false),
            //            Designation = c.String(),
            //            TelephoneNo = c.String(nullable: false),
            //            MobileNo = c.String(nullable: false),
            //            FaxNo = c.String(),
            //            EmailId = c.String(nullable: false),
            //            HowUCome = c.String(),
            //            RecyclingRemarks = c.String(),
            //            ProjectName = c.String(nullable: false),
            //            NatureOfBusinessId = c.Int(nullable: false),
            //            WasteTypeId = c.Int(nullable: false),
            //            CompetitorId = c.Int(nullable: false),
            //            LastMeeting = c.DateTime(),
            //            NextMeeting = c.DateTime(),
            //            IsNewLocation = c.Boolean(nullable: false),
            //            AreaId = c.Int(),
            //            Location = c.String(),
            //            SalesManId = c.Int(nullable: false),
            //            PaymentTermId = c.Int(),
            //            Description = c.String(),
            //            IsRecycables = c.Boolean(nullable: false),
            //            FOC = c.Boolean(nullable: false),
            //            CreateDate = c.DateTime(),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            LastStatusDate = c.DateTime(),
            //            UserLastStatus = c.String(),
            //            StampDate = c.DateTime(),
            //            SkipType1_SkipType1Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.EnqueryId)
            //    .ForeignKey("dbo.Areas", t => t.AreaId)
            //    .ForeignKey("dbo.Competitors", t => t.CompetitorId, cascadeDelete: true)
            //    .ForeignKey("dbo.SkipType1", t => t.SkipType1_SkipType1Id)
            //    .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId, cascadeDelete: true)
            //    .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.EnqueryStatus", t => t.EnqueryStatusId)
            //    .Index(t => t.EnqueryStatusId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.NatureOfBusinessId)
            //    .Index(t => t.WasteTypeId)
            //    .Index(t => t.CompetitorId)
            //    .Index(t => t.AreaId)
            //    .Index(t => t.SalesManId)
            //    .Index(t => t.PaymentTermId)
            //    .Index(t => t.SkipType1_SkipType1Id);
            
            //CreateTable(
            //    "dbo.Competitors",
            //    c => new
            //        {
            //            CompetitorId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.CompetitorId);
            
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            CustomerId = c.Int(nullable: false, identity: true),
            //            CustomerGroupId = c.Int(nullable: false),
            //            CompanyName = c.String(),
            //            Industry = c.String(),
            //            NatureOfBusinessId = c.Int(),
            //            CustomerCode = c.Int(nullable: false),
            //            TradeLicenceNo = c.String(),
            //            TRNNo = c.String(maxLength: 15),
            //            OfficeAddressHO = c.String(nullable: false),
            //            ContactPerson = c.String(),
            //            Mobile = c.String(),
            //            CompanyTelNo = c.String(),
            //            CompanyFaxNo = c.String(),
            //            CompanyEmailID = c.String(),
            //            FolederLocation = c.String(),
            //            DocumentIdTrade = c.Int(),
            //            DocumentIdID = c.Int(),
            //            DocumentIdPass = c.Int(),
            //            CustomerSalesCategoryId = c.Int(nullable: false),
            //            SalesManId = c.Int(nullable: false),
            //            CrerateDate = c.DateTime(),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            isCancel = c.Boolean(nullable: false),
            //            PaymentFeedBack = c.Int(),
            //            StampDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.CustomerId)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId, cascadeDelete: true)
            //    .ForeignKey("dbo.CustomerSalesCategories", t => t.CustomerSalesCategoryId, cascadeDelete: true)
            //    .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId)
            //    .Index(t => t.CustomerGroupId)
            //    .Index(t => t.NatureOfBusinessId)
            //    .Index(t => t.CustomerSalesCategoryId)
            //    .Index(t => t.SalesManId);
            
            //CreateTable(
            //    "dbo.CustomerFiles",
            //    c => new
            //        {
            //            CustomerFileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //            ValidUntil = c.DateTime(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CustomerId = c.Int(),
            //            KYCId = c.Int(),
            //            ContractId = c.Int(),
            //            QuotationId = c.Int(),
            //            LPOId = c.Int(),
            //            CustomerFileTypeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CustomerFileId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.CustomerFileTypes", t => t.CustomerFileTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.KYCs", t => t.KYCId)
            //    .ForeignKey("dbo.LPOes", t => t.LPOId)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.KYCId)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.QuotationId)
            //    .Index(t => t.LPOId)
            //    .Index(t => t.CustomerFileTypeId);
            
            //CreateTable(
            //    "dbo.CustomerFileTypes",
            //    c => new
            //        {
            //            CustomerFileTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.CustomerFileTypeId);
            
            //CreateTable(
            //    "dbo.KYCs",
            //    c => new
            //        {
            //            KYCId = c.Int(nullable: false, identity: true),
            //            CustomerId = c.Int(nullable: false),
            //            SalesManId = c.Int(nullable: false),
            //            KYCCode = c.String(),
            //            OwnerName = c.String(),
            //            OwnerContact = c.String(),
            //            OwnerEmail = c.String(),
            //            MdName = c.String(),
            //            MdContact = c.String(),
            //            MdEmail = c.String(),
            //            ClientSupplier1 = c.String(),
            //            ClientSupplier2 = c.String(),
            //            ContactOfficeName = c.String(),
            //            ContactOfficeDesignation = c.String(),
            //            ContactOfficeDepartment = c.String(),
            //            ContactOfficeMobileNo = c.String(),
            //            ContactOfficeTelNoExtn = c.String(),
            //            ContactOfficeFax = c.String(),
            //            ContactOfficeEmail = c.String(),
            //            ContactOfficeRemarks = c.String(),
            //            CutOffdateofinvoicesubmission = c.String(),
            //            InvoiceDeliveryThroughEmail = c.Boolean(nullable: false),
            //            InvoiceDeliveryHardcopy = c.Boolean(nullable: false),
            //            InvoiceDeliveryLocationId = c.Int(),
            //            InvoiceDeliveryAddress = c.String(),
            //            MakaniNo = c.String(),
            //            InvoiceAccountContactPerson = c.String(),
            //            InvoiceAccountContactNo = c.String(),
            //            InvoiceAccountEmail = c.String(),
            //            ModeOfPaymentId = c.Int(),
            //            PaymentAccountsPayable = c.String(),
            //            PaymentAccountMobileNo = c.String(),
            //            PaymentAccountTelNoExtn = c.String(),
            //            PaymentAccountEmail = c.String(),
            //            FinanceMangerName = c.String(),
            //            FinanceMangerContactNo = c.String(),
            //            FinanceMangerEmail = c.String(),
            //            PaymentCollectionDetails = c.String(),
            //            CollectionLocation = c.String(),
            //            CollectionContactPerson = c.String(),
            //            CollectionContactPersonDesignation = c.String(),
            //            CollectionContactNo = c.String(),
            //            PaymentCollectionDays = c.String(),
            //            PaymentCollectionTiming = c.String(),
            //            CollectionPaymentRemarks = c.String(),
            //            SiteLocation = c.String(nullable: false),
            //            ProjectName = c.String(nullable: false),
            //            SiteContactPersonNameDayShift = c.String(),
            //            SiteDayDesignation = c.String(),
            //            SiteDayEmail = c.String(),
            //            SiteDayMobileNo = c.String(),
            //            SiteContactPersonNameNightShift = c.String(),
            //            SiteNightDesignation = c.String(),
            //            SiteNightEmail = c.String(),
            //            SiteNightMobileNo = c.String(),
            //            SiteNightRemarks = c.String(),
            //            DocumentId = c.Int(),
            //            CreatedIn = c.DateTime(nullable: false),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            ModeOfPayment_ModeOfPaymentId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.KYCId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
            //    .ForeignKey("dbo.InvoiceDeliveryLocations", t => t.InvoiceDeliveryLocationId)
            //    .ForeignKey("dbo.ModeOfPayments", t => t.ModeOfPayment_ModeOfPaymentId)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.SalesManId)
            //    .Index(t => t.InvoiceDeliveryLocationId)
            //    .Index(t => t.ModeOfPayment_ModeOfPaymentId);
            
            //CreateTable(
            //    "dbo.InvoiceDeliveryLocations",
            //    c => new
            //        {
            //            InvoiceDeliveryLocationId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.InvoiceDeliveryLocationId);
            
            //CreateTable(
            //    "dbo.KycFiles",
            //    c => new
            //        {
            //            KycFileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //            ValidUntil = c.DateTime(),
            //            KYCId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.KycFileId)
            //    .ForeignKey("dbo.KYCs", t => t.KYCId)
            //    .Index(t => t.KYCId);
            
            //CreateTable(
            //    "dbo.ModeOfPayments",
            //    c => new
            //        {
            //            ModeOfPaymentId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            KYC_KYCId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ModeOfPaymentId)
            //    .ForeignKey("dbo.KYCs", t => t.KYC_KYCId)
            //    .Index(t => t.KYC_KYCId);
            
            //CreateTable(
            //    "dbo.SalesMen",
            //    c => new
            //        {
            //            SalesManId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Mobile = c.String(),
            //            Email = c.String(),
            //            AppUserName = c.String(),
            //            AppPassWard = c.String(),
            //            EmployeeId = c.Int(),
            //            SalesTeamId = c.Int(),
            //            isTeamleader = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.SalesManId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId)
            //    .ForeignKey("dbo.SalesTeams", t => t.SalesTeamId)
            //    .Index(t => t.EmployeeId)
            //    .Index(t => t.SalesTeamId);
            
            //CreateTable(
            //    "dbo.Employees",
            //    c => new
            //        {
            //            EmployeeId = c.Int(nullable: false, identity: true),
            //            Code = c.String(),
            //            Name = c.String(),
            //            EmailSignature = c.String(),
            //        })
            //    .PrimaryKey(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.CustomerFolderHandlings",
            //    c => new
            //        {
            //            CustomerFolderHandlingId = c.Int(nullable: false, identity: true),
            //            CustomerId = c.Int(nullable: false),
            //            Username = c.String(),
            //            EmployeeId = c.Int(),
            //            TakenDate = c.DateTime(nullable: false),
            //            ReturnDate = c.DateTime(),
            //            Remarks = c.String(),
            //        })
            //    .PrimaryKey(t => t.CustomerFolderHandlingId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.SalesTeams",
            //    c => new
            //        {
            //            SalesTeamId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            EmployeeId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.SalesTeamId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId)
            //    .Index(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.Shifts",
            //    c => new
            //        {
            //            ShiftId = c.Int(nullable: false, identity: true),
            //            EmployeeId = c.Int(nullable: false),
            //            ActualDutyId = c.Int(),
            //            StartShift = c.DateTime(nullable: false),
            //            EndShift = c.DateTime(nullable: false),
            //            StartKM = c.Single(),
            //            EndKM = c.Single(),
            //            TripSheetId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ShiftId)
            //    .ForeignKey("dbo.ActualDuties", t => t.ActualDutyId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
            //    .ForeignKey("dbo.TripSheets", t => t.TripSheetId, cascadeDelete: true)
            //    .Index(t => t.EmployeeId)
            //    .Index(t => t.ActualDutyId)
            //    .Index(t => t.TripSheetId);
            
            //CreateTable(
            //    "dbo.TripSheets",
            //    c => new
            //        {
            //            TripSheetId = c.Int(nullable: false, identity: true),
            //            TripsDate = c.DateTime(nullable: false),
            //            RouteId = c.Int(nullable: false),
            //            DriverId = c.Int(nullable: false),
            //            Helpers = c.String(),
            //            VehicleId = c.Int(),
            //            ActualDutyDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.TripSheetId)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId)
            //    .Index(t => t.RouteId)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId);
            
            //CreateTable(
            //    "dbo.Helpers",
            //    c => new
            //        {
            //            HelperId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Mobile = c.String(),
            //            EmployeeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.HelperId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
            //    .Index(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.Routes",
            //    c => new
            //        {
            //            RouteId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Area = c.String(),
            //            DriverId = c.Int(nullable: false),
            //            Helpers = c.String(),
            //            VehicleId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.RouteId)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId);
            
            //CreateTable(
            //    "dbo.Vehicles",
            //    c => new
            //        {
            //            VehicleId = c.Int(nullable: false, identity: true),
            //            PlateNo = c.String(),
            //            VehicleMakerId = c.Int(),
            //            TruckTypeId = c.Int(),
            //            Description = c.String(),
            //        })
            //    .PrimaryKey(t => t.VehicleId)
            //    .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
            //    .ForeignKey("dbo.VehicleMakers", t => t.VehicleMakerId)
            //    .Index(t => t.VehicleMakerId)
            //    .Index(t => t.TruckTypeId);
            
            //CreateTable(
            //    "dbo.TripSheetDaetails",
            //    c => new
            //        {
            //            TripSheetDaetailsId = c.Int(nullable: false, identity: true),
            //            TripsDate = c.DateTime(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //            DoNum = c.String(),
            //            SkipSerialNumber = c.String(),
            //            ProductId = c.Int(nullable: false),
            //            NumberOfSkips = c.Int(nullable: false),
            //            NumberOfSkipscollected = c.Int(),
            //            Timein = c.String(),
            //            Timeout = c.String(),
            //            Weight = c.String(),
            //            Remarks = c.String(),
            //            Status = c.Int(nullable: false),
            //            DriverId = c.Int(),
            //            Helpers = c.String(),
            //            VehicleId = c.Int(),
            //            ServiceTypeId = c.Int(),
            //            CallBasedId = c.Int(),
            //            TripSheetId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.TripSheetDaetailsId)
            //    .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId)
            //    .ForeignKey("dbo.CallBaseds", t => t.CallBasedId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.TripSheets", t => t.TripSheetId)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId)
            //    .Index(t => t.ServiceTypeId)
            //    .Index(t => t.CallBasedId)
            //    .Index(t => t.TripSheetId);
            
            //CreateTable(
            //    "dbo.CallBaseds",
            //    c => new
            //        {
            //            CallBasedId = c.Int(nullable: false, identity: true),
            //            Colection_Date = c.DateTime(nullable: false),
            //            NumOfSkips = c.Int(nullable: false),
            //            WasteType = c.String(),
            //            CallerName = c.String(),
            //            CallerNymber = c.String(),
            //            Email = c.String(),
            //            RequestDate = c.DateTime(nullable: false),
            //            Remarks = c.String(),
            //            isSRF = c.Boolean(nullable: false),
            //            FollowUpNo = c.Int(),
            //            FollowUpRemarks = c.String(),
            //            ManagerApproval = c.Boolean(nullable: false),
            //            AccountApproval = c.Boolean(nullable: false),
            //            Status = c.Int(nullable: false),
            //            UserId = c.String(),
            //            UserName = c.String(),
            //            ContractId = c.Int(nullable: false),
            //            ServiceTypeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CallBasedId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.ServiceTypeId);
            
            //CreateTable(
            //    "dbo.ServiceTypes",
            //    c => new
            //        {
            //            ServiceTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ServiceTypeId);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductId = c.Int(nullable: false, identity: true),
            //            ProductKey = c.String(),
            //            Name = c.String(),
            //            Category_ProductId = c.Int(nullable: false),
            //            Unit_ProductId = c.Int(nullable: false),
            //            Type_ProductId = c.Int(nullable: false),
            //            TruckTypeId = c.Int(),
            //            DMLandfillFee = c.Single(),
            //            TippingFee = c.Single(),
            //            TippingFeeNext = c.Single(),
            //            PriceCat1 = c.Single(),
            //            PriceCat1Client = c.Single(),
            //            MaxQtyCat1 = c.Single(),
            //            PriceCat2 = c.Single(),
            //            PriceCat2Client = c.Single(),
            //            MaxQtyCat2 = c.Single(),
            //            PriceCat3 = c.Single(),
            //            PriceCat3Client = c.Single(),
            //            MaxQtyCat3 = c.Single(),
            //            PriceCat4 = c.Single(),
            //            PriceCat4Client = c.Single(),
            //            MaxQtyCat4 = c.Single(),
            //        })
            //    .PrimaryKey(t => t.ProductId)
            //    .ForeignKey("dbo.Category_Product", t => t.Category_ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
            //    .ForeignKey("dbo.Type_Product", t => t.Type_ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.Unit_Product", t => t.Unit_ProductId, cascadeDelete: true)
            //    .Index(t => t.Category_ProductId)
            //    .Index(t => t.Unit_ProductId)
            //    .Index(t => t.Type_ProductId)
            //    .Index(t => t.TruckTypeId);
            
            //CreateTable(
            //    "dbo.Category_Product",
            //    c => new
            //        {
            //            Category_ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Category_ProductId);
            
            //CreateTable(
            //    "dbo.EnqueryProducts",
            //    c => new
            //        {
            //            EnqueryId = c.Int(nullable: false),
            //            ProductId = c.Int(nullable: false),
            //            SkipSize = c.String(),
            //            SkipType1Id = c.Int(),
            //            WasteTypeId = c.Int(nullable: false),
            //            NoOfSkips = c.Int(nullable: false),
            //            CollectionFrequencyId = c.Int(),
            //            charges = c.Double(nullable: false),
            //            Description = c.String(),
            //            VendorExpiryDate = c.DateTime(),
            //            Enquery_EnqueryId = c.Int(),
            //            Product_ProductId = c.Int(),
            //        })
            //    .PrimaryKey(t => new { t.EnqueryId, t.ProductId })
            //    .ForeignKey("dbo.CollectionFrequencies", t => t.CollectionFrequencyId)
            //    .ForeignKey("dbo.Enqueries", t => t.Enquery_EnqueryId)
            //    .ForeignKey("dbo.Products", t => t.Product_ProductId)
            //    .ForeignKey("dbo.SkipType1", t => t.SkipType1Id)
            //    .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.Enqueries", t => t.EnqueryId, cascadeDelete: true)
            //    .Index(t => t.EnqueryId)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.SkipType1Id)
            //    .Index(t => t.WasteTypeId)
            //    .Index(t => t.CollectionFrequencyId)
            //    .Index(t => t.Enquery_EnqueryId)
            //    .Index(t => t.Product_ProductId);
            
            //CreateTable(
            //    "dbo.CollectionFrequencies",
            //    c => new
            //        {
            //            CollectionFrequencyId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.CollectionFrequencyId);
            
            //CreateTable(
            //    "dbo.SkipType1",
            //    c => new
            //        {
            //            SkipType1Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.SkipType1Id);
            
            //CreateTable(
            //    "dbo.WasteTypes",
            //    c => new
            //        {
            //            WasteTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.WasteTypeId);
            
            //CreateTable(
            //    "dbo.LPOes",
            //    c => new
            //        {
            //            LPOId = c.Int(nullable: false, identity: true),
            //            LPONo = c.Int(nullable: false),
            //            LPORefNo = c.String(),
            //            ContractId = c.Int(),
            //            CustomerId = c.Int(),
            //            LpoTypeId = c.Int(nullable: false),
            //            LpoDate = c.DateTime(),
            //            ProductId = c.Int(nullable: false),
            //            NoOfSkips = c.Int(nullable: false),
            //            AttachedInInvoice = c.Boolean(nullable: false),
            //            LPOContactPerson = c.String(),
            //            LPOContactNumber = c.String(),
            //            LPOContactEmailID = c.String(),
            //            Remarks = c.String(),
            //            ServiceRequestedQuantity = c.Int(),
            //            ServicedActualQty = c.Int(nullable: false),
            //            BalanceQty = c.Int(nullable: false),
            //            BalanceQtyOnAvailedTrip = c.Int(nullable: false),
            //            LpoStartDate = c.DateTime(),
            //            LpoEndDate = c.DateTime(),
            //            TerminatedDate = c.DateTime(),
            //            ExtendedLPOID = c.Int(),
            //            ExtendedLPONo = c.Int(),
            //            ExtendedLPORefNo = c.String(),
            //            LpoStatusId = c.Int(nullable: false),
            //            QtyConsumed = c.Int(),
            //            SuspendReason = c.String(),
            //            SuspendDate = c.DateTime(),
            //            TerminatedReason = c.String(),
            //            FileName = c.String(),
            //            FilePath = c.String(),
            //            IsActive = c.Boolean(nullable: false),
            //            CreatedDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.LPOId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.LpoStatus", t => t.LpoStatusId, cascadeDelete: true)
            //    .ForeignKey("dbo.LpoTypes", t => t.LpoTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.LpoTypeId)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.LpoStatusId);
            
            //CreateTable(
            //    "dbo.Lpofiles",
            //    c => new
            //        {
            //            LpofileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //            ValidUntil = c.DateTime(),
            //            LPOId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.LpofileId)
            //    .ForeignKey("dbo.LPOes", t => t.LPOId)
            //    .Index(t => t.LPOId);
            
            //CreateTable(
            //    "dbo.LpoStatus",
            //    c => new
            //        {
            //            LpoStatusId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.LpoStatusId);
            
            //CreateTable(
            //    "dbo.LpoSuspends",
            //    c => new
            //        {
            //            LpoSuspendId = c.Int(nullable: false, identity: true),
            //            Reason = c.String(),
            //            SuspendDate = c.DateTime(nullable: false),
            //            LpoId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.LpoSuspendId)
            //    .ForeignKey("dbo.LPOes", t => t.LpoId, cascadeDelete: true)
            //    .Index(t => t.LpoId);
            
            //CreateTable(
            //    "dbo.LpoTypes",
            //    c => new
            //        {
            //            LpoTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.LpoTypeId);
            
            //CreateTable(
            //    "dbo.TruckTypes",
            //    c => new
            //        {
            //            TruckTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.TruckTypeId);
            
            //CreateTable(
            //    "dbo.Type_Product",
            //    c => new
            //        {
            //            Type_ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Type_ProductId);
            
            //CreateTable(
            //    "dbo.Unit_Product",
            //    c => new
            //        {
            //            Unit_ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Unit_ProductId);
            
            //CreateTable(
            //    "dbo.TripSheetDeatails_skip",
            //    c => new
            //        {
            //            TripSheetDeatails_skipId = c.Int(nullable: false, identity: true),
            //            TripSheetDaetailsId = c.Int(nullable: false),
            //            ProductId = c.Int(nullable: false),
            //            DoNum = c.String(),
            //            SkipSerialNumber = c.String(),
            //            SkipSerialNumber2 = c.String(),
            //            Weight = c.String(),
            //            Remarks = c.String(),
            //            Status = c.Int(),
            //            ReasonImg = c.String(),
            //            SignateImg = c.String(),
            //            DumbId = c.Int(),
            //            isYard = c.Boolean(nullable: false),
            //            ServiceCharges = c.Single(),
            //            Timein = c.String(),
            //            Timeout = c.String(),
            //            DumpLocationId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.TripSheetDeatails_skipId)
            //    .ForeignKey("dbo.DumpLocations", t => t.DumpLocationId)
            //    .ForeignKey("dbo.Dumbs", t => t.DumbId)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.TripSheetDaetails", t => t.TripSheetDaetailsId, cascadeDelete: true)
            //    .Index(t => t.TripSheetDaetailsId)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.DumbId)
            //    .Index(t => t.DumpLocationId);
            
            //CreateTable(
            //    "dbo.Dumbs",
            //    c => new
            //        {
            //            DumbId = c.Int(nullable: false, identity: true),
            //            DumpLocationId = c.Int(nullable: false),
            //            DumpDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DumbId)
            //    .ForeignKey("dbo.DumpLocations", t => t.DumpLocationId, cascadeDelete: true)
            //    .Index(t => t.DumpLocationId);
            
            //CreateTable(
            //    "dbo.DumpLocations",
            //    c => new
            //        {
            //            DumpLocationId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.DumpLocationId);
            
            //CreateTable(
            //    "dbo.VehicleMakers",
            //    c => new
            //        {
            //            VehicleMakerId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.VehicleMakerId);
            
            //CreateTable(
            //    "dbo.VehicleCheckLists",
            //    c => new
            //        {
            //            VehicleCheckListId = c.Int(nullable: false, identity: true),
            //            Reason = c.String(),
            //            LIGHTSINDICATORS = c.Boolean(nullable: false),
            //            ENGINEOILLEVEL = c.Boolean(nullable: false),
            //            HYDRAULICOILLEVEL = c.Boolean(nullable: false),
            //            REDIATORCOOLENTLEVEL = c.Boolean(nullable: false),
            //            WIPERMIRROR = c.Boolean(nullable: false),
            //            HYDRAULICFUNCTION = c.Boolean(nullable: false),
            //            ALLTYRES = c.Boolean(nullable: false),
            //            VEHICLECLEANLINESS = c.Boolean(nullable: false),
            //            PPEFIRSTAID = c.Boolean(nullable: false),
            //            UNIFORM = c.Boolean(nullable: false),
            //            WARNINGTRIANGLE = c.Boolean(nullable: false),
            //            TARPAULINE = c.Boolean(nullable: false),
            //            BODYDAMAGE = c.Boolean(nullable: false),
            //            SEATBELTAC = c.Boolean(nullable: false),
            //            TOOLS = c.Boolean(nullable: false),
            //            VEHICLEPAPERS = c.Boolean(nullable: false),
            //            FIREEXTINGUSHER = c.Boolean(nullable: false),
            //            CheckDate = c.DateTime(nullable: false),
            //            TripSheetId = c.Int(nullable: false),
            //            DriverId = c.Int(nullable: false),
            //            VehicleId = c.Int(nullable: false),
            //            ActualDuty_ActualDutyId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.VehicleCheckListId)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.TripSheets", t => t.TripSheetId, cascadeDelete: true)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
            //    .ForeignKey("dbo.ActualDuties", t => t.ActualDuty_ActualDutyId)
            //    .Index(t => t.TripSheetId)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId)
            //    .Index(t => t.ActualDuty_ActualDutyId);
            
            //CreateTable(
            //    "dbo.EnrollmentContractSalesmen",
            //    c => new
            //        {
            //            EnrollmentContractSalesmanID = c.Int(nullable: false, identity: true),
            //            ContractId = c.Int(nullable: false),
            //            SalesManId = c.Int(nullable: false),
            //            StartDate = c.DateTime(nullable: false),
            //            EndDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.EnrollmentContractSalesmanID)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.SalesManId);
            
            //CreateTable(
            //    "dbo.Quotations",
            //    c => new
            //        {
            //            QuotationId = c.Int(nullable: false, identity: true),
            //            QuotationCode = c.Int(nullable: false),
            //            docs = c.Int(nullable: false),
            //            attachment = c.Int(nullable: false),
            //            CustomerName = c.String(),
            //            Code = c.String(),
            //            QuotationTypeId = c.Int(),
            //            IsRecycables = c.Boolean(nullable: false),
            //            QuoteType = c.String(),
            //            ContractTypeId = c.Int(nullable: false),
            //            ContractDurationId = c.Int(nullable: false),
            //            OwnerShipOfSkipId = c.Int(nullable: false),
            //            CustomerId = c.Int(),
            //            KYCId = c.Int(),
            //            QuotationDate = c.DateTime(nullable: false),
            //            QuotationValidityId = c.Int(nullable: false),
            //            Attention = c.String(nullable: false),
            //            TelNo = c.String(),
            //            EmailID = c.String(),
            //            MobileNo = c.String(),
            //            FaxNo = c.String(),
            //            ProjectName = c.String(nullable: false),
            //            SkipLocation = c.String(nullable: false),
            //            AreaId = c.Int(),
            //            collectionfrequencyGeneral = c.Int(),
            //            WasteTypeId = c.Int(nullable: false),
            //            WasteDescription = c.String(),
            //            TruckTypeId = c.Int(),
            //            SkipTypeId = c.Int(nullable: false),
            //            SkipType1Id = c.Int(),
            //            ProductId = c.Int(nullable: false),
            //            CollectionFrequencyId = c.Int(),
            //            NoOfSkips = c.Int(nullable: false),
            //            ServiceCharges = c.Single(nullable: false),
            //            NoOfVisitsRequiered = c.Single(),
            //            NoOfVisitsRequieredYearly = c.Single(),
            //            MinimumTripsRequiredPerMonth = c.Single(nullable: false),
            //            MinimumTripsRequiredPerYear = c.Single(nullable: false),
            //            MinimumInvoiceMonthlyRental = c.Single(nullable: false),
            //            MinimumInvoiceYearlyRental = c.Single(nullable: false),
            //            DMDisposalTippingFeeCharges = c.Single(nullable: false),
            //            TippingFee = c.Single(),
            //            SecurityDepositAmount = c.Single(nullable: false),
            //            PaymentTermId = c.Int(nullable: false),
            //            REMARK = c.String(),
            //            REMARKInternal = c.String(),
            //            IsDailyService = c.Boolean(nullable: false),
            //            IsYearlyWeeklyService = c.Boolean(nullable: false),
            //            IsYearlyAlternateService = c.Boolean(nullable: false),
            //            Approved = c.Boolean(nullable: false),
            //            ApprovalDate = c.DateTime(),
            //            RestrictSch = c.Boolean(nullable: false),
            //            SalesManId = c.Int(nullable: false),
            //            QuotationStatusId = c.Int(nullable: false),
            //            LastStatusDate = c.DateTime(),
            //            UserLastStatus = c.String(),
            //            StatusReason = c.String(),
            //            NatureOfBusinessId = c.Int(),
            //            EnqueryId = c.Int(),
            //            CreateDate = c.DateTime(),
            //            StampDate = c.DateTime(),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            OrginalId = c.Int(),
            //            Sequense = c.Int(),
            //            isLock = c.Boolean(nullable: false),
            //            LeadId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.QuotationId)
            //    .ForeignKey("dbo.Areas", t => t.AreaId)
            //    .ForeignKey("dbo.CollectionFrequencies", t => t.CollectionFrequencyId)
            //    .ForeignKey("dbo.ContractDurations", t => t.ContractDurationId, cascadeDelete: true)
            //    .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.Enqueries", t => t.EnqueryId)
            //    .ForeignKey("dbo.KYCs", t => t.KYCId)
            //    .ForeignKey("dbo.Leads", t => t.LeadId)
            //    .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId)
            //    .ForeignKey("dbo.OwnerShipOfSkips", t => t.OwnerShipOfSkipId, cascadeDelete: true)
            //    .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId, cascadeDelete: true)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.QuotationStatus", t => t.QuotationStatusId, cascadeDelete: true)
            //    .ForeignKey("dbo.QuotationTypes", t => t.QuotationTypeId)
            //    .ForeignKey("dbo.QuotationValidities", t => t.QuotationValidityId, cascadeDelete: true)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
            //    .ForeignKey("dbo.SkipTypes", t => t.SkipTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.SkipType1", t => t.SkipType1Id)
            //    .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
            //    .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
            //    .Index(t => t.QuotationTypeId)
            //    .Index(t => t.ContractTypeId)
            //    .Index(t => t.ContractDurationId)
            //    .Index(t => t.OwnerShipOfSkipId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.KYCId)
            //    .Index(t => t.QuotationValidityId)
            //    .Index(t => t.AreaId)
            //    .Index(t => t.WasteTypeId)
            //    .Index(t => t.TruckTypeId)
            //    .Index(t => t.SkipTypeId)
            //    .Index(t => t.SkipType1Id)
            //    .Index(t => t.ProductId)
            //    .Index(t => t.CollectionFrequencyId)
            //    .Index(t => t.PaymentTermId)
            //    .Index(t => t.SalesManId)
            //    .Index(t => t.QuotationStatusId)
            //    .Index(t => t.NatureOfBusinessId)
            //    .Index(t => t.EnqueryId)
            //    .Index(t => t.LeadId);
            
            //CreateTable(
            //    "dbo.ContractDurations",
            //    c => new
            //        {
            //            ContractDurationId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractDurationId);
            
            //CreateTable(
            //    "dbo.ContractTypes",
            //    c => new
            //        {
            //            ContractTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractTypeId);
            
            //CreateTable(
            //    "dbo.Leads",
            //    c => new
            //        {
            //            LeadId = c.Int(nullable: false, identity: true),
            //            Code = c.String(),
            //            IsNewCustomer = c.Boolean(nullable: false),
            //            CustomerId = c.Int(),
            //            CustomerName = c.String(),
            //            ContactPerson = c.String(),
            //            MobileNo = c.String(),
            //            TelephoneNo = c.String(),
            //            FaxNo = c.String(),
            //            EmailId = c.String(),
            //            HowUCome = c.String(),
            //            IsNewLocation = c.Boolean(nullable: false),
            //            EnqueryStatus = c.Int(),
            //            StatusReason = c.String(),
            //            Location = c.String(),
            //            SalesManId = c.Int(),
            //            Description = c.String(),
            //            CreateDate = c.DateTime(),
            //            UserCreate = c.String(),
            //            LastUpdateDate = c.DateTime(),
            //            UserLastUpdate = c.String(),
            //            LastStatusDate = c.DateTime(),
            //            UserLastStatus = c.String(),
            //        })
            //    .PrimaryKey(t => t.LeadId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .ForeignKey("dbo.SalesMen", t => t.SalesManId)
            //    .Index(t => t.CustomerId)
            //    .Index(t => t.SalesManId);
            
            //CreateTable(
            //    "dbo.NatureOfBusinesses",
            //    c => new
            //        {
            //            NatureOfBusinessId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.NatureOfBusinessId);
            
            //CreateTable(
            //    "dbo.OwnerShipOfSkips",
            //    c => new
            //        {
            //            OwnerShipOfSkipId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.OwnerShipOfSkipId);
            
            //CreateTable(
            //    "dbo.PaymentTerms",
            //    c => new
            //        {
            //            PaymentTermId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.PaymentTermId);
            
            //CreateTable(
            //    "dbo.QuotationFiles",
            //    c => new
            //        {
            //            QuotationFileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //            QuotationId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.QuotationFileId)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId)
            //    .Index(t => t.QuotationId);
            
            //CreateTable(
            //    "dbo.QuotationStatusAudit1",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            QuotationStatusId = c.Int(nullable: false),
            //            UserLastStatus = c.String(),
            //            LastStatusDate = c.DateTime(),
            //            StatusReason = c.String(),
            //            QuotationId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
            //    .Index(t => t.QuotationId);
            
            //CreateTable(
            //    "dbo.QuotationStatus",
            //    c => new
            //        {
            //            QuotationStatusId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.QuotationStatusId);
            
            //CreateTable(
            //    "dbo.QuotationTypes",
            //    c => new
            //        {
            //            QuotationTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.QuotationTypeId);
            
            //CreateTable(
            //    "dbo.QuotationValidities",
            //    c => new
            //        {
            //            QuotationValidityId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.QuotationValidityId);
            
            //CreateTable(
            //    "dbo.SecurityDeposits",
            //    c => new
            //        {
            //            SecurityDepositId = c.Int(nullable: false, identity: true),
            //            SecurityDepositAmount = c.Double(nullable: false),
            //            SkipDeposit = c.Double(nullable: false),
            //            TippingFeeDeposit = c.Double(nullable: false),
            //            AmountPaid = c.Double(nullable: false),
            //            ModeOfPaymentName = c.Int(nullable: false),
            //            ChqDate = c.DateTime(),
            //            ChqAmount = c.Double(),
            //            ChqNo = c.String(),
            //            ReceiptNo = c.String(),
            //            ReceiptDate = c.DateTime(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //            ReceiptFileId = c.Int(),
            //            Quotation_QuotationId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.SecurityDepositId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.ReceiptFiles", t => t.ReceiptFileId)
            //    .ForeignKey("dbo.Quotations", t => t.Quotation_QuotationId)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.ReceiptFileId)
            //    .Index(t => t.Quotation_QuotationId);
            
            //CreateTable(
            //    "dbo.ReceiptFiles",
            //    c => new
            //        {
            //            ReceiptFileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //        })
            //    .PrimaryKey(t => t.ReceiptFileId);
            
            //CreateTable(
            //    "dbo.SkipTypes",
            //    c => new
            //        {
            //            SkipTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.SkipTypeId);
            
            //CreateTable(
            //    "dbo.TermsAndConditionQutas",
            //    c => new
            //        {
            //            TermsAndConditionQutaId = c.Int(nullable: false, identity: true),
            //            Text = c.String(),
            //            QuotationId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TermsAndConditionQutaId)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
            //    .Index(t => t.QuotationId);
            
            //CreateTable(
            //    "dbo.CustomerCallers",
            //    c => new
            //        {
            //            CustomerCallerId = c.Int(nullable: false, identity: true),
            //            CallerName = c.String(),
            //            CallerNymber = c.String(),
            //            Email = c.String(),
            //            location = c.String(),
            //            CustomerId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.CustomerCallerId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .Index(t => t.CustomerId);
            
            //CreateTable(
            //    "dbo.CustomerCancelations",
            //    c => new
            //        {
            //            CustomerCancelationId = c.Int(nullable: false, identity: true),
            //            AllSkipsPullout = c.Boolean(nullable: false),
            //            Deposit = c.Int(nullable: false),
            //            FinalInvoie = c.Boolean(nullable: false),
            //            OutStandClearnce = c.Boolean(nullable: false),
            //            PaymentFeedBack = c.Int(nullable: false),
            //            Shred = c.Boolean(nullable: false),
            //            Comment = c.String(),
            //            CustomerId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CustomerCancelationId)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
            //    .Index(t => t.CustomerId);
            
            //CreateTable(
            //    "dbo.CustomerGroups",
            //    c => new
            //        {
            //            CustomerGroupId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            CustomerGroupCode = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CustomerGroupId);
            
            //CreateTable(
            //    "dbo.CustomerSalesCategories",
            //    c => new
            //        {
            //            CustomerSalesCategoryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.CustomerSalesCategoryId);
            
            //CreateTable(
            //    "dbo.EnqueryStatus",
            //    c => new
            //        {
            //            EnqueryStatusId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.EnqueryStatusId);
            
            //CreateTable(
            //    "dbo.RecycleSources",
            //    c => new
            //        {
            //            RecycleSourceId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.RecycleSourceId);
            
            //CreateTable(
            //    "dbo.RecycleTypes",
            //    c => new
            //        {
            //            RecycleTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.RecycleTypeId);
            
            //CreateTable(
            //    "dbo.LocationMasters",
            //    c => new
            //        {
            //            LocationMasterId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            AreaId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.LocationMasterId)
            //    .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
            //    .Index(t => t.AreaId);
            
            //CreateTable(
            //    "dbo.CollectionCanceledDates",
            //    c => new
            //        {
            //            CollectionCanceledDateId = c.Int(nullable: false, identity: true),
            //            ColectionCanceled_Date = c.DateTime(nullable: false),
            //            NumOfSkips = c.Int(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CollectionCanceledDateId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.CollectionDates",
            //    c => new
            //        {
            //            CollectionDateId = c.Int(nullable: false, identity: true),
            //            Colection_Date = c.DateTime(nullable: false),
            //            NumOfSkips = c.Int(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CollectionDateId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.CollectionDayMonthlies",
            //    c => new
            //        {
            //            CollectionDayMonthlyId = c.Int(nullable: false, identity: true),
            //            DayOfMonth = c.Int(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CollectionDayMonthlyId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.CollectionDays",
            //    c => new
            //        {
            //            CollectionDayId = c.Int(nullable: false, identity: true),
            //            DayOfWeek = c.String(),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CollectionDayId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.ContractFiles",
            //    c => new
            //        {
            //            ContractFileId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Path = c.String(),
            //            ValidUntil = c.DateTime(nullable: false),
            //            ContractId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ContractFileId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.ContractServiceStatus",
            //    c => new
            //        {
            //            ContractServiceStatusId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractServiceStatusId);
            
            //CreateTable(
            //    "dbo.ContractSkips",
            //    c => new
            //        {
            //            ContractSkipId = c.Int(nullable: false, identity: true),
            //            SkipSize = c.String(),
            //            ProductId = c.Int(nullable: false),
            //            SkipSerialNumber = c.String(),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ContractSkipId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.ContractStatus",
            //    c => new
            //        {
            //            ContractStatusId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            order1 = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ContractStatusId);
            
            //CreateTable(
            //    "dbo.DoSheets",
            //    c => new
            //        {
            //            DoSheetId = c.Int(nullable: false, identity: true),
            //            DoNum = c.Int(nullable: false),
            //            StartDate = c.DateTime(nullable: false),
            //            EndDate = c.DateTime(nullable: false),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DoSheetId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.Schedule1",
            //    c => new
            //        {
            //            Schedule1Id = c.Int(nullable: false),
            //            Text = c.String(),
            //            ScheduleType = c.Int(),
            //            AlternativeStart = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Schedule1Id)
            //    .ForeignKey("dbo.Contracts", t => t.Schedule1Id)
            //    .Index(t => t.Schedule1Id);
            
            //CreateTable(
            //    "dbo.TermsAndConditions",
            //    c => new
            //        {
            //            TermsAndConditionId = c.Int(nullable: false, identity: true),
            //            Text = c.String(),
            //            ContractId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TermsAndConditionId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.ContractConditionMcs",
            //    c => new
            //        {
            //            ContractConditionMcId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionMcId);
            
            //CreateTable(
            //    "dbo.ContractConditionMMs",
            //    c => new
            //        {
            //            ContractConditionMMId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionMMId);
            
            //CreateTable(
            //    "dbo.ContractConditions",
            //    c => new
            //        {
            //            ContractConditionId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionId);
            
            //CreateTable(
            //    "dbo.ContractConditionTcs",
            //    c => new
            //        {
            //            ContractConditionTcId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionTcId);
            
            //CreateTable(
            //    "dbo.ContractConditionTms",
            //    c => new
            //        {
            //            ContractConditionTmId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionTmId);
            
            //CreateTable(
            //    "dbo.ContractConditionYCs",
            //    c => new
            //        {
            //            ContractConditionYCId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionYCId);
            
            //CreateTable(
            //    "dbo.ContractConditionYms",
            //    c => new
            //        {
            //            ContractConditionYmId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ContractConditionYmId);
            
            //CreateTable(
            //    "dbo.CustomerCodes",
            //    c => new
            //        {
            //            CustomerCodeId = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.CustomerCodeId);
            
            //CreateTable(
            //    "dbo.EmailServers",
            //    c => new
            //        {
            //            EmailServerId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Host = c.String(),
            //            EnableSsl = c.Boolean(nullable: false),
            //            Port = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.EmailServerId);
            
            //CreateTable(
            //    "dbo.EmployeeUsers",
            //    c => new
            //        {
            //            EmployeeUserId = c.Int(nullable: false, identity: true),
            //            EmployeeId = c.Int(nullable: false),
            //            User = c.String(),
            //        })
            //    .PrimaryKey(t => t.EmployeeUserId);
            
            //CreateTable(
            //    "dbo.FuelRecipts",
            //    c => new
            //        {
            //            FuelReciptId = c.Int(nullable: false, identity: true),
            //            Rate = c.Single(nullable: false),
            //            Amount = c.Single(nullable: false),
            //            Qty = c.Single(nullable: false),
            //            Provider = c.String(),
            //            ReciptDate = c.DateTime(nullable: false),
            //            DriverId = c.Int(nullable: false),
            //            VehicleId = c.Int(nullable: false),
            //            ImgRecipt = c.String(),
            //        })
            //    .PrimaryKey(t => t.FuelReciptId)
            //    .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.VehicleId);
            
            //CreateTable(
            //    "dbo.Jobs",
            //    c => new
            //        {
            //            JobId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.JobId);
            
            //CreateTable(
            //    "dbo.KYCCodes",
            //    c => new
            //        {
            //            KYCCodeID = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.KYCCodeID);
            
            //CreateTable(
            //    "dbo.PermissionUsers",
            //    c => new
            //        {
            //            PermissionUserId = c.Int(nullable: false, identity: true),
            //            PermissionId = c.Int(nullable: false),
            //            Username = c.String(),
            //        })
            //    .PrimaryKey(t => t.PermissionUserId)
            //    .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
            //    .Index(t => t.PermissionId);
            
            //CreateTable(
            //    "dbo.Permissions",
            //    c => new
            //        {
            //            PermissionId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.PermissionId);
            
            //CreateTable(
            //    "dbo.QuotationStatusAudits",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            QuotationStatusId = c.Int(nullable: false),
            //            UserLastStatus = c.String(),
            //            LastStatusDate = c.DateTime(),
            //            StatusReason = c.String(),
            //            QuotationId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
            //    .Index(t => t.QuotationId);
            
            //CreateTable(
            //    "dbo.quotConditionTcs",
            //    c => new
            //        {
            //            quotConditionTcId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.quotConditionTcId);
            
            //CreateTable(
            //    "dbo.quotConditionTms",
            //    c => new
            //        {
            //            quotConditionTmId = c.Int(nullable: false, identity: true),
            //            Conditionsequence = c.Int(nullable: false),
            //            TextCondition = c.String(),
            //            TextConditionart2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.quotConditionTmId);
            
            //CreateTable(
            //    "dbo.RequestApprovals",
            //    c => new
            //        {
            //            RequestApprovalId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            RequestDate = c.DateTime(nullable: false),
            //            RequestApprovalTypeId = c.Int(nullable: false),
            //            QuotationId = c.Int(),
            //            ContractId = c.Int(),
            //            details = c.String(),
            //            UserName = c.String(),
            //            SalesManager = c.Boolean(nullable: false),
            //            BDM = c.Boolean(nullable: false),
            //            CoordinatorFull = c.Boolean(nullable: false),
            //            CoordinatorPartial = c.Boolean(nullable: false),
            //            CEO = c.Boolean(nullable: false),
            //            IsRejected = c.Boolean(),
            //            SalesManagerRemarks = c.String(),
            //            BDMRemarks = c.String(),
            //            CoordinatorFullRemarks = c.String(),
            //            CoordinatorPartialRemarks = c.String(),
            //            CEORemarks = c.String(),
            //            SalesManagerDate = c.String(),
            //            BDMDate = c.String(),
            //            CoordinatorFullDate = c.String(),
            //            CoordinatorPartialDate = c.String(),
            //            CEODate = c.String(),
            //        })
            //    .PrimaryKey(t => t.RequestApprovalId)
            //    .ForeignKey("dbo.Contracts", t => t.ContractId)
            //    .ForeignKey("dbo.Quotations", t => t.QuotationId)
            //    .ForeignKey("dbo.RequestApprovalTypes", t => t.RequestApprovalTypeId, cascadeDelete: true)
            //    .Index(t => t.RequestApprovalTypeId)
            //    .Index(t => t.QuotationId)
            //    .Index(t => t.ContractId);
            
            //CreateTable(
            //    "dbo.RequestApprovalTypes",
            //    c => new
            //        {
            //            RequestApprovalTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.RequestApprovalTypeId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Tallies",
            //    c => new
            //        {
            //            TallyId = c.Int(nullable: false, identity: true),
            //            DoNum = c.String(),
            //            CustomerName = c.String(),
            //            Location = c.String(),
            //            MonthYear = c.String(),
            //            DoDate = c.String(),
            //            ServiceType = c.String(),
            //            Qty = c.Int(nullable: false),
            //            NoOfTrip = c.Int(nullable: false),
            //            ServiceCharges = c.Single(nullable: false),
            //            SkipSize = c.String(),
            //            ContractDuration = c.String(),
            //            LpoNo = c.String(),
            //            TallyCode = c.String(),
            //            TallyName = c.String(),
            //            FixedTrips = c.Int(nullable: false),
            //            AdditionalTrip = c.Int(nullable: false),
            //            DM = c.Double(nullable: false),
            //            Tipping = c.Double(nullable: false),
            //            OwnerShip = c.String(),
            //        })
            //    .PrimaryKey(t => t.TallyId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            IsEnabled = c.Boolean(),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.YearlyCustConds",
            //    c => new
            //        {
            //            YearlyCustCondId = c.Int(nullable: false, identity: true),
            //            seq = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.YearlyCustCondId);
            
            //CreateTable(
            //    "dbo.RouteHelper",
            //    c => new
            //        {
            //            RouteId = c.Int(nullable: false),
            //            HelperId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.RouteId, t.HelperId })
            //    .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
            //    .ForeignKey("dbo.Helpers", t => t.HelperId, cascadeDelete: true)
            //    .Index(t => t.RouteId)
            //    .Index(t => t.HelperId);
            
            //CreateTable(
            //    "dbo.TripSheetDaetailHelper",
            //    c => new
            //        {
            //            TripSheetDaetailsId = c.Int(nullable: false),
            //            HelperId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.TripSheetDaetailsId, t.HelperId })
            //    .ForeignKey("dbo.TripSheetDaetails", t => t.TripSheetDaetailsId, cascadeDelete: true)
            //    .ForeignKey("dbo.Helpers", t => t.HelperId, cascadeDelete: true)
            //    .Index(t => t.TripSheetDaetailsId)
            //    .Index(t => t.HelperId);
            
            //CreateTable(
            //    "dbo.TripSheetHelper",
            //    c => new
            //        {
            //            TripSheetId = c.Int(nullable: false),
            //            HelperId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.TripSheetId, t.HelperId })
            //    .ForeignKey("dbo.TripSheets", t => t.TripSheetId, cascadeDelete: true)
            //    .ForeignKey("dbo.Helpers", t => t.HelperId, cascadeDelete: true)
            //    .Index(t => t.TripSheetId)
            //    .Index(t => t.HelperId);
            
            //CreateTable(
            //    "dbo.EnqueryRecycleSource",
            //    c => new
            //        {
            //            EnqueryId = c.Int(nullable: false),
            //            RecycleSourceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.EnqueryId, t.RecycleSourceId })
            //    .ForeignKey("dbo.Enqueries", t => t.EnqueryId, cascadeDelete: true)
            //    .ForeignKey("dbo.RecycleSources", t => t.RecycleSourceId, cascadeDelete: true)
            //    .Index(t => t.EnqueryId)
            //    .Index(t => t.RecycleSourceId);
            
            //CreateTable(
            //    "dbo.EnqueryRecycleType",
            //    c => new
            //        {
            //            EnqueryId = c.Int(nullable: false),
            //            RecycleTypeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.EnqueryId, t.RecycleTypeId })
            //    .ForeignKey("dbo.Enqueries", t => t.EnqueryId, cascadeDelete: true)
            //    .ForeignKey("dbo.RecycleTypes", t => t.RecycleTypeId, cascadeDelete: true)
            //    .Index(t => t.EnqueryId)
            //    .Index(t => t.RecycleTypeId);
            
            //CreateTable(
            //    "dbo.ContractRecycleSource",
            //    c => new
            //        {
            //            ContractId = c.Int(nullable: false),
            //            RecycleSourceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ContractId, t.RecycleSourceId })
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.RecycleSources", t => t.RecycleSourceId, cascadeDelete: true)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.RecycleSourceId);
            
            //CreateTable(
            //    "dbo.ContractRecycleType",
            //    c => new
            //        {
            //            ContractId = c.Int(nullable: false),
            //            RecycleTypeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ContractId, t.RecycleTypeId })
            //    .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
            //    .ForeignKey("dbo.RecycleTypes", t => t.RecycleTypeId, cascadeDelete: true)
            //    .Index(t => t.ContractId)
            //    .Index(t => t.RecycleTypeId);
            
            //CreateTable(
            //    "dbo.ActualDutyHelper",
            //    c => new
            //        {
            //            ActualDutyId = c.Int(nullable: false),
            //            HelperId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ActualDutyId, t.HelperId })
            //    .ForeignKey("dbo.ActualDuties", t => t.ActualDutyId, cascadeDelete: true)
            //    .ForeignKey("dbo.Helpers", t => t.HelperId, cascadeDelete: true)
            //    .Index(t => t.ActualDutyId)
            //    .Index(t => t.HelperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RequestApprovals", "RequestApprovalTypeId", "dbo.RequestApprovalTypes");
            DropForeignKey("dbo.RequestApprovals", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.RequestApprovals", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.QuotationStatusAudits", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.PermissionUsers", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.FuelRecipts", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.FuelRecipts", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.VehicleCheckLists", "ActualDuty_ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.ActualDutyHelper", "HelperId", "dbo.Helpers");
            DropForeignKey("dbo.ActualDutyHelper", "ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.Drivers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CdcReceipts", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.TermsAndConditions", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Schedule1", "Schedule1Id", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.ContractRecycleType", "RecycleTypeId", "dbo.RecycleTypes");
            DropForeignKey("dbo.ContractRecycleType", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.ContractRecycleSource", "RecycleSourceId", "dbo.RecycleSources");
            DropForeignKey("dbo.ContractRecycleSource", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.DoSheets", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ContractStatusId", "dbo.ContractStatus");
            DropForeignKey("dbo.ContractSkips", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ContractServiceStatusId", "dbo.ContractServiceStatus");
            DropForeignKey("dbo.ContractFiles", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDays", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDayMonthlies", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDates", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionCanceledDates", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CdcReceipts", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.LocationMasters", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.EnqueryRecycleType", "RecycleTypeId", "dbo.RecycleTypes");
            DropForeignKey("dbo.EnqueryRecycleType", "EnqueryId", "dbo.Enqueries");
            DropForeignKey("dbo.EnqueryRecycleSource", "RecycleSourceId", "dbo.RecycleSources");
            DropForeignKey("dbo.EnqueryRecycleSource", "EnqueryId", "dbo.Enqueries");
            DropForeignKey("dbo.Enqueries", "EnqueryStatusId", "dbo.EnqueryStatus");
            DropForeignKey("dbo.EnqueryProducts", "EnqueryId", "dbo.Enqueries");
            DropForeignKey("dbo.Customers", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
            DropForeignKey("dbo.Enqueries", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CustomerSalesCategoryId", "dbo.CustomerSalesCategories");
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerCancelations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCallers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Quotations", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.Quotations", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.TermsAndConditionQutas", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.Quotations", "SkipTypeId", "dbo.SkipTypes");
            DropForeignKey("dbo.Contracts", "SkipTypeId", "dbo.SkipTypes");
            DropForeignKey("dbo.SecurityDeposits", "Quotation_QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.SecurityDeposits", "ReceiptFileId", "dbo.ReceiptFiles");
            DropForeignKey("dbo.SecurityDeposits", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Quotations", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.Quotations", "QuotationValidityId", "dbo.QuotationValidities");
            DropForeignKey("dbo.Quotations", "QuotationTypeId", "dbo.QuotationTypes");
            DropForeignKey("dbo.Quotations", "QuotationStatusId", "dbo.QuotationStatus");
            DropForeignKey("dbo.QuotationStatusAudit1", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.QuotationFiles", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Quotations", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Enqueries", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Contracts", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Quotations", "OwnerShipOfSkipId", "dbo.OwnerShipOfSkips");
            DropForeignKey("dbo.Contracts", "OwnerShipOfSkipId", "dbo.OwnerShipOfSkips");
            DropForeignKey("dbo.Quotations", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
            DropForeignKey("dbo.Enqueries", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
            DropForeignKey("dbo.Contracts", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
            DropForeignKey("dbo.Leads", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.Quotations", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Leads", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Quotations", "KYCId", "dbo.KYCs");
            DropForeignKey("dbo.Quotations", "EnqueryId", "dbo.Enqueries");
            DropForeignKey("dbo.CustomerFiles", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Quotations", "ContractTypeId", "dbo.ContractTypes");
            DropForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes");
            DropForeignKey("dbo.Contracts", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "ContractDurationId", "dbo.ContractDurations");
            DropForeignKey("dbo.Contracts", "ContractDurationId", "dbo.ContractDurations");
            DropForeignKey("dbo.Quotations", "CollectionFrequencyId", "dbo.CollectionFrequencies");
            DropForeignKey("dbo.Quotations", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AnnualPaymentTerms", "Quotation_QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.KYCs", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.EnrollmentContractSalesmen", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.EnrollmentContractSalesmen", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Enqueries", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.VehicleCheckLists", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleCheckLists", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.VehicleCheckLists", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.TripSheets", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Shifts", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.TripSheetHelper", "HelperId", "dbo.Helpers");
            DropForeignKey("dbo.TripSheetHelper", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.Vehicles", "VehicleMakerId", "dbo.VehicleMakers");
            DropForeignKey("dbo.TripSheetDaetails", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TripSheetDeatails_skip", "TripSheetDaetailsId", "dbo.TripSheetDaetails");
            DropForeignKey("dbo.TripSheetDeatails_skip", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TripSheetDeatails_skip", "DumbId", "dbo.Dumbs");
            DropForeignKey("dbo.Dumbs", "DumpLocationId", "dbo.DumpLocations");
            DropForeignKey("dbo.TripSheetDeatails_skip", "DumpLocationId", "dbo.DumpLocations");
            DropForeignKey("dbo.TripSheetDaetails", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.Products", "Unit_ProductId", "dbo.Unit_Product");
            DropForeignKey("dbo.Products", "Type_ProductId", "dbo.Type_Product");
            DropForeignKey("dbo.Vehicles", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.Products", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.Contracts", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.TripSheetDaetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.LPOes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.LPOes", "LpoTypeId", "dbo.LpoTypes");
            DropForeignKey("dbo.LpoSuspends", "LpoId", "dbo.LPOes");
            DropForeignKey("dbo.LPOes", "LpoStatusId", "dbo.LpoStatus");
            DropForeignKey("dbo.Lpofiles", "LPOId", "dbo.LPOes");
            DropForeignKey("dbo.CustomerFiles", "LPOId", "dbo.LPOes");
            DropForeignKey("dbo.LPOes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.LPOes", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.EnqueryProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.EnqueryProducts", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.Enqueries", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.Contracts", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.EnqueryProducts", "SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.Enqueries", "SkipType1_SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.Contracts", "SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.EnqueryProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.EnqueryProducts", "Enquery_EnqueryId", "dbo.Enqueries");
            DropForeignKey("dbo.EnqueryProducts", "CollectionFrequencyId", "dbo.CollectionFrequencies");
            DropForeignKey("dbo.Contracts", "CollectionFrequencyId", "dbo.CollectionFrequencies");
            DropForeignKey("dbo.Contracts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_ProductId", "dbo.Category_Product");
            DropForeignKey("dbo.TripSheetDaetailHelper", "HelperId", "dbo.Helpers");
            DropForeignKey("dbo.TripSheetDaetailHelper", "TripSheetDaetailsId", "dbo.TripSheetDaetails");
            DropForeignKey("dbo.TripSheetDaetails", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.TripSheetDaetails", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.TripSheetDaetails", "CallBasedId", "dbo.CallBaseds");
            DropForeignKey("dbo.TripSheetDaetails", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.CallBaseds", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.CallBaseds", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Routes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.ActualDuties", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TripSheets", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.RouteHelper", "HelperId", "dbo.Helpers");
            DropForeignKey("dbo.RouteHelper", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Contracts", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.ActualDuties", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Helpers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TripSheets", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Shifts", "ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.SalesMen", "SalesTeamId", "dbo.SalesTeams");
            DropForeignKey("dbo.SalesTeams", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesMen", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CustomerFolderHandlings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CustomerFolderHandlings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.ModeOfPayments", "KYC_KYCId", "dbo.KYCs");
            DropForeignKey("dbo.KYCs", "ModeOfPayment_ModeOfPaymentId", "dbo.ModeOfPayments");
            DropForeignKey("dbo.KycFiles", "KYCId", "dbo.KYCs");
            DropForeignKey("dbo.KYCs", "InvoiceDeliveryLocationId", "dbo.InvoiceDeliveryLocations");
            DropForeignKey("dbo.KYCs", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "KYCId", "dbo.KYCs");
            DropForeignKey("dbo.CustomerFiles", "KYCId", "dbo.KYCs");
            DropForeignKey("dbo.CustomerFiles", "CustomerFileTypeId", "dbo.CustomerFileTypes");
            DropForeignKey("dbo.CustomerFiles", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerFiles", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Enqueries", "CompetitorId", "dbo.Competitors");
            DropForeignKey("dbo.Enqueries", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Contracts", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AnnualPaymentTerms", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.ActualDuties", "DriverId", "dbo.Drivers");
            DropIndex("dbo.ActualDutyHelper", new[] { "HelperId" });
            DropIndex("dbo.ActualDutyHelper", new[] { "ActualDutyId" });
            DropIndex("dbo.ContractRecycleType", new[] { "RecycleTypeId" });
            DropIndex("dbo.ContractRecycleType", new[] { "ContractId" });
            DropIndex("dbo.ContractRecycleSource", new[] { "RecycleSourceId" });
            DropIndex("dbo.ContractRecycleSource", new[] { "ContractId" });
            DropIndex("dbo.EnqueryRecycleType", new[] { "RecycleTypeId" });
            DropIndex("dbo.EnqueryRecycleType", new[] { "EnqueryId" });
            DropIndex("dbo.EnqueryRecycleSource", new[] { "RecycleSourceId" });
            DropIndex("dbo.EnqueryRecycleSource", new[] { "EnqueryId" });
            DropIndex("dbo.TripSheetHelper", new[] { "HelperId" });
            DropIndex("dbo.TripSheetHelper", new[] { "TripSheetId" });
            DropIndex("dbo.TripSheetDaetailHelper", new[] { "HelperId" });
            DropIndex("dbo.TripSheetDaetailHelper", new[] { "TripSheetDaetailsId" });
            DropIndex("dbo.RouteHelper", new[] { "HelperId" });
            DropIndex("dbo.RouteHelper", new[] { "RouteId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RequestApprovals", new[] { "ContractId" });
            DropIndex("dbo.RequestApprovals", new[] { "QuotationId" });
            DropIndex("dbo.RequestApprovals", new[] { "RequestApprovalTypeId" });
            DropIndex("dbo.QuotationStatusAudits", new[] { "QuotationId" });
            DropIndex("dbo.PermissionUsers", new[] { "PermissionId" });
            DropIndex("dbo.FuelRecipts", new[] { "VehicleId" });
            DropIndex("dbo.FuelRecipts", new[] { "DriverId" });
            DropIndex("dbo.TermsAndConditions", new[] { "ContractId" });
            DropIndex("dbo.Schedule1", new[] { "Schedule1Id" });
            DropIndex("dbo.DoSheets", new[] { "ContractId" });
            DropIndex("dbo.ContractSkips", new[] { "ContractId" });
            DropIndex("dbo.ContractFiles", new[] { "ContractId" });
            DropIndex("dbo.CollectionDays", new[] { "ContractId" });
            DropIndex("dbo.CollectionDayMonthlies", new[] { "ContractId" });
            DropIndex("dbo.CollectionDates", new[] { "ContractId" });
            DropIndex("dbo.CollectionCanceledDates", new[] { "ContractId" });
            DropIndex("dbo.LocationMasters", new[] { "AreaId" });
            DropIndex("dbo.CustomerCancelations", new[] { "CustomerId" });
            DropIndex("dbo.CustomerCallers", new[] { "CustomerId" });
            DropIndex("dbo.TermsAndConditionQutas", new[] { "QuotationId" });
            DropIndex("dbo.SecurityDeposits", new[] { "Quotation_QuotationId" });
            DropIndex("dbo.SecurityDeposits", new[] { "ReceiptFileId" });
            DropIndex("dbo.SecurityDeposits", new[] { "ContractId" });
            DropIndex("dbo.QuotationStatusAudit1", new[] { "QuotationId" });
            DropIndex("dbo.QuotationFiles", new[] { "QuotationId" });
            DropIndex("dbo.Leads", new[] { "SalesManId" });
            DropIndex("dbo.Leads", new[] { "CustomerId" });
            DropIndex("dbo.Quotations", new[] { "LeadId" });
            DropIndex("dbo.Quotations", new[] { "EnqueryId" });
            DropIndex("dbo.Quotations", new[] { "NatureOfBusinessId" });
            DropIndex("dbo.Quotations", new[] { "QuotationStatusId" });
            DropIndex("dbo.Quotations", new[] { "SalesManId" });
            DropIndex("dbo.Quotations", new[] { "PaymentTermId" });
            DropIndex("dbo.Quotations", new[] { "CollectionFrequencyId" });
            DropIndex("dbo.Quotations", new[] { "ProductId" });
            DropIndex("dbo.Quotations", new[] { "SkipType1Id" });
            DropIndex("dbo.Quotations", new[] { "SkipTypeId" });
            DropIndex("dbo.Quotations", new[] { "TruckTypeId" });
            DropIndex("dbo.Quotations", new[] { "WasteTypeId" });
            DropIndex("dbo.Quotations", new[] { "AreaId" });
            DropIndex("dbo.Quotations", new[] { "QuotationValidityId" });
            DropIndex("dbo.Quotations", new[] { "KYCId" });
            DropIndex("dbo.Quotations", new[] { "CustomerId" });
            DropIndex("dbo.Quotations", new[] { "OwnerShipOfSkipId" });
            DropIndex("dbo.Quotations", new[] { "ContractDurationId" });
            DropIndex("dbo.Quotations", new[] { "ContractTypeId" });
            DropIndex("dbo.Quotations", new[] { "QuotationTypeId" });
            DropIndex("dbo.EnrollmentContractSalesmen", new[] { "SalesManId" });
            DropIndex("dbo.EnrollmentContractSalesmen", new[] { "ContractId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "ActualDuty_ActualDutyId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "VehicleId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "DriverId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "TripSheetId" });
            DropIndex("dbo.Dumbs", new[] { "DumpLocationId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "DumpLocationId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "DumbId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "ProductId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "TripSheetDaetailsId" });
            DropIndex("dbo.LpoSuspends", new[] { "LpoId" });
            DropIndex("dbo.Lpofiles", new[] { "LPOId" });
            DropIndex("dbo.LPOes", new[] { "LpoStatusId" });
            DropIndex("dbo.LPOes", new[] { "ProductId" });
            DropIndex("dbo.LPOes", new[] { "LpoTypeId" });
            DropIndex("dbo.LPOes", new[] { "CustomerId" });
            DropIndex("dbo.LPOes", new[] { "ContractId" });
            DropIndex("dbo.EnqueryProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.EnqueryProducts", new[] { "Enquery_EnqueryId" });
            DropIndex("dbo.EnqueryProducts", new[] { "CollectionFrequencyId" });
            DropIndex("dbo.EnqueryProducts", new[] { "WasteTypeId" });
            DropIndex("dbo.EnqueryProducts", new[] { "SkipType1Id" });
            DropIndex("dbo.EnqueryProducts", new[] { "ProductId" });
            DropIndex("dbo.EnqueryProducts", new[] { "EnqueryId" });
            DropIndex("dbo.Products", new[] { "TruckTypeId" });
            DropIndex("dbo.Products", new[] { "Type_ProductId" });
            DropIndex("dbo.Products", new[] { "Unit_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_ProductId" });
            DropIndex("dbo.CallBaseds", new[] { "ServiceTypeId" });
            DropIndex("dbo.CallBaseds", new[] { "ContractId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "TripSheetId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "CallBasedId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ServiceTypeId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "VehicleId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "DriverId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ProductId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ContractId" });
            DropIndex("dbo.Vehicles", new[] { "TruckTypeId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleMakerId" });
            DropIndex("dbo.Routes", new[] { "VehicleId" });
            DropIndex("dbo.Routes", new[] { "DriverId" });
            DropIndex("dbo.Helpers", new[] { "EmployeeId" });
            DropIndex("dbo.TripSheets", new[] { "VehicleId" });
            DropIndex("dbo.TripSheets", new[] { "DriverId" });
            DropIndex("dbo.TripSheets", new[] { "RouteId" });
            DropIndex("dbo.Shifts", new[] { "TripSheetId" });
            DropIndex("dbo.Shifts", new[] { "ActualDutyId" });
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropIndex("dbo.SalesTeams", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerFolderHandlings", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerFolderHandlings", new[] { "CustomerId" });
            DropIndex("dbo.SalesMen", new[] { "SalesTeamId" });
            DropIndex("dbo.SalesMen", new[] { "EmployeeId" });
            DropIndex("dbo.ModeOfPayments", new[] { "KYC_KYCId" });
            DropIndex("dbo.KycFiles", new[] { "KYCId" });
            DropIndex("dbo.KYCs", new[] { "ModeOfPayment_ModeOfPaymentId" });
            DropIndex("dbo.KYCs", new[] { "InvoiceDeliveryLocationId" });
            DropIndex("dbo.KYCs", new[] { "SalesManId" });
            DropIndex("dbo.KYCs", new[] { "CustomerId" });
            DropIndex("dbo.CustomerFiles", new[] { "CustomerFileTypeId" });
            DropIndex("dbo.CustomerFiles", new[] { "LPOId" });
            DropIndex("dbo.CustomerFiles", new[] { "QuotationId" });
            DropIndex("dbo.CustomerFiles", new[] { "ContractId" });
            DropIndex("dbo.CustomerFiles", new[] { "KYCId" });
            DropIndex("dbo.CustomerFiles", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "SalesManId" });
            DropIndex("dbo.Customers", new[] { "CustomerSalesCategoryId" });
            DropIndex("dbo.Customers", new[] { "NatureOfBusinessId" });
            DropIndex("dbo.Customers", new[] { "CustomerGroupId" });
            DropIndex("dbo.Enqueries", new[] { "SkipType1_SkipType1Id" });
            DropIndex("dbo.Enqueries", new[] { "PaymentTermId" });
            DropIndex("dbo.Enqueries", new[] { "SalesManId" });
            DropIndex("dbo.Enqueries", new[] { "AreaId" });
            DropIndex("dbo.Enqueries", new[] { "CompetitorId" });
            DropIndex("dbo.Enqueries", new[] { "WasteTypeId" });
            DropIndex("dbo.Enqueries", new[] { "NatureOfBusinessId" });
            DropIndex("dbo.Enqueries", new[] { "CustomerId" });
            DropIndex("dbo.Enqueries", new[] { "EnqueryStatusId" });
            DropIndex("dbo.AnnualPaymentTerms", new[] { "Quotation_QuotationId" });
            DropIndex("dbo.AnnualPaymentTerms", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "ContractServiceStatusId" });
            DropIndex("dbo.Contracts", new[] { "RouteId" });
            DropIndex("dbo.Contracts", new[] { "NatureOfBusinessId" });
            DropIndex("dbo.Contracts", new[] { "ContractStatusId" });
            DropIndex("dbo.Contracts", new[] { "SalesManId" });
            DropIndex("dbo.Contracts", new[] { "PaymentTermId" });
            DropIndex("dbo.Contracts", new[] { "CollectionFrequencyId" });
            DropIndex("dbo.Contracts", new[] { "ProductId" });
            DropIndex("dbo.Contracts", new[] { "SkipType1Id" });
            DropIndex("dbo.Contracts", new[] { "SkipTypeId" });
            DropIndex("dbo.Contracts", new[] { "TruckTypeId" });
            DropIndex("dbo.Contracts", new[] { "WasteTypeId" });
            DropIndex("dbo.Contracts", new[] { "QuotationId" });
            DropIndex("dbo.Contracts", new[] { "AreaId" });
            DropIndex("dbo.Contracts", new[] { "KYCId" });
            DropIndex("dbo.Contracts", new[] { "CustomerId" });
            DropIndex("dbo.Contracts", new[] { "OwnerShipOfSkipId" });
            DropIndex("dbo.Contracts", new[] { "ContractDurationId" });
            DropIndex("dbo.Contracts", new[] { "ContractTypeId" });
            DropIndex("dbo.CdcReceipts", new[] { "ContractId" });
            DropIndex("dbo.CdcReceipts", new[] { "DriverId" });
            DropIndex("dbo.Drivers", new[] { "EmployeeId" });
            DropIndex("dbo.ActualDuties", new[] { "VehicleId" });
            DropIndex("dbo.ActualDuties", new[] { "DriverId" });
            DropIndex("dbo.ActualDuties", new[] { "RouteId" });
            DropTable("dbo.ActualDutyHelper");
            DropTable("dbo.ContractRecycleType");
            DropTable("dbo.ContractRecycleSource");
            DropTable("dbo.EnqueryRecycleType");
            DropTable("dbo.EnqueryRecycleSource");
            DropTable("dbo.TripSheetHelper");
            DropTable("dbo.TripSheetDaetailHelper");
            DropTable("dbo.RouteHelper");
            DropTable("dbo.YearlyCustConds");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tallies");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RequestApprovalTypes");
            DropTable("dbo.RequestApprovals");
            DropTable("dbo.quotConditionTms");
            DropTable("dbo.quotConditionTcs");
            DropTable("dbo.QuotationStatusAudits");
            DropTable("dbo.Permissions");
            DropTable("dbo.PermissionUsers");
            DropTable("dbo.KYCCodes");
            DropTable("dbo.Jobs");
            DropTable("dbo.FuelRecipts");
            DropTable("dbo.EmployeeUsers");
            DropTable("dbo.EmailServers");
            DropTable("dbo.CustomerCodes");
            DropTable("dbo.ContractConditionYms");
            DropTable("dbo.ContractConditionYCs");
            DropTable("dbo.ContractConditionTms");
            DropTable("dbo.ContractConditionTcs");
            DropTable("dbo.ContractConditions");
            DropTable("dbo.ContractConditionMMs");
            DropTable("dbo.ContractConditionMcs");
            DropTable("dbo.TermsAndConditions");
            DropTable("dbo.Schedule1");
            DropTable("dbo.DoSheets");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.ContractSkips");
            DropTable("dbo.ContractServiceStatus");
            DropTable("dbo.ContractFiles");
            DropTable("dbo.CollectionDays");
            DropTable("dbo.CollectionDayMonthlies");
            DropTable("dbo.CollectionDates");
            DropTable("dbo.CollectionCanceledDates");
            DropTable("dbo.LocationMasters");
            DropTable("dbo.RecycleTypes");
            DropTable("dbo.RecycleSources");
            DropTable("dbo.EnqueryStatus");
            DropTable("dbo.CustomerSalesCategories");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.CustomerCancelations");
            DropTable("dbo.CustomerCallers");
            DropTable("dbo.TermsAndConditionQutas");
            DropTable("dbo.SkipTypes");
            DropTable("dbo.ReceiptFiles");
            DropTable("dbo.SecurityDeposits");
            DropTable("dbo.QuotationValidities");
            DropTable("dbo.QuotationTypes");
            DropTable("dbo.QuotationStatus");
            DropTable("dbo.QuotationStatusAudit1");
            DropTable("dbo.QuotationFiles");
            DropTable("dbo.PaymentTerms");
            DropTable("dbo.OwnerShipOfSkips");
            DropTable("dbo.NatureOfBusinesses");
            DropTable("dbo.Leads");
            DropTable("dbo.ContractTypes");
            DropTable("dbo.ContractDurations");
            DropTable("dbo.Quotations");
            DropTable("dbo.EnrollmentContractSalesmen");
            DropTable("dbo.VehicleCheckLists");
            DropTable("dbo.VehicleMakers");
            DropTable("dbo.DumpLocations");
            DropTable("dbo.Dumbs");
            DropTable("dbo.TripSheetDeatails_skip");
            DropTable("dbo.Unit_Product");
            DropTable("dbo.Type_Product");
            DropTable("dbo.TruckTypes");
            DropTable("dbo.LpoTypes");
            DropTable("dbo.LpoSuspends");
            DropTable("dbo.LpoStatus");
            DropTable("dbo.Lpofiles");
            DropTable("dbo.LPOes");
            DropTable("dbo.WasteTypes");
            DropTable("dbo.SkipType1");
            DropTable("dbo.CollectionFrequencies");
            DropTable("dbo.EnqueryProducts");
            DropTable("dbo.Category_Product");
            DropTable("dbo.Products");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.CallBaseds");
            DropTable("dbo.TripSheetDaetails");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Routes");
            DropTable("dbo.Helpers");
            DropTable("dbo.TripSheets");
            DropTable("dbo.Shifts");
            DropTable("dbo.SalesTeams");
            DropTable("dbo.CustomerFolderHandlings");
            DropTable("dbo.Employees");
            DropTable("dbo.SalesMen");
            DropTable("dbo.ModeOfPayments");
            DropTable("dbo.KycFiles");
            DropTable("dbo.InvoiceDeliveryLocations");
            DropTable("dbo.KYCs");
            DropTable("dbo.CustomerFileTypes");
            DropTable("dbo.CustomerFiles");
            DropTable("dbo.Customers");
            DropTable("dbo.Competitors");
            DropTable("dbo.Enqueries");
            DropTable("dbo.Areas");
            DropTable("dbo.AnnualPaymentTerms");
            DropTable("dbo.Contracts");
            DropTable("dbo.CdcReceipts");
            DropTable("dbo.Drivers");
            DropTable("dbo.ActualDuties");
        }
    }
}
