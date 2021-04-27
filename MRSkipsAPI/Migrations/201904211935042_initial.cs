namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.AnnualPaymentTerms",
                c => new
                    {
                        AnnualPaymentTermId = c.Int(nullable: false, identity: true),
                        AmountPaid = c.Double(nullable: false),
                        ModeOfPaymentName = c.Int(nullable: false),
                        DateOfPayment = c.DateTime(nullable: false),
                        Balance = c.Double(nullable: false),
                        ContractId = c.Int(nullable: false),
                        Quotation_QuotationId = c.Int(),
                    })
                .PrimaryKey(t => t.AnnualPaymentTermId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Quotations", t => t.Quotation_QuotationId)
                .Index(t => t.ContractId)
                .Index(t => t.Quotation_QuotationId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        ContractCode = c.Int(nullable: false),
                        Code = c.String(),
                        ISLPOAvailable = c.Boolean(),
                        IsRecycables = c.Boolean(nullable: false),
                        QuoteType = c.String(),
                        ContractTypeId = c.Int(nullable: false),
                        ContractDurationId = c.Int(nullable: false),
                        OwnerShipOfSkipId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        KYCId = c.Int(),
                        ContractDate = c.DateTime(nullable: false),
                        Valid1 = c.DateTime(nullable: false),
                        Attention = c.String(nullable: false),
                        TelNo = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        MobileNo = c.String(),
                        FaxNo = c.String(),
                        ProjectName = c.String(),
                        SkipLocation = c.String(nullable: false),
                        AreaId = c.Int(),
                        QuotationId = c.Int(),
                        QuotationRef = c.String(),
                        QuotationDate = c.DateTime(),
                        collectionfrequencyGeneral = c.Int(),
                        LPORef = c.String(),
                        LPODate = c.DateTime(),
                        LPOExpiry = c.DateTime(),
                        LPOQty = c.Int(),
                        LPOQtyBalance = c.Int(),
                        BalanceQty = c.Int(),
                        BalanceQtyOnAvailedTrip = c.Int(),
                        WasteTypeId = c.Int(nullable: false),
                        WasteDescription = c.String(),
                        TruckTypeId = c.Int(),
                        SkipTypeId = c.Int(nullable: false),
                        SkipType1Id = c.Int(),
                        ProductId = c.Int(nullable: false),
                        CollectionFrequencyId = c.Int(),
                        NoOfSkips = c.Int(nullable: false),
                        ServiceCharges = c.Single(nullable: false),
                        NoOfVisitsRequiered = c.Single(),
                        NoOfVisitsRequieredYearly = c.Single(),
                        MinimumTripsRequiredPerMonth = c.Single(nullable: false),
                        MinimumTripsRequiredPerYear = c.Single(nullable: false),
                        MinimumInvoiceMonthlyRental = c.Single(nullable: false),
                        MinimumInvoiceYearlyRental = c.Single(nullable: false),
                        DMDisposalTippingFeeCharges = c.Single(nullable: false),
                        TippingFee = c.Single(),
                        SecurityDepositAmount = c.Single(nullable: false),
                        PaymentTermId = c.Int(nullable: false),
                        REMARK = c.String(),
                        REMARKInternal = c.String(),
                        IsDailyService = c.Boolean(nullable: false),
                        IsYearlyWeeklyService = c.Boolean(nullable: false),
                        IsYearlyAlternateService = c.Boolean(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        ApprovalDate = c.DateTime(),
                        TallyName = c.String(),
                        TallyCode = c.String(),
                        RestrictSch = c.Boolean(nullable: false),
                        DocumentId = c.Int(),
                        SalesManId = c.Int(nullable: false),
                        ContractStatusId = c.Int(nullable: false),
                        NatureOfBusinessId = c.Int(),
                        StatusReason = c.String(),
                        StatusServiceReason = c.String(),
                        RouteId = c.Int(),
                        ContractServiceStatusId = c.Int(nullable: false),
                        Schedule1Id = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UserCreate = c.String(),
                        LastUpdateDate = c.DateTime(),
                        UserLastUpdate = c.String(),
                        Sequense = c.Int(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.KYCs", t => t.KYCId)
                .ForeignKey("dbo.CollectionFrequencies", t => t.CollectionFrequencyId)
                .ForeignKey("dbo.ContractDurations", t => t.ContractDurationId, cascadeDelete: true)
                .ForeignKey("dbo.Quotations", t => t.QuotationId)
                .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
                .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId)
                .ForeignKey("dbo.OwnerShipOfSkips", t => t.OwnerShipOfSkipId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
                .ForeignKey("dbo.SkipTypes", t => t.SkipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SkipType1", t => t.SkipType1Id)
                .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Routes", t => t.RouteId)
                .ForeignKey("dbo.ContractServiceStatus", t => t.ContractServiceStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ContractStatus", t => t.ContractStatusId, cascadeDelete: true)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
                .Index(t => t.ContractTypeId)
                .Index(t => t.ContractDurationId)
                .Index(t => t.OwnerShipOfSkipId)
                .Index(t => t.CustomerId)
                .Index(t => t.KYCId)
                .Index(t => t.AreaId)
                .Index(t => t.QuotationId)
                .Index(t => t.WasteTypeId)
                .Index(t => t.TruckTypeId)
                .Index(t => t.SkipTypeId)
                .Index(t => t.SkipType1Id)
                .Index(t => t.ProductId)
                .Index(t => t.CollectionFrequencyId)
                .Index(t => t.PaymentTermId)
                .Index(t => t.SalesManId)
                .Index(t => t.ContractStatusId)
                .Index(t => t.NatureOfBusinessId)
                .Index(t => t.RouteId)
                .Index(t => t.ContractServiceStatusId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.LocationMasters",
                c => new
                    {
                        LocationMasterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationMasterId)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.CallBaseds",
                c => new
                    {
                        CallBasedId = c.Int(nullable: false, identity: true),
                        Colection_Date = c.DateTime(nullable: false),
                        NumOfSkips = c.Int(nullable: false),
                        WasteType = c.String(),
                        CallerName = c.String(),
                        CallerNymber = c.String(),
                        Email = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        FollowUpNo = c.Int(),
                        FollowUpRemarks = c.String(),
                        ManagerApproval = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        UserId = c.String(),
                        UserName = c.String(),
                        ContractId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        Schedule_ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.CallBasedId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId)
                .Index(t => t.ContractId)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.Schedule_ScheduleId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.TripSheetDaetails",
                c => new
                    {
                        TripSheetDaetailsId = c.Int(nullable: false, identity: true),
                        TripsDate = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                        DoNum = c.String(),
                        SkipSerialNumber = c.String(),
                        ProductId = c.Int(nullable: false),
                        NumberOfSkips = c.Int(nullable: false),
                        NumberOfSkipscollected = c.Int(),
                        Timein = c.String(),
                        Timeout = c.String(),
                        Weight = c.String(),
                        Remarks = c.String(),
                        Status = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Helpers = c.String(),
                        VehicleId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(),
                        CallBasedId = c.Int(),
                    })
                .PrimaryKey(t => t.TripSheetDaetailsId)
                .ForeignKey("dbo.CallBaseds", t => t.CallBasedId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId)
                .Index(t => t.ContractId)
                .Index(t => t.ProductId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.CallBasedId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        AppUserName = c.String(),
                        AppPassWard = c.String(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.CustomerFolderHandlings",
                c => new
                    {
                        CustomerFolderHandlingId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        TakenDate = c.DateTime(nullable: false, storeType: "date"),
                        ReturnDate = c.DateTime(storeType: "date"),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.CustomerFolderHandlingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerGroupId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Industry = c.String(),
                        CustomerCode = c.Int(nullable: false),
                        TradeLicenceNo = c.String(nullable: false),
                        TRNNo = c.String(nullable: false, maxLength: 15),
                        OfficeAddressHO = c.String(nullable: false),
                        ContactPerson = c.String(),
                        Mobile = c.String(),
                        CompanyTelNo = c.String(),
                        CompanyFaxNo = c.String(),
                        CompanyEmailID = c.String(),
                        FolederLocation = c.String(),
                        DocumentIdTrade = c.Int(),
                        DocumentIdID = c.Int(),
                        DocumentIdPass = c.Int(),
                        CustomerSalesCategoryId = c.Int(nullable: false),
                        SalesManId = c.Int(nullable: false),
                        CrerateDate = c.DateTime(),
                        UserCreate = c.String(),
                        LastUpdateDate = c.DateTime(),
                        UserLastUpdate = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerSalesCategories", t => t.CustomerSalesCategoryId, cascadeDelete: true)
                .Index(t => t.CustomerGroupId)
                .Index(t => t.CustomerSalesCategoryId)
                .Index(t => t.SalesManId);
            
            CreateTable(
                "dbo.CustomerFiles",
                c => new
                    {
                        CustomerFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        ValidUntil = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CustomerId = c.Int(),
                        KYCId = c.Int(),
                        ContractId = c.Int(),
                        QuotationId = c.Int(),
                        LPOId = c.Int(),
                        CustomerFileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerFileId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.CustomerFileTypes", t => t.CustomerFileTypeId, cascadeDelete: true)
                .ForeignKey("dbo.KYCs", t => t.KYCId)
                .ForeignKey("dbo.Quotations", t => t.QuotationId)
                .ForeignKey("dbo.LPOes", t => t.LPOId)
                .Index(t => t.CustomerId)
                .Index(t => t.KYCId)
                .Index(t => t.ContractId)
                .Index(t => t.QuotationId)
                .Index(t => t.LPOId)
                .Index(t => t.CustomerFileTypeId);
            
            CreateTable(
                "dbo.CustomerFileTypes",
                c => new
                    {
                        CustomerFileTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerFileTypeId);
            
            CreateTable(
                "dbo.KYCs",
                c => new
                    {
                        KYCId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SalesManId = c.Int(nullable: false),
                        KYCCode = c.String(),
                        OwnerName = c.String(),
                        OwnerContact = c.String(),
                        OwnerEmail = c.String(),
                        MdName = c.String(),
                        MdContact = c.String(),
                        MdEmail = c.String(),
                        ClientSupplier1 = c.String(),
                        ClientSupplier2 = c.String(),
                        ContactOfficeName = c.String(),
                        ContactOfficeDesignation = c.String(),
                        ContactOfficeDepartment = c.String(),
                        ContactOfficeMobileNo = c.String(),
                        ContactOfficeTelNoExtn = c.String(),
                        ContactOfficeFax = c.String(),
                        ContactOfficeEmail = c.String(),
                        ContactOfficeRemarks = c.String(),
                        CutOffdateofinvoicesubmission = c.String(),
                        InvoiceDeliveryThroughEmail = c.Boolean(nullable: false),
                        InvoiceDeliveryHardcopy = c.Boolean(nullable: false),
                        InvoiceDeliveryLocationId = c.Int(),
                        InvoiceDeliveryAddress = c.String(),
                        MakaniNo = c.String(),
                        InvoiceAccountContactPerson = c.String(),
                        InvoiceAccountContactNo = c.String(),
                        InvoiceAccountEmail = c.String(),
                        ModeOfPaymentId = c.Int(),
                        PaymentAccountsPayable = c.String(),
                        PaymentAccountMobileNo = c.String(),
                        PaymentAccountTelNoExtn = c.String(),
                        PaymentAccountEmail = c.String(),
                        FinanceMangerName = c.String(),
                        FinanceMangerContactNo = c.String(),
                        FinanceMangerEmail = c.String(),
                        PaymentCollectionDetails = c.String(),
                        CollectionLocation = c.String(),
                        CollectionContactPerson = c.String(),
                        CollectionContactPersonDesignation = c.String(),
                        CollectionContactNo = c.String(),
                        PaymentCollectionDays = c.String(),
                        PaymentCollectionTiming = c.String(),
                        CollectionPaymentRemarks = c.String(),
                        SiteLocation = c.String(nullable: false),
                        ProjectName = c.String(nullable: false),
                        SiteContactPersonNameDayShift = c.String(),
                        SiteDayDesignation = c.String(),
                        SiteDayEmail = c.String(),
                        SiteDayMobileNo = c.String(),
                        SiteContactPersonNameNightShift = c.String(),
                        SiteNightDesignation = c.String(),
                        SiteNightEmail = c.String(),
                        SiteNightMobileNo = c.String(),
                        SiteNightRemarks = c.String(),
                        DocumentId = c.Int(),
                        CreatedIn = c.DateTime(nullable: false),
                        UserCreate = c.String(),
                        LastUpdateDate = c.DateTime(),
                        UserLastUpdate = c.String(),
                        ModeOfPayment_ModeOfPaymentId = c.Int(),
                    })
                .PrimaryKey(t => t.KYCId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.InvoiceDeliveryLocations", t => t.InvoiceDeliveryLocationId)
                .ForeignKey("dbo.ModeOfPayments", t => t.ModeOfPayment_ModeOfPaymentId)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.SalesManId)
                .Index(t => t.InvoiceDeliveryLocationId)
                .Index(t => t.ModeOfPayment_ModeOfPaymentId);
            
            CreateTable(
                "dbo.InvoiceDeliveryLocations",
                c => new
                    {
                        InvoiceDeliveryLocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceDeliveryLocationId);
            
            CreateTable(
                "dbo.KycFiles",
                c => new
                    {
                        KycFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        ValidUntil = c.DateTime(),
                        KYCId = c.Int(),
                    })
                .PrimaryKey(t => t.KycFileId)
                .ForeignKey("dbo.KYCs", t => t.KYCId)
                .Index(t => t.KYCId);
            
            CreateTable(
                "dbo.ModeOfPayments",
                c => new
                    {
                        ModeOfPaymentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KYC_KYCId = c.Int(),
                    })
                .PrimaryKey(t => t.ModeOfPaymentId)
                .ForeignKey("dbo.KYCs", t => t.KYC_KYCId)
                .Index(t => t.KYC_KYCId);
            
            CreateTable(
                "dbo.SalesMen",
                c => new
                    {
                        SalesManId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SalesMan_SalesManId = c.Int(),
                    })
                .PrimaryKey(t => t.SalesManId)
                .ForeignKey("dbo.SalesMen", t => t.SalesMan_SalesManId)
                .Index(t => t.SalesMan_SalesManId);
            
            CreateTable(
                "dbo.Enqueries",
                c => new
                    {
                        EnqueryId = c.Int(nullable: false, identity: true),
                        Sequense = c.Int(nullable: false),
                        Code = c.String(),
                        IsNewCustomer = c.Boolean(nullable: false),
                        HowUCome = c.String(),
                        CustomerId = c.Int(),
                        CustomerName = c.String(),
                        ContactPerson = c.String(),
                        MobileNo = c.String(),
                        TelephoneNo = c.String(),
                        FaxNo = c.String(),
                        EmailId = c.String(),
                        IsNewLocation = c.Boolean(nullable: false),
                        Location = c.String(),
                        SalesManId = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EnqueryId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId)
                .Index(t => t.CustomerId)
                .Index(t => t.SalesManId);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        QuotationId = c.Int(nullable: false, identity: true),
                        QuotationCode = c.Int(nullable: false),
                        CustomerName = c.String(),
                        Code = c.String(),
                        QuotationTypeId = c.Int(),
                        IsRecycables = c.Boolean(nullable: false),
                        QuoteType = c.String(),
                        ContractTypeId = c.Int(nullable: false),
                        ContractDurationId = c.Int(nullable: false),
                        OwnerShipOfSkipId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        KYCId = c.Int(),
                        QuotationDate = c.DateTime(nullable: false),
                        QuotationValidityId = c.Int(nullable: false),
                        Attention = c.String(nullable: false),
                        TelNo = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        MobileNo = c.String(),
                        FaxNo = c.String(),
                        ProjectName = c.String(),
                        SkipLocation = c.String(nullable: false),
                        AreaId = c.Int(),
                        collectionfrequencyGeneral = c.Int(),
                        WasteTypeId = c.Int(nullable: false),
                        WasteDescription = c.String(),
                        TruckTypeId = c.Int(),
                        SkipTypeId = c.Int(nullable: false),
                        SkipType1Id = c.Int(),
                        ProductId = c.Int(nullable: false),
                        CollectionFrequencyId = c.Int(),
                        NoOfSkips = c.Int(nullable: false),
                        ServiceCharges = c.Single(nullable: false),
                        NoOfVisitsRequiered = c.Single(),
                        NoOfVisitsRequieredYearly = c.Single(),
                        MinimumTripsRequiredPerMonth = c.Single(nullable: false),
                        MinimumTripsRequiredPerYear = c.Single(nullable: false),
                        MinimumInvoiceMonthlyRental = c.Single(nullable: false),
                        MinimumInvoiceYearlyRental = c.Single(nullable: false),
                        DMDisposalTippingFeeCharges = c.Single(nullable: false),
                        TippingFee = c.Single(),
                        SecurityDepositAmount = c.Single(nullable: false),
                        PaymentTermId = c.Int(nullable: false),
                        REMARK = c.String(),
                        REMARKInternal = c.String(),
                        IsDailyService = c.Boolean(nullable: false),
                        IsYearlyWeeklyService = c.Boolean(nullable: false),
                        IsYearlyAlternateService = c.Boolean(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        ApprovalDate = c.DateTime(),
                        RestrictSch = c.Boolean(nullable: false),
                        SalesManId = c.Int(nullable: false),
                        QuotationStatusId = c.Int(nullable: false),
                        StatusReason = c.String(),
                        NatureOfBusinessId = c.Int(),
                        EnqueryId = c.Int(),
                        CreateDate = c.DateTime(),
                        UserCreate = c.String(),
                        LastUpdateDate = c.DateTime(),
                        UserLastUpdate = c.String(),
                        Sequense = c.Int(),
                    })
                .PrimaryKey(t => t.QuotationId)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.CollectionFrequencies", t => t.CollectionFrequencyId)
                .ForeignKey("dbo.ContractDurations", t => t.ContractDurationId, cascadeDelete: true)
                .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Enqueries", t => t.EnqueryId)
                .ForeignKey("dbo.KYCs", t => t.KYCId)
                .ForeignKey("dbo.NatureOfBusinesses", t => t.NatureOfBusinessId)
                .ForeignKey("dbo.OwnerShipOfSkips", t => t.OwnerShipOfSkipId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentTerms", t => t.PaymentTermId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.QuotationStatus", t => t.QuotationStatusId, cascadeDelete: true)
                .ForeignKey("dbo.QuotationTypes", t => t.QuotationTypeId)
                .ForeignKey("dbo.QuotationValidities", t => t.QuotationValidityId, cascadeDelete: true)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: true)
                .ForeignKey("dbo.SkipTypes", t => t.SkipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SkipType1", t => t.SkipType1Id)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
                .ForeignKey("dbo.WasteTypes", t => t.WasteTypeId, cascadeDelete: true)
                .Index(t => t.QuotationTypeId)
                .Index(t => t.ContractTypeId)
                .Index(t => t.ContractDurationId)
                .Index(t => t.OwnerShipOfSkipId)
                .Index(t => t.CustomerId)
                .Index(t => t.KYCId)
                .Index(t => t.QuotationValidityId)
                .Index(t => t.AreaId)
                .Index(t => t.WasteTypeId)
                .Index(t => t.TruckTypeId)
                .Index(t => t.SkipTypeId)
                .Index(t => t.SkipType1Id)
                .Index(t => t.ProductId)
                .Index(t => t.CollectionFrequencyId)
                .Index(t => t.PaymentTermId)
                .Index(t => t.SalesManId)
                .Index(t => t.QuotationStatusId)
                .Index(t => t.NatureOfBusinessId)
                .Index(t => t.EnqueryId);
            
            CreateTable(
                "dbo.CollectionFrequencies",
                c => new
                    {
                        CollectionFrequencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CollectionFrequencyId);
            
            CreateTable(
                "dbo.ContractDurations",
                c => new
                    {
                        ContractDurationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ContractDurationId);
            
            CreateTable(
                "dbo.ContractTypes",
                c => new
                    {
                        ContractTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ContractTypeId);
            
            CreateTable(
                "dbo.NatureOfBusinesses",
                c => new
                    {
                        NatureOfBusinessId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NatureOfBusinessId);
            
            CreateTable(
                "dbo.OwnerShipOfSkips",
                c => new
                    {
                        OwnerShipOfSkipId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerShipOfSkipId);
            
            CreateTable(
                "dbo.PaymentTerms",
                c => new
                    {
                        PaymentTermId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentTermId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductKey = c.String(),
                        Name = c.String(),
                        Category_ProductId = c.Int(nullable: false),
                        Unit_ProductId = c.Int(nullable: false),
                        Type_ProductId = c.Int(nullable: false),
                        TruckTypeId = c.Int(),
                        DMLandfillFee = c.Single(),
                        TippingFee = c.Single(),
                        TippingFeeNext = c.Single(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category_Product", t => t.Category_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId)
                .ForeignKey("dbo.Type_Product", t => t.Type_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Unit_Product", t => t.Unit_ProductId, cascadeDelete: true)
                .Index(t => t.Category_ProductId)
                .Index(t => t.Unit_ProductId)
                .Index(t => t.Type_ProductId)
                .Index(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.Category_Product",
                c => new
                    {
                        Category_ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Category_ProductId);
            
            CreateTable(
                "dbo.LPOes",
                c => new
                    {
                        LPOId = c.Int(nullable: false, identity: true),
                        LPONo = c.Int(nullable: false),
                        LPORefNo = c.String(),
                        ContractId = c.Int(),
                        CustomerId = c.Int(),
                        LpoTypeId = c.Int(nullable: false),
                        LpoDate = c.DateTime(),
                        ProductId = c.Int(nullable: false),
                        NoOfSkips = c.Int(nullable: false),
                        AttachedInInvoice = c.Boolean(nullable: false),
                        LPOContactPerson = c.String(),
                        LPOContactNumber = c.String(),
                        LPOContactEmailID = c.String(),
                        Remarks = c.String(),
                        ServiceRequestedQuantity = c.Int(),
                        ServicedActualQty = c.Int(nullable: false),
                        BalanceQty = c.Int(nullable: false),
                        BalanceQtyOnAvailedTrip = c.Int(nullable: false),
                        LpoStartDate = c.DateTime(),
                        LpoEndDate = c.DateTime(),
                        TerminatedDate = c.DateTime(),
                        ExtendedLPOID = c.Int(),
                        ExtendedLPONo = c.Int(),
                        ExtendedLPORefNo = c.String(),
                        LpoStatusId = c.Int(nullable: false),
                        QtyConsumed = c.Int(),
                        SuspendReason = c.String(),
                        SuspendDate = c.DateTime(),
                        TerminatedReason = c.String(),
                        FileName = c.String(),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LPOId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.LpoStatus", t => t.LpoStatusId, cascadeDelete: true)
                .ForeignKey("dbo.LpoTypes", t => t.LpoTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ContractId)
                .Index(t => t.CustomerId)
                .Index(t => t.LpoTypeId)
                .Index(t => t.ProductId)
                .Index(t => t.LpoStatusId);
            
            CreateTable(
                "dbo.Lpofiles",
                c => new
                    {
                        LpofileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        ValidUntil = c.DateTime(),
                        LPOId = c.Int(),
                    })
                .PrimaryKey(t => t.LpofileId)
                .ForeignKey("dbo.LPOes", t => t.LPOId)
                .Index(t => t.LPOId);
            
            CreateTable(
                "dbo.LpoStatus",
                c => new
                    {
                        LpoStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LpoStatusId);
            
            CreateTable(
                "dbo.LpoSuspends",
                c => new
                    {
                        LpoSuspendId = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        SuspendDate = c.DateTime(nullable: false),
                        LpoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LpoSuspendId)
                .ForeignKey("dbo.LPOes", t => t.LpoId, cascadeDelete: true)
                .Index(t => t.LpoId);
            
            CreateTable(
                "dbo.LpoTypes",
                c => new
                    {
                        LpoTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LpoTypeId);
            
            CreateTable(
                "dbo.TruckTypes",
                c => new
                    {
                        TruckTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.Type_Product",
                c => new
                    {
                        Type_ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Type_ProductId);
            
            CreateTable(
                "dbo.Unit_Product",
                c => new
                    {
                        Unit_ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Unit_ProductId);
            
            CreateTable(
                "dbo.QuotationFiles",
                c => new
                    {
                        QuotationFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        QuotationId = c.Int(),
                    })
                .PrimaryKey(t => t.QuotationFileId)
                .ForeignKey("dbo.Quotations", t => t.QuotationId)
                .Index(t => t.QuotationId);
            
            CreateTable(
                "dbo.QuotationStatus",
                c => new
                    {
                        QuotationStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QuotationStatusId);
            
            CreateTable(
                "dbo.QuotationTypes",
                c => new
                    {
                        QuotationTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QuotationTypeId);
            
            CreateTable(
                "dbo.QuotationValidities",
                c => new
                    {
                        QuotationValidityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QuotationValidityId);
            
            CreateTable(
                "dbo.SecurityDeposits",
                c => new
                    {
                        SecurityDepositId = c.Int(nullable: false, identity: true),
                        SecurityDepositAmount = c.Double(nullable: false),
                        SkipDeposit = c.Double(nullable: false),
                        TippingFeeDeposit = c.Double(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        ModeOfPaymentName = c.Int(nullable: false),
                        ChqDate = c.DateTime(),
                        ChqAmount = c.Double(),
                        ChqNo = c.String(),
                        ReceiptNo = c.String(),
                        ReceiptDate = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                        ReceiptFileId = c.Int(),
                        Quotation_QuotationId = c.Int(),
                    })
                .PrimaryKey(t => t.SecurityDepositId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.ReceiptFiles", t => t.ReceiptFileId)
                .ForeignKey("dbo.Quotations", t => t.Quotation_QuotationId)
                .Index(t => t.ContractId)
                .Index(t => t.ReceiptFileId)
                .Index(t => t.Quotation_QuotationId);
            
            CreateTable(
                "dbo.ReceiptFiles",
                c => new
                    {
                        ReceiptFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ReceiptFileId);
            
            CreateTable(
                "dbo.SkipTypes",
                c => new
                    {
                        SkipTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SkipTypeId);
            
            CreateTable(
                "dbo.SkipType1",
                c => new
                    {
                        SkipType1Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SkipType1Id);
            
            CreateTable(
                "dbo.WasteTypes",
                c => new
                    {
                        WasteTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WasteTypeId);
            
            CreateTable(
                "dbo.EnrollmentContractSalesmen",
                c => new
                    {
                        EnrollmentContractSalesmanID = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        SalesManId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EnrollmentContractSalesmanID)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.SalesMen", t => t.SalesManId, cascadeDelete: false)
                .Index(t => t.ContractId)
                .Index(t => t.SalesManId);
            
            CreateTable(
                "dbo.CustomerCallers",
                c => new
                    {
                        CustomerCallerId = c.Int(nullable: false, identity: true),
                        CallerName = c.String(),
                        CallerNymber = c.String(),
                        Email = c.String(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerCallerId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        CustomerGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerGroupCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerGroupId);
            
            CreateTable(
                "dbo.CustomerSalesCategories",
                c => new
                    {
                        CustomerSalesCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerSalesCategoryId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ActualDutyId = c.Int(nullable: false),
                        StartShift = c.DateTime(nullable: false),
                        EndShift = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId)
                .ForeignKey("dbo.ActualDuties", t => t.ActualDutyId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ActualDutyId);
            
            CreateTable(
                "dbo.ActualDuties",
                c => new
                    {
                        ActualDutyId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        ActualDutyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActualDutyId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: false)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Helpers",
                c => new
                    {
                        HelperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HelperId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Area = c.String(),
                        DriverId = c.Int(nullable: false),
                        Helpers = c.String(),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: false)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: false)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.TripSheets",
                c => new
                    {
                        TripSheetId = c.Int(nullable: false, identity: true),
                        TripsDate = c.DateTime(nullable: false),
                        RouteId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Helpers = c.String(),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.TripSheetId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.RouteId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        PlateNo = c.String(),
                        Maker = c.String(),
                        VehicleMakerId = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.VehicleMakers", t => t.VehicleMakerId)
                .Index(t => t.VehicleMakerId);
            
            CreateTable(
                "dbo.VehicleMakers",
                c => new
                    {
                        VehicleMakerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VehicleMakerId);
            
            CreateTable(
                "dbo.VehicleCheckLists",
                c => new
                    {
                        VehicleCheckListId = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        LIGHTSINDICATORS = c.Boolean(nullable: false),
                        ENGINEOILLEVEL = c.Boolean(nullable: false),
                        HYDRAULICOILLEVEL = c.Boolean(nullable: false),
                        REDIATORCOOLENTLEVEL = c.Boolean(nullable: false),
                        WIPERMIRROR = c.Boolean(nullable: false),
                        HYDRAULICFUNCTION = c.Boolean(nullable: false),
                        ALLTYRES = c.Boolean(nullable: false),
                        VEHICLECLEANLINESS = c.Boolean(nullable: false),
                        PPEFIRSTAID = c.Boolean(nullable: false),
                        UNIFORM = c.Boolean(nullable: false),
                        WARNINGTRIANGLE = c.Boolean(nullable: false),
                        TARPAULINE = c.Boolean(nullable: false),
                        BODYDAMAGE = c.Boolean(nullable: false),
                        SEATBELTAC = c.Boolean(nullable: false),
                        TOOLS = c.Boolean(nullable: false),
                        VEHICLEPAPERS = c.Boolean(nullable: false),
                        FIREEXTINGUSHER = c.Boolean(nullable: false),
                        CheckDate = c.DateTime(nullable: false),
                        ActualDutyId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleCheckListId)
                .ForeignKey("dbo.ActualDuties", t => t.ActualDutyId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: false)
                .Index(t => t.ActualDutyId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.TripSheetDeatails_skip",
                c => new
                    {
                        TripSheetDeatails_skipId = c.Int(nullable: false, identity: true),
                        TripSheetDaetailsId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        DoNum = c.String(),
                        SkipSerialNumber = c.String(),
                        Weight = c.String(),
                        Remarks = c.String(),
                        Status = c.Int(nullable: false),
                        ReasonImg = c.String(),
                        SignateImg = c.String(),
                    })
                .PrimaryKey(t => t.TripSheetDeatails_skipId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TripSheetDaetails", t => t.TripSheetDaetailsId, cascadeDelete: false)
                .Index(t => t.TripSheetDaetailsId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.CollectionCanceledDates",
                c => new
                    {
                        CollectionCanceledDateId = c.Int(nullable: false, identity: true),
                        ColectionCanceled_Date = c.DateTime(nullable: false),
                        NumOfSkips = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionCanceledDateId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.CollectionDates",
                c => new
                    {
                        CollectionDateId = c.Int(nullable: false, identity: true),
                        Colection_Date = c.DateTime(nullable: false),
                        NumOfSkips = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        Schedule_ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionDateId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId)
                .Index(t => t.ContractId)
                .Index(t => t.Schedule_ScheduleId);
            
            CreateTable(
                "dbo.CollectionDayMonthlies",
                c => new
                    {
                        CollectionDayMonthlyId = c.Int(nullable: false, identity: true),
                        DayOfMonth = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionDayMonthlyId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.CollectionDays",
                c => new
                    {
                        CollectionDayId = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                        ContractId = c.Int(nullable: false),
                        Schedule_ScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionDayId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId)
                .Index(t => t.ContractId)
                .Index(t => t.Schedule_ScheduleId);
            
            CreateTable(
                "dbo.ContractFiles",
                c => new
                    {
                        ContractFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        ValidUntil = c.DateTime(nullable: false),
                        ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.ContractFileId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.ContractServiceStatus",
                c => new
                    {
                        ContractServiceStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ContractServiceStatusId);
            
            CreateTable(
                "dbo.ContractSkips",
                c => new
                    {
                        ContractSkipId = c.Int(nullable: false, identity: true),
                        SkipSize = c.String(),
                        ProductId = c.Int(nullable: false),
                        SkipSerialNumber = c.String(),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractSkipId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.ContractStatus",
                c => new
                    {
                        ContractStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ContractStatusId);
            
            CreateTable(
                "dbo.DoSheets",
                c => new
                    {
                        DoSheetId = c.Int(nullable: false, identity: true),
                        DoNum = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoSheetId)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false),
                        Text = c.String(),
                        ScheduleType = c.Int(),
                        AlternativeStart = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Contracts", t => t.ScheduleId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Schedule1",
                c => new
                    {
                        Schedule1Id = c.Int(nullable: false),
                        Text = c.String(),
                        ScheduleType = c.Int(),
                        AlternativeStart = c.Int(),
                    })
                .PrimaryKey(t => t.Schedule1Id)
                .ForeignKey("dbo.Contracts", t => t.Schedule1Id)
                .Index(t => t.Schedule1Id);
            
            CreateTable(
                "dbo.ContractConditions",
                c => new
                    {
                        ContractConditionId = c.Int(nullable: false, identity: true),
                        TextCondition = c.String(),
                        TextConditionart2 = c.String(),
                    })
                .PrimaryKey(t => t.ContractConditionId);
            
            CreateTable(
                "dbo.CustomerCodes",
                c => new
                    {
                        CustomerCodeId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CustomerCodeId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.KYCCodes",
                c => new
                    {
                        KYCCodeID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.KYCCodeID);
            
            CreateTable(
                "dbo.HelperActualDuties",
                c => new
                    {
                        Helper_HelperId = c.Int(nullable: false),
                        ActualDuty_ActualDutyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Helper_HelperId, t.ActualDuty_ActualDutyId })
                .ForeignKey("dbo.Helpers", t => t.Helper_HelperId, cascadeDelete: true)
                .ForeignKey("dbo.ActualDuties", t => t.ActualDuty_ActualDutyId, cascadeDelete: true)
                .Index(t => t.Helper_HelperId)
                .Index(t => t.ActualDuty_ActualDutyId);
            
            CreateTable(
                "dbo.RouteHelpers",
                c => new
                    {
                        Route_RouteId = c.Int(nullable: false),
                        Helper_HelperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_RouteId, t.Helper_HelperId })
                .ForeignKey("dbo.Routes", t => t.Route_RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Helpers", t => t.Helper_HelperId, cascadeDelete: true)
                .Index(t => t.Route_RouteId)
                .Index(t => t.Helper_HelperId);
            
            CreateTable(
                "dbo.HelperTripSheetDaetails",
                c => new
                    {
                        Helper_HelperId = c.Int(nullable: false),
                        TripSheetDaetails_TripSheetDaetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Helper_HelperId, t.TripSheetDaetails_TripSheetDaetailsId })
                .ForeignKey("dbo.Helpers", t => t.Helper_HelperId, cascadeDelete: true)
                .ForeignKey("dbo.TripSheetDaetails", t => t.TripSheetDaetails_TripSheetDaetailsId, cascadeDelete: false)
                .Index(t => t.Helper_HelperId)
                .Index(t => t.TripSheetDaetails_TripSheetDaetailsId);
            
            CreateTable(
                "dbo.TripSheetHelpers",
                c => new
                {
                    TripSheet_TripSheetId = c.Int(nullable: false),
                    Helper_HelperId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.TripSheet_TripSheetId, t.Helper_HelperId })
                .ForeignKey("dbo.TripSheets", t => t.TripSheet_TripSheetId, cascadeDelete: true)
                .ForeignKey("dbo.Helpers", t => t.Helper_HelperId, cascadeDelete: false)
                .Index(t => t.TripSheet_TripSheetId)
                .Index(t => t.Helper_HelperId);
                */
            //AddColumn("dbo.Shifts", "TripSheetId", c => c.Int(nullable: false));
            //AddColumn("dbo.TripSheets", "ActualDutyDate", c => c.DateTime());
            //AddColumn("dbo.VehicleCheckLists", "TripSheetId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Shifts", "TripSheetId");
            //CreateIndex("dbo.VehicleCheckLists", "TripSheetId");
            //AddForeignKey("dbo.Shifts", "TripSheetId", "dbo.TripSheets", "TripSheetId", cascadeDelete: false);
            //AddForeignKey("dbo.VehicleCheckLists", "TripSheetId", "dbo.TripSheets", "TripSheetId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule1", "Schedule1Id", "dbo.Contracts");
            DropForeignKey("dbo.Schedules", "ScheduleId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDays", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.CollectionDates", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.CallBaseds", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Contracts", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.DoSheets", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ContractStatusId", "dbo.ContractStatus");
            DropForeignKey("dbo.ContractSkips", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ContractServiceStatusId", "dbo.ContractServiceStatus");
            DropForeignKey("dbo.ContractFiles", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDays", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDayMonthlies", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionDates", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.CollectionCanceledDates", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.TripSheetDeatails_skip", "TripSheetDaetailsId", "dbo.TripSheetDaetails");
            DropForeignKey("dbo.TripSheetDeatails_skip", "ProductId", "dbo.Products");
            DropForeignKey("dbo.TripSheetDaetails", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.TripSheetDaetails", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.VehicleCheckLists", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleCheckLists", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.VehicleCheckLists", "ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.ActualDuties", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Shifts", "ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.ActualDuties", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.HelperTripSheetDaetails", "TripSheetDaetails_TripSheetDaetailsId", "dbo.TripSheetDaetails");
            DropForeignKey("dbo.HelperTripSheetDaetails", "Helper_HelperId", "dbo.Helpers");
            DropForeignKey("dbo.TripSheets", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleMakerId", "dbo.VehicleMakers");
            DropForeignKey("dbo.TripSheetDaetails", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Routes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TripSheets", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.TripSheets", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.RouteHelpers", "Helper_HelperId", "dbo.Helpers");
            DropForeignKey("dbo.RouteHelpers", "Route_RouteId", "dbo.Routes");
            DropForeignKey("dbo.Routes", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Contracts", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Helpers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.HelperActualDuties", "ActualDuty_ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.HelperActualDuties", "Helper_HelperId", "dbo.Helpers");
            DropForeignKey("dbo.ActualDuties", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.CustomerFolderHandlings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Customers", "CustomerSalesCategoryId", "dbo.CustomerSalesCategories");
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerFolderHandlings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCallers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesMen", "SalesMan_SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.KYCs", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.EnrollmentContractSalesmen", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.EnrollmentContractSalesmen", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Enqueries", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.Quotations", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.Contracts", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.Quotations", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.Quotations", "SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.Contracts", "SkipType1Id", "dbo.SkipType1");
            DropForeignKey("dbo.Quotations", "SkipTypeId", "dbo.SkipTypes");
            DropForeignKey("dbo.Contracts", "SkipTypeId", "dbo.SkipTypes");
            DropForeignKey("dbo.SecurityDeposits", "Quotation_QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.SecurityDeposits", "ReceiptFileId", "dbo.ReceiptFiles");
            DropForeignKey("dbo.SecurityDeposits", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Quotations", "SalesManId", "dbo.SalesMen");
            DropForeignKey("dbo.Quotations", "QuotationValidityId", "dbo.QuotationValidities");
            DropForeignKey("dbo.Quotations", "QuotationTypeId", "dbo.QuotationTypes");
            DropForeignKey("dbo.Quotations", "QuotationStatusId", "dbo.QuotationStatus");
            DropForeignKey("dbo.QuotationFiles", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Unit_ProductId", "dbo.Unit_Product");
            DropForeignKey("dbo.Products", "Type_ProductId", "dbo.Type_Product");
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
            DropForeignKey("dbo.Contracts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_ProductId", "dbo.Category_Product");
            DropForeignKey("dbo.Quotations", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Contracts", "PaymentTermId", "dbo.PaymentTerms");
            DropForeignKey("dbo.Quotations", "OwnerShipOfSkipId", "dbo.OwnerShipOfSkips");
            DropForeignKey("dbo.Contracts", "OwnerShipOfSkipId", "dbo.OwnerShipOfSkips");
            DropForeignKey("dbo.Quotations", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
            DropForeignKey("dbo.Contracts", "NatureOfBusinessId", "dbo.NatureOfBusinesses");
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
            DropForeignKey("dbo.Contracts", "CollectionFrequencyId", "dbo.CollectionFrequencies");
            DropForeignKey("dbo.Quotations", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AnnualPaymentTerms", "Quotation_QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Enqueries", "CustomerId", "dbo.Customers");
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
            DropForeignKey("dbo.TripSheetDaetails", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.TripSheetDaetails", "CallBasedId", "dbo.CallBaseds");
            DropForeignKey("dbo.CallBaseds", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.CallBaseds", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.LocationMasters", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Contracts", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.AnnualPaymentTerms", "ContractId", "dbo.Contracts");
            DropIndex("dbo.HelperTripSheetDaetails", new[] { "TripSheetDaetails_TripSheetDaetailsId" });
            DropIndex("dbo.HelperTripSheetDaetails", new[] { "Helper_HelperId" });
            DropIndex("dbo.RouteHelpers", new[] { "Helper_HelperId" });
            DropIndex("dbo.RouteHelpers", new[] { "Route_RouteId" });
            DropIndex("dbo.HelperActualDuties", new[] { "ActualDuty_ActualDutyId" });
            DropIndex("dbo.HelperActualDuties", new[] { "Helper_HelperId" });
            DropIndex("dbo.Schedule1", new[] { "Schedule1Id" });
            DropIndex("dbo.Schedules", new[] { "ScheduleId" });
            DropIndex("dbo.DoSheets", new[] { "ContractId" });
            DropIndex("dbo.ContractSkips", new[] { "ContractId" });
            DropIndex("dbo.ContractFiles", new[] { "ContractId" });
            DropIndex("dbo.CollectionDays", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.CollectionDays", new[] { "ContractId" });
            DropIndex("dbo.CollectionDayMonthlies", new[] { "ContractId" });
            DropIndex("dbo.CollectionDates", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.CollectionDates", new[] { "ContractId" });
            DropIndex("dbo.CollectionCanceledDates", new[] { "ContractId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "ProductId" });
            DropIndex("dbo.TripSheetDeatails_skip", new[] { "TripSheetDaetailsId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "VehicleId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "DriverId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "ActualDutyId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleMakerId" });
            DropIndex("dbo.TripSheets", new[] { "VehicleId" });
            DropIndex("dbo.TripSheets", new[] { "DriverId" });
            DropIndex("dbo.TripSheets", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "VehicleId" });
            DropIndex("dbo.Routes", new[] { "DriverId" });
            DropIndex("dbo.Helpers", new[] { "EmployeeId" });
            DropIndex("dbo.ActualDuties", new[] { "VehicleId" });
            DropIndex("dbo.ActualDuties", new[] { "DriverId" });
            DropIndex("dbo.ActualDuties", new[] { "RouteId" });
            DropIndex("dbo.Shifts", new[] { "ActualDutyId" });
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerCallers", new[] { "CustomerId" });
            DropIndex("dbo.EnrollmentContractSalesmen", new[] { "SalesManId" });
            DropIndex("dbo.EnrollmentContractSalesmen", new[] { "ContractId" });
            DropIndex("dbo.SecurityDeposits", new[] { "Quotation_QuotationId" });
            DropIndex("dbo.SecurityDeposits", new[] { "ReceiptFileId" });
            DropIndex("dbo.SecurityDeposits", new[] { "ContractId" });
            DropIndex("dbo.QuotationFiles", new[] { "QuotationId" });
            DropIndex("dbo.LpoSuspends", new[] { "LpoId" });
            DropIndex("dbo.Lpofiles", new[] { "LPOId" });
            DropIndex("dbo.LPOes", new[] { "LpoStatusId" });
            DropIndex("dbo.LPOes", new[] { "ProductId" });
            DropIndex("dbo.LPOes", new[] { "LpoTypeId" });
            DropIndex("dbo.LPOes", new[] { "CustomerId" });
            DropIndex("dbo.LPOes", new[] { "ContractId" });
            DropIndex("dbo.Products", new[] { "TruckTypeId" });
            DropIndex("dbo.Products", new[] { "Type_ProductId" });
            DropIndex("dbo.Products", new[] { "Unit_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_ProductId" });
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
            DropIndex("dbo.Enqueries", new[] { "SalesManId" });
            DropIndex("dbo.Enqueries", new[] { "CustomerId" });
            DropIndex("dbo.SalesMen", new[] { "SalesMan_SalesManId" });
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
            DropIndex("dbo.Customers", new[] { "CustomerGroupId" });
            DropIndex("dbo.CustomerFolderHandlings", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerFolderHandlings", new[] { "CustomerId" });
            DropIndex("dbo.Drivers", new[] { "EmployeeId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "CallBasedId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ServiceTypeId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "VehicleId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "DriverId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ProductId" });
            DropIndex("dbo.TripSheetDaetails", new[] { "ContractId" });
            DropIndex("dbo.CallBaseds", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.CallBaseds", new[] { "ServiceTypeId" });
            DropIndex("dbo.CallBaseds", new[] { "ContractId" });
            DropIndex("dbo.LocationMasters", new[] { "AreaId" });
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
            DropIndex("dbo.AnnualPaymentTerms", new[] { "Quotation_QuotationId" });
            DropIndex("dbo.AnnualPaymentTerms", new[] { "ContractId" });
            DropTable("dbo.HelperTripSheetDaetails");
            DropTable("dbo.RouteHelpers");
            DropTable("dbo.HelperActualDuties");
            DropTable("dbo.KYCCodes");
            DropTable("dbo.Jobs");
            DropTable("dbo.CustomerCodes");
            DropTable("dbo.ContractConditions");
            DropTable("dbo.Schedule1");
            DropTable("dbo.Schedules");
            DropTable("dbo.DoSheets");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.ContractSkips");
            DropTable("dbo.ContractServiceStatus");
            DropTable("dbo.ContractFiles");
            DropTable("dbo.CollectionDays");
            DropTable("dbo.CollectionDayMonthlies");
            DropTable("dbo.CollectionDates");
            DropTable("dbo.CollectionCanceledDates");
            DropTable("dbo.TripSheetDeatails_skip");
            DropTable("dbo.VehicleCheckLists");
            DropTable("dbo.VehicleMakers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.TripSheets");
            DropTable("dbo.Routes");
            DropTable("dbo.Helpers");
            DropTable("dbo.ActualDuties");
            DropTable("dbo.Shifts");
            DropTable("dbo.CustomerSalesCategories");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.CustomerCallers");
            DropTable("dbo.EnrollmentContractSalesmen");
            DropTable("dbo.WasteTypes");
            DropTable("dbo.SkipType1");
            DropTable("dbo.SkipTypes");
            DropTable("dbo.ReceiptFiles");
            DropTable("dbo.SecurityDeposits");
            DropTable("dbo.QuotationValidities");
            DropTable("dbo.QuotationTypes");
            DropTable("dbo.QuotationStatus");
            DropTable("dbo.QuotationFiles");
            DropTable("dbo.Unit_Product");
            DropTable("dbo.Type_Product");
            DropTable("dbo.TruckTypes");
            DropTable("dbo.LpoTypes");
            DropTable("dbo.LpoSuspends");
            DropTable("dbo.LpoStatus");
            DropTable("dbo.Lpofiles");
            DropTable("dbo.LPOes");
            DropTable("dbo.Category_Product");
            DropTable("dbo.Products");
            DropTable("dbo.PaymentTerms");
            DropTable("dbo.OwnerShipOfSkips");
            DropTable("dbo.NatureOfBusinesses");
            DropTable("dbo.ContractTypes");
            DropTable("dbo.ContractDurations");
            DropTable("dbo.CollectionFrequencies");
            DropTable("dbo.Quotations");
            DropTable("dbo.Enqueries");
            DropTable("dbo.SalesMen");
            DropTable("dbo.ModeOfPayments");
            DropTable("dbo.KycFiles");
            DropTable("dbo.InvoiceDeliveryLocations");
            DropTable("dbo.KYCs");
            DropTable("dbo.CustomerFileTypes");
            DropTable("dbo.CustomerFiles");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerFolderHandlings");
            DropTable("dbo.Employees");
            DropTable("dbo.Drivers");
            DropTable("dbo.TripSheetDaetails");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.CallBaseds");
            DropTable("dbo.LocationMasters");
            DropTable("dbo.Areas");
            DropTable("dbo.Contracts");
            DropTable("dbo.AnnualPaymentTerms");
        }
    }
}
