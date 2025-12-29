using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample;

public static class SampleDataGenerator
{
    public static StandardTaxInvoiceModel GetSampleTaxInvoice()
    {
        return new StandardTaxInvoiceModel
        {
            TaxInvoiceNumber = "TAX-2025-00789",
            InvoiceDate = DateTime.Now,
            SupplyDate = DateTime.Now.AddDays(-2),
            PurchaseOrderNumber = "PO-12345",
            PaymentTerms = "Net 30 Days",

            Seller = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                CompanyNameArabic = "شركة حلول التكنولوجيا الخليجية",
                VATRegistrationNumber = "BH100234567800003",
                CommercialRegistrationNumber = "123456-1",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "accounts@gulftech.com.bh",
                Fax = "+973 1729 8889"
            },

            Customer = new CompanyInfo
            {
                CompanyName = "Bahrain Trading Company B.S.C.",
                CompanyNameArabic = "شركة البحرين للتجارة",
                VATRegistrationNumber = "BH100987654300002",
                CommercialRegistrationNumber = "654321-2",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666",
                Email = "procurement@bahraintrading.bh"
            },

            Items = new List<TaxInvoiceItem>
            {
                new() { ItemNo = 1, Description = "Enterprise Software License - Annual Subscription", HSNCode = "852351", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 2850.000m, DiscountPercent = 5, VATPercent = 10 },
                new() { ItemNo = 2, Description = "Professional Implementation Services", HSNCode = "998314", Quantity = 80, UnitOfMeasure = "Hours", UnitPrice = 65.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 3, Description = "Cloud Infrastructure Hosting - Premium Tier", HSNCode = "998315", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 450.000m, DiscountPercent = 10, VATPercent = 10 },
                new() { ItemNo = 4, Description = "Custom Module Development", HSNCode = "998314", Quantity = 120, UnitOfMeasure = "Hours", UnitPrice = 85.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 5, Description = "Premium Support Package - 24/7 Technical Support", HSNCode = "998316", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 550.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 6, Description = "Security Audit and Penetration Testing", HSNCode = "998317", Quantity = 2, UnitOfMeasure = "Service", UnitPrice = 1800.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 7, Description = "Mobile Application Development - iOS and Android", HSNCode = "998314", Quantity = 1, UnitOfMeasure = "Project", UnitPrice = 8500.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 8, Description = "Data Analytics and Business Intelligence Tools", HSNCode = "852351", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 1200.000m, DiscountPercent = 8, VATPercent = 10 },
                new() { ItemNo = 9, Description = "API Gateway and Microservices Architecture Setup", HSNCode = "998314", Quantity = 60, UnitOfMeasure = "Hours", UnitPrice = 95.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 10, Description = "Database Optimization and Performance Tuning", HSNCode = "998314", Quantity = 40, UnitOfMeasure = "Hours", UnitPrice = 75.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 11, Description = "DevOps and CI/CD Pipeline Setup", HSNCode = "998315", Quantity = 1, UnitOfMeasure = "Project", UnitPrice = 4500.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 12, Description = "Training and Knowledge Transfer Sessions", HSNCode = "998318", Quantity = 20, UnitOfMeasure = "Hours", UnitPrice = 120.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 13, Description = "Documentation Services - Technical and User Manuals", HSNCode = "998319", Quantity = 1, UnitOfMeasure = "Package", UnitPrice = 2200.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 14, Description = "Third-party Software Licenses", HSNCode = "852351", Quantity = 8, UnitOfMeasure = "License", UnitPrice = 650.000m, DiscountPercent = 5, VATPercent = 10 },
                new() { ItemNo = 15, Description = "Ongoing Maintenance and Software Updates", HSNCode = "998316", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 850.000m, DiscountPercent = 10, VATPercent = 10 }
            },

            BankDetails = new BankDetails
            {
                BankName = "National Bank of Bahrain B.S.C.",
                AccountName = "Gulf Technology Solutions W.L.L.",
                AccountNumber = "0123456789",
                IBAN = "BH67 NBOB 0000 1234 5678 90",
                SwiftCode = "NBOBBBMX",
                Branch = "Diplomatic Area Branch, Manama"
            },

            TermsAndConditions = "1. Payment is due within 30 days from the invoice date.\n2. Late payments will incur a charge of 2% per month.\n3. All prices are in Bahraini Dinars (BHD) and include VAT as applicable.\n4. Services are provided as per the signed agreement dated 15-Sep-2025.\n5. Any disputes are subject to the jurisdiction of Bahrain courts.",

            Notes = "Thank you for your business! For any queries regarding this invoice, please contact our accounts department at accounts@gulftech.com.bh or call +973 1729 8888. Reference this invoice number (TAX-2025-00789) in all communications."
        };
    }

    public static ReceiptModel GetSampleReceipt()
    {
        return new ReceiptModel
        {
            ReceiptNumber = "RCP-2025-00456",
            ReceiptDate = DateTime.Now,
            PaymentMethod = "Bank Transfer",
            ReferenceNumber = "TXN-987654321",
            RelatedInvoiceNumber = "TAX-2025-00789",

            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "accounts@gulftech.com.bh"
            },

            Customer = new CustomerInfo
            {
                Name = "Ahmed Al-Khalifa",
                CompanyName = "Bahrain Trading Company B.S.C.",
                Address = "Building 1122, Road 3315, Block 433, Manama",
                Phone = "+973 1755 6666",
                Email = "ahmed@bahraintrading.bh",
                VATNumber = "BH100987654300002"
            },

            Items = new List<ReceiptItem>
            {
                new() { ItemNo = 1, Description = "Payment for Invoice TAX-2025-00789", Amount = 45500.000m },
                new() { ItemNo = 2, Description = "Advance Payment for Next Month Services", Amount = 5000.000m }
            },

            Notes = "Payment received in full. Thank you for your prompt payment!",
            ReceivedBy = "Sara Mohammed - Accounts Manager"
        };
    }

    public static PurchaseOrderModel GetSamplePurchaseOrder()
    {
        return new PurchaseOrderModel
        {
            PONumber = "PO-2025-1234",
            PODate = DateTime.Now,
            RequiredDate = DateTime.Now.AddDays(30),
            DeliveryTerms = "DDP - Delivered Duty Paid",
            PaymentTerms = "50% advance, 50% on delivery",
            ShippingMethod = "Express Courier",

            Buyer = new CompanyInfo
            {
                CompanyName = "Bahrain Trading Company B.S.C.",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666",
                Email = "procurement@bahraintrading.bh",
                VATRegistrationNumber = "BH100987654300002"
            },

            Supplier = new CompanyInfo
            {
                CompanyName = "Global Tech Supplies Ltd.",
                Address = "Silicon Valley Tech Park, Building 5",
                City = "Dubai",
                Country = "United Arab Emirates",
                Phone = "+971 4 123 4567",
                Email = "sales@globaltechsupplies.ae",
                VATRegistrationNumber = "AE123456789000001"
            },

            ShipTo = new ShippingAddress
            {
                AttentionTo = "Ahmed Al-Khalifa - IT Manager",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666"
            },

            Items = new List<PurchaseOrderItem>
            {
                new() { ItemNo = 1, ItemCode = "SRV-HP-DL380", Description = "HP ProLiant DL380 Gen11 Server - 32GB RAM, 2TB SSD", Quantity = 5, UnitOfMeasure = "Unit", UnitPrice = 4500.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(20) },
                new() { ItemNo = 2, ItemCode = "SW-VMWARE-VSPHERE", Description = "VMware vSphere Enterprise Plus License", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 3200.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(5) },
                new() { ItemNo = 3, ItemCode = "NET-CISCO-SW48", Description = "Cisco Catalyst 9300 48-Port Switch", Quantity = 2, UnitOfMeasure = "Unit", UnitPrice = 5800.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(15) },
                new() { ItemNo = 4, ItemCode = "STG-DELL-SAN", Description = "Dell PowerStore 500T Storage Array", Quantity = 1, UnitOfMeasure = "Unit", UnitPrice = 28000.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(25) },
                new() { ItemNo = 5, ItemCode = "UPS-APC-10KVA", Description = "APC Smart-UPS 10KVA Rack-Mount with Battery Pack", Quantity = 3, UnitOfMeasure = "Unit", UnitPrice = 3500.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(10) },
                new() { ItemNo = 6, ItemCode = "RACK-42U-STD", Description = "42U Server Rack Cabinet with PDU", Quantity = 2, UnitOfMeasure = "Unit", UnitPrice = 1200.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(12) },
                new() { ItemNo = 7, ItemCode = "SRV-INST", Description = "Professional Installation & Configuration Services", Quantity = 40, UnitOfMeasure = "Hours", UnitPrice = 150.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(30) }
            },

            SpecialInstructions = "1. All equipment must be brand new with manufacturer warranty\n2. Installation to be coordinated with IT team 2 weeks in advance\n3. Deliver between 8 AM - 4 PM on weekdays only\n4. Supplier to provide training for 2 IT staff members",

            TermsAndConditions = "1. Prices are fixed and valid for 60 days from PO date\n2. Supplier must provide delivery schedule within 5 business days\n3. Any delays must be communicated immediately\n4. Goods remain property of supplier until full payment received",

            PreparedBy = "Ahmed Al-Khalifa - IT Manager",
            ApprovedBy = "Mohammed Al-Mansoori - CFO"
        };
    }

    public static DynamicColumnReportModel GetSampleDynamicColumnReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "Regional Sales Performance Report",
            ReportSubtitle = "Quarterly Revenue by Product Category (2025)",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Sarah Ahmed - Analytics Manager",
            
            ColumnHeaders = new List<string>
            {
                "Q1 2025",
                "Q2 2025",
                "Q3 2025",
                "Q4 2025",
                "Total",
                "YoY Growth"
            },
            
            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "Electronics", Values = new List<string> { "285,450", "312,800", "298,600", "425,900", "1,322,750", "+18.5%" } },
                new() { RowLabel = "Home Appliances", Values = new List<string> { "156,200", "178,500", "165,300", "245,800", "745,800", "+12.3%" } },
                new() { RowLabel = "Computing", Values = new List<string> { "425,600", "468,900", "512,300", "598,700", "2,005,500", "+22.7%" } },
                new() { RowLabel = "Mobile Devices", Values = new List<string> { "512,800", "545,200", "587,400", "689,500", "2,334,900", "+15.8%" } },
                new() { RowLabel = "Accessories", Values = new List<string> { "98,500", "112,300", "125,600", "156,800", "493,200", "+28.4%" }, IsHighlighted = true },
                new() { RowLabel = "Gaming", Values = new List<string> { "245,600", "278,900", "312,500", "389,200", "1,226,200", "+31.2%" }, IsHighlighted = true },
                new() { RowLabel = "Smart Home", Values = new List<string> { "134,500", "156,800", "178,900", "212,400", "682,600", "+24.6%" } },
                new() { RowLabel = "Audio Equipment", Values = new List<string> { "89,200", "95,600", "102,300", "128,900", "416,000", "+9.8%" } }
            },
            
            SummaryRow = new DynamicDataRow
            {
                RowLabel = "GRAND TOTAL",
                Values = new List<string> { "1,947,850", "2,149,000", "2,282,900", "2,847,200", "9,226,950", "+19.4%" }
            },
            
            FooterNotes = "All figures in BHD (Bahraini Dinars). YoY Growth calculated against previous year same period. Highlighted rows indicate categories exceeding 25% growth target."
        };
    }

    public static ProductCatalogModel GetSampleProductCatalog()
    {
        return new ProductCatalogModel
        {
            CatalogTitle = "PREMIUM TECHNOLOGY PRODUCTS CATALOG",
            Season = "Summer",
            Year = 2025,
            ValidUntil = DateTime.Now.AddMonths(6),
            
            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "sales@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003"
            },
            
            Categories = new List<ProductCategory>
            {
                new()
                {
                    CategoryName = "Enterprise Servers",
                    Description = "High-performance server solutions for business-critical applications",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "SRV-HP-DL380", ProductName = "HP ProLiant DL380 Gen11", Description = "2U Rack Server with dual Intel Xeon processors", Specifications = "32GB RAM, 2TB SSD, Redundant PSU", ListPrice = 4500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "3-5 days" },
                        new() { ProductCode = "SRV-DELL-R750", ProductName = "Dell PowerEdge R750", Description = "Next-gen 2U rack server for demanding workloads", Specifications = "64GB RAM, 4TB NVMe, RAID Controller", ListPrice = 5800.00m, DiscountPrice = 5200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "2-4 days" },
                        new() { ProductCode = "SRV-IBM-X3650", ProductName = "IBM System x3650 M5", Description = "Versatile 2U rack server with enterprise features", Specifications = "128GB RAM, 6TB Storage, Hot-swap drives", ListPrice = 6200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "On Order", LeadTime = "10-15 days" }
                    }
                },
                new()
                {
                    CategoryName = "Network Equipment",
                    Description = "Professional networking hardware for reliable connectivity",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "NET-CISCO-SW48", ProductName = "Cisco Catalyst 9300 48-Port", Description = "Enterprise-grade managed switch", Specifications = "48x 1GbE ports, 4x 10GbE uplinks, PoE+", ListPrice = 5800.00m, DiscountPrice = 5400.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-3 days" },
                        new() { ProductCode = "NET-HP-SW24", ProductName = "HP Aruba 2930F 24-Port", Description = "Layer 3 managed switch with advanced features", Specifications = "24x 1GbE + 4x SFP+, Stacking capable", ListPrice = 2400.00m, Unit = "Unit", MinOrderQuantity = 2, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" },
                        new() { ProductCode = "NET-UBNT-DREAM", ProductName = "Ubiquiti Dream Machine Pro", Description = "All-in-one enterprise gateway and controller", Specifications = "8-port PoE switch, IDS/IPS, UniFi controller", ListPrice = 450.00m, DiscountPrice = 399.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" }
                    }
                },
                new()
                {
                    CategoryName = "Storage Solutions",
                    Description = "Scalable storage systems for data-intensive operations",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "STG-DELL-SAN", ProductName = "Dell PowerStore 500T", Description = "Next-gen midrange storage array", Specifications = "All-flash, 100TB usable, dual controllers", ListPrice = 28000.00m, DiscountPrice = 25500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "On Order", LeadTime = "20-30 days" },
                        new() { ProductCode = "STG-QNAP-NAS", ProductName = "QNAP TS-h1283XU-RP", Description = "High-performance rackmount NAS", Specifications = "12-bay, 10GbE, 32GB RAM, redundant PSU", ListPrice = 3200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "5-7 days" },
                        new() { ProductCode = "STG-SYNOLOGY-SA", ProductName = "Synology SA3600", Description = "Enterprise NAS with high availability", Specifications = "12-bay, dual controller, 64GB RAM", ListPrice = 4500.00m, DiscountPrice = 4200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "3-5 days" }
                    }
                },
                new()
                {
                    CategoryName = "Backup & UPS",
                    Description = "Power protection and backup solutions",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "UPS-APC-10KVA", ProductName = "APC Smart-UPS SRT 10KVA", Description = "Double-conversion online UPS", Specifications = "10KVA/10KW, rack-mount 6U, LCD display", ListPrice = 3500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "2-4 days" },
                        new() { ProductCode = "UPS-EATON-5P", ProductName = "Eaton 5P 3000VA Rack", Description = "Line-interactive UPS for IT equipment", Specifications = "3000VA/2700W, 2U rack, hot-swap batteries", ListPrice = 850.00m, DiscountPrice = 799.00m, Unit = "Unit", MinOrderQuantity = 2, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" },
                        new() { ProductCode = "UPS-CYBERPOWER", ProductName = "CyberPower OR2200LCDRTXL2U", Description = "Smart App LCD UPS", Specifications = "2200VA/1600W, 2U rack, sine wave output", ListPrice = 425.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-3 days" }
                    }
                }
            },
            
            TermsAndConditions = "TERMS AND CONDITIONS:\n\n" +
                "1. PRICING: All prices are in Bahraini Dinars (BHD) and exclude VAT unless stated otherwise. Prices are valid until the date specified on the catalog cover.\n\n" +
                "2. MINIMUM ORDER: Minimum order quantities (MOQ) apply as specified per product. Orders below MOQ may incur additional charges.\n\n" +
                "3. PAYMENT TERMS: Standard payment terms are 50% advance and 50% upon delivery. Credit terms available for approved customers.\n\n" +
                "4. DELIVERY: Lead times are estimates and may vary based on stock availability. Express delivery available at additional cost.\n\n" +
                "5. WARRANTY: All products carry manufacturer warranty. Extended warranty options available upon request.\n\n" +
                "6. RETURNS: Returns accepted within 14 days for unopened items in original packaging. Restocking fee may apply.\n\n" +
                "7. TECHNICAL SUPPORT: Pre-sales consultation and post-sales technical support included. Professional installation services available.\n\n" +
                "8. RESERVATION OF RIGHTS: We reserve the right to modify prices, specifications, and availability without prior notice.\n\n" +
                "For inquiries, bulk orders, or custom quotations, please contact our sales team at sales@gulftech.com.bh or call +973 1729 8888."
        };
    }

    public static EmployeeReportModel GetSampleEmployeeReport()
    {
        return new EmployeeReportModel
        {
            ReportTitle = "Monthly Employee Performance & Attendance Report",
            Department = "Information Technology Department",
            ReportDate = DateTime.Now,
            ReportingPeriod = "October 2025",
            
            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "hr@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003"
            },
            
            Employees = new List<EmployeeRecord>
            {
                new() { EmployeeId = "EMP001", FullName = "Ahmed Al-Khalifa", Position = "Senior System Administrator", JoinDate = new DateTime(2020, 3, 15), Email = "ahmed.k@gulftech.bh", Phone = "+973 3312 4567", MonthlySalary = 1800m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP002", FullName = "Sarah Mohammed", Position = "Software Developer", JoinDate = new DateTime(2021, 6, 1), Email = "sarah.m@gulftech.bh", Phone = "+973 3345 6789", MonthlySalary = 1500m, WorkingDays = 20, LeaveDays = 2, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP003", FullName = "Mohammed Al-Mansoori", Position = "Network Engineer", JoinDate = new DateTime(2019, 1, 10), Email = "mohammed.a@gulftech.bh", Phone = "+973 3398 7654", MonthlySalary = 1650m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP004", FullName = "Fatima Hassan", Position = "Database Administrator", JoinDate = new DateTime(2022, 9, 5), Email = "fatima.h@gulftech.bh", Phone = "+973 3356 4321", MonthlySalary = 1400m, WorkingDays = 21, LeaveDays = 1, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP005", FullName = "Khalid Ibrahim", Position = "IT Support Specialist", JoinDate = new DateTime(2023, 2, 20), Email = "khalid.i@gulftech.bh", Phone = "+973 3334 5678", MonthlySalary = 950m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP006", FullName = "Noora Ali", Position = "Security Analyst", JoinDate = new DateTime(2021, 11, 8), Email = "noora.a@gulftech.bh", Phone = "+973 3367 8901", MonthlySalary = 1550m, WorkingDays = 19, LeaveDays = 3, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP007", FullName = "Hamad Yousif", Position = "DevOps Engineer", JoinDate = new DateTime(2020, 7, 12), Email = "hamad.y@gulftech.bh", Phone = "+973 3389 0123", MonthlySalary = 1700m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP008", FullName = "Mariam Abdullah", Position = "Junior Developer", JoinDate = new DateTime(2024, 1, 15), Email = "mariam.a@gulftech.bh", Phone = "+973 3323 4567", MonthlySalary = 850m, WorkingDays = 21, LeaveDays = 1, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP009", FullName = "Ali Salman", Position = "IT Manager", JoinDate = new DateTime(2018, 4, 1), Email = "ali.s@gulftech.bh", Phone = "+973 3345 6789", MonthlySalary = 2200m, WorkingDays = 20, LeaveDays = 2, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP010", FullName = "Aysha Jamal", Position = "Cloud Architect", JoinDate = new DateTime(2021, 3, 22), Email = "aysha.j@gulftech.bh", Phone = "+973 3378 9012", MonthlySalary = 1900m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" }
            },
            
            Summary = new EmployeeSummary
            {
                TotalEmployees = 10,
                ActiveEmployees = 10,
                OnLeaveEmployees = 0,
                TotalSalaryExpense = 15500m,
                AverageSalary = 1550m
            },
            
            Remarks = "Overall department performance has been excellent this month. All critical projects are on schedule. Team collaboration and productivity metrics show positive trends. Continue monitoring the new junior developers' progress and provide necessary mentoring support.",
            
            PreparedBy = "Layla Ahmed - HR Manager",
            ReviewedBy = "Rashid Al-Khater - Head of IT"
        };
    }

    public static DynamicColumnReportModel GetSampleAttendanceReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "Employee Attendance Report",
            ReportSubtitle = "Daily Attendance Tracking - October 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Layla Ahmed - HR Manager",
            
            ColumnHeaders = new List<string>
            {
                "Oct 1", "Oct 2", "Oct 3", "Oct 4", "Oct 5", "Oct 8", "Oct 9", "Oct 10", "Oct 11", "Oct 12",
                "Present Days", "Absent Days", "Late Days", "Attendance %"
            },
            
            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "Ahmed Al-Khalifa", Values = new List<string> { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P", "10", "0", "0", "100%" } },
                new() { RowLabel = "Sarah Mohammed", Values = new List<string> { "P", "P", "A", "P", "P", "P", "P", "P", "P", "P", "9", "1", "0", "90%" } },
                new() { RowLabel = "Mohammed Al-Mansoori", Values = new List<string> { "P", "P", "P", "L", "P", "P", "P", "P", "P", "P", "10", "0", "1", "100%" } },
                new() { RowLabel = "Fatima Hassan", Values = new List<string> { "P", "P", "P", "P", "P", "P", "P", "A", "P", "P", "9", "1", "0", "90%" } },
                new() { RowLabel = "Khalid Ibrahim", Values = new List<string> { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P", "10", "0", "0", "100%" } },
                new() { RowLabel = "Noora Ali", Values = new List<string> { "P", "A", "P", "P", "P", "P", "L", "P", "P", "P", "9", "1", "1", "90%" } },
                new() { RowLabel = "Hamad Yousif", Values = new List<string> { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P", "10", "0", "0", "100%" } },
                new() { RowLabel = "Mariam Abdullah", Values = new List<string> { "P", "P", "P", "P", "L", "P", "P", "P", "P", "P", "10", "0", "1", "100%" } },
                new() { RowLabel = "Ali Salman", Values = new List<string> { "P", "P", "P", "P", "P", "A", "P", "P", "P", "P", "9", "1", "0", "90%" } },
                new() { RowLabel = "Aysha Jamal", Values = new List<string> { "P", "P", "P", "P", "P", "P", "P", "P", "P", "P", "10", "0", "0", "100%" } }
            },
            
            SummaryRow = new DynamicDataRow
            {
                RowLabel = "DEPARTMENT TOTAL",
                Values = new List<string> { "10", "9", "9", "9", "9", "9", "9", "9", "10", "10", "96", "4", "3", "96%" }
            },
            
            FooterNotes = "P = Present, A = Absent, L = Late (after 9:00 AM). Weekend days (Oct 6, 7) excluded. Department target attendance: 95%."
        };
    }

    public static DynamicColumnReportModel GetSampleAssetsReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "IT Assets Distribution Report",
            ReportSubtitle = "Asset Count by Location and Status - October 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Khalid Ibrahim - IT Support Specialist",
            
            ColumnHeaders = new List<string>
            {
                "Head Office", "Branch 1", "Branch 2", "Warehouse", "Remote", "Total Assets", "Active", "Maintenance", "Retired"
            },
            
            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "Desktop Computers", Values = new List<string> { "45", "12", "8", "2", "15", "82", "78", "3", "1" } },
                new() { RowLabel = "Laptops", Values = new List<string> { "28", "8", "6", "0", "25", "67", "65", "2", "0" } },
                new() { RowLabel = "Servers", Values = new List<string> { "15", "2", "1", "3", "0", "21", "19", "2", "0" } },
                new() { RowLabel = "Network Switches", Values = new List<string> { "8", "3", "2", "1", "0", "14", "14", "0", "0" } },
                new() { RowLabel = "Printers", Values = new List<string> { "12", "4", "3", "1", "2", "22", "20", "1", "1" } },
                new() { RowLabel = "Monitors", Values = new List<string> { "65", "18", "12", "5", "20", "120", "115", "4", "1" } },
                new() { RowLabel = "UPS Units", Values = new List<string> { "25", "6", "4", "8", "3", "46", "44", "2", "0" } },
                new() { RowLabel = "Mobile Devices", Values = new List<string> { "35", "8", "6", "0", "12", "61", "58", "2", "1" }, IsHighlighted = true },
                new() { RowLabel = "Storage Arrays", Values = new List<string> { "5", "1", "0", "2", "0", "8", "7", "1", "0" } },
                new() { RowLabel = "Backup Devices", Values = new List<string> { "8", "2", "1", "4", "0", "15", "14", "1", "0" } }
            },
            
            SummaryRow = new DynamicDataRow
            {
                RowLabel = "TOTAL ASSETS",
                Values = new List<string> { "246", "64", "43", "26", "77", "456", "434", "18", "4" }
            },
            
            FooterNotes = "Asset status: Active (in use), Maintenance (under repair/upgrade), Retired (end of life). Mobile devices highlighted due to high remote usage. Next audit scheduled: November 15, 2025."
        };
    }

    public static DynamicColumnReportModel GetSampleBudgetAnalysisReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "IT Department Budget vs Actual Analysis",
            ReportSubtitle = "Monthly Budget Performance - 2025 (in BHD)",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Ali Salman - IT Manager",
            
            ColumnHeaders = new List<string>
            {
                "Budget", "Jan Actual", "Feb Actual", "Mar Actual", "Apr Actual", "May Actual", "Jun Actual", "YTD Actual", "Variance", "% Used"
            },
            
            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "Hardware Purchases", Values = new List<string> { "50,000", "4,200", "3,800", "8,500", "2,100", "6,200", "4,800", "29,600", "20,400", "59%" } },
                new() { RowLabel = "Software Licenses", Values = new List<string> { "25,000", "2,100", "1,800", "2,200", "1,900", "2,300", "2,000", "12,300", "12,700", "49%" } },
                new() { RowLabel = "Cloud Services", Values = new List<string> { "18,000", "1,450", "1,520", "1,680", "1,720", "1,850", "1,900", "10,120", "7,880", "56%" } },
                new() { RowLabel = "Maintenance Contracts", Values = new List<string> { "15,000", "1,200", "1,200", "1,350", "1,200", "1,400", "1,200", "7,550", "7,450", "50%" } },
                new() { RowLabel = "Training & Certification", Values = new List<string> { "8,000", "650", "0", "1,200", "800", "0", "950", "3,600", "4,400", "45%" } },
                new() { RowLabel = "Telecommunications", Values = new List<string> { "12,000", "980", "1,020", "1,050", "1,100", "1,080", "1,150", "6,380", "5,620", "53%" } },
                new() { RowLabel = "Security Solutions", Values = new List<string> { "20,000", "1,800", "1,600", "2,200", "1,500", "2,100", "1,900", "11,100", "8,900", "56%" } },
                new() { RowLabel = "Backup & Recovery", Values = new List<string> { "10,000", "800", "750", "900", "850", "950", "800", "5,050", "4,950", "51%" }, IsHighlighted = true },
                new() { RowLabel = "Professional Services", Values = new List<string> { "22,000", "2,200", "1,800", "2,500", "1,900", "2,800", "2,200", "13,400", "8,600", "61%" }, IsHighlighted = true },
                new() { RowLabel = "Miscellaneous", Values = new List<string> { "5,000", "320", "280", "450", "380", "420", "350", "2,200", "2,800", "44%" } }
            },
            
            SummaryRow = new DynamicDataRow
            {
                RowLabel = "TOTAL BUDGET",
                Values = new List<string> { "185,000", "15,700", "14,770", "22,030", "13,450", "19,100", "17,250", "102,300", "82,700", "55%" }
            },
            
            FooterNotes = "Budget utilization at 55% by mid-year is on track. Highlighted categories show higher than expected spending. Professional Services over-budget due to emergency security audit. Backup & Recovery under-budget - consider additional investments."
        };
    }

    public static DynamicColumnReportModel GetSampleProjectTimelineReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "Active Projects Timeline & Status Report",
            ReportSubtitle = "Project Milestones and Progress Tracking - Q4 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Ali Salman - IT Manager",

            ColumnHeaders = new List<string>
            {
                "Planning", "Design", "Development", "Testing", "Deployment", "Go-Live", "Progress %", "Status", "Risk Level"
            },

            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "ERP System Upgrade", Values = new List<string> { "✓", "✓", "✓", "In Progress", "Pending", "Dec 15", "75%", "On Track", "Low" } },
                new() { RowLabel = "Mobile App Development", Values = new List<string> { "✓", "✓", "In Progress", "Pending", "Pending", "Jan 30", "45%", "On Track", "Medium" } },
                new() { RowLabel = "Network Infrastructure", Values = new List<string> { "✓", "✓", "✓", "✓", "In Progress", "Nov 20", "85%", "Ahead", "Low" }, IsHighlighted = true },
                new() { RowLabel = "Security Audit System", Values = new List<string> { "✓", "In Progress", "Pending", "Pending", "Pending", "Feb 28", "25%", "On Track", "Low" } },
                new() { RowLabel = "Data Analytics Platform", Values = new List<string> { "✓", "✓", "✓", "In Progress", "Pending", "Jan 15", "70%", "Delayed", "High" }, IsHighlighted = true },
                new() { RowLabel = "Cloud Migration Phase 2", Values = new List<string> { "✓", "✓", "In Progress", "Pending", "Pending", "Mar 30", "40%", "On Track", "Medium" } },
                new() { RowLabel = "Backup System Overhaul", Values = new List<string> { "✓", "✓", "✓", "✓", "✓", "Completed", "100%", "Complete", "None" } },
                new() { RowLabel = "Employee Portal V2", Values = new List<string> { "✓", "In Progress", "Pending", "Pending", "Pending", "Apr 15", "20%", "On Track", "Low" } },
                new() { RowLabel = "IoT Sensors Integration", Values = new List<string> { "✓", "✓", "In Progress", "Pending", "Pending", "May 30", "35%", "On Track", "Medium" } },
                new() { RowLabel = "AI Chatbot Implementation", Values = new List<string> { "In Progress", "Pending", "Pending", "Pending", "Pending", "Jun 30", "15%", "Planning", "Low" } }
            },

            SummaryRow = new DynamicDataRow
            {
                RowLabel = "PORTFOLIO SUMMARY",
                Values = new List<string> { "9/10", "7/10", "5/10", "3/10", "2/10", "1/10", "51%", "7 Active", "2 High Risk" }
            },

            FooterNotes = "✓ = Completed, In Progress = Currently active. Highlighted projects need attention: Network Infrastructure ahead of schedule (resource reallocation opportunity), Data Analytics Platform delayed (additional resources required). Portfolio health: 70% projects on track."
        };
    }

    public static GenericReportModel GetSampleGenericReport()
    {
        return new GenericReportModel
        {
            ReportName = "Monthly Sales Report",
            DateFilter = "October 2025",
            GeneratedBy = "Sales Manager",
            PageOrientation = "Portrait", // Can be "Portrait" or "Landscape"
            TextDirection = "LTR", // "LTR" for English, "RTL" for Arabic/Hebrew

            ColumnNames = new List<string>
            {
                "Product",
                "Units Sold",
                "Revenue (BHD)",
                "Profit Margin %",
                "Target Achievement %"
            },

            Data = new List<List<string>>
            {
                new() { "Laptop Computers", "45", "67,500", "15.2%", "112%" },
                new() { "Smartphones", "128", "38,400", "12.8%", "98%" },
                new() { "Tablets", "67", "20,100", "18.5%", "134%" },
                new() { "Desktop PCs", "23", "34,500", "22.1%", "77%" },
                new() { "Monitors", "89", "17,800", "14.7%", "89%" },
                new() { "Printers", "34", "10,200", "16.3%", "113%" },
                new() { "Accessories", "156", "15,600", "25.4%", "156%" },
                new() { "Software Licenses", "78", "23,400", "45.2%", "130%" }
            },

            SummaryRow = new List<string>
            {
                "TOTAL",
                "620",
                "227,500",
                "21.8%",
                "114%"
            },

            FooterNotes = "Sales performance exceeded targets for the month. Accessories and Software Licenses showed exceptional growth. Desktop PCs underperformed and require marketing focus. Overall profit margin improved by 2.3% compared to last month.",

            // Optional: Add custom header and footer logos as Base64 strings
            // HeaderLogoBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAUA...", // Your base64 encoded image
            // FooterLogoBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAUA..."  // Your base64 encoded image
        };
    }

    /// <summary>
    /// Sample Arabic report - demonstrates RTL support
    /// </summary>
    public static GenericReportModel GetSampleGenericReportArabic()
    {
        return new GenericReportModel
        {
            ReportName = "تقرير المبيعات الشهري",
            DateFilter = "أكتوبر 2025",
            GeneratedBy = "مدير المبيعات",
            PageOrientation = "Portrait",
            TextDirection = "RTL", // Enable RTL for Arabic

            ColumnNames = new List<string>
            {
                "المنتج",
                "الوحدات المباعة",
                "الإيرادات (د.ب)",
                "هامش الربح %",
                "تحقيق الهدف %"
            },

            Data = new List<List<string>>
            {
                new() { "أجهزة الكمبيوتر المحمولة", "45", "67,500", "15.2%", "112%" },
                new() { "الهواتف الذكية", "128", "38,400", "12.8%", "98%" },
                new() { "الأجهزة اللوحية", "67", "20,100", "18.5%", "134%" },
                new() { "أجهزة الكمبيوتر المكتبية", "23", "34,500", "22.1%", "77%" },
                new() { "الشاشات", "89", "17,800", "14.7%", "89%" },
                new() { "الطابعات", "34", "10,200", "16.3%", "113%" },
                new() { "الملحقات", "156", "15,600", "25.4%", "156%" },
                new() { "تراخيص البرامج", "78", "23,400", "45.2%", "130%" }
            },

            SummaryRow = new List<string>
            {
                "المجموع",
                "620",
                "227,500",
                "21.8%",
                "114%"
            },

            FooterNotes = "تجاوز أداء المبيعات الأهداف المحددة للشهر. أظهرت الملحقات وتراخيص البرامج نموًا استثنائيًا. أجهزة الكمبيوتر المكتبية لم تحقق الأداء المطلوب وتحتاج إلى تركيز تسويقي. تحسن هامش الربح الإجمالي بنسبة 2.3٪ مقارنة بالشهر الماضي."
        };
    }

    public static EmployeePayslipModel GetSampleEmployeePayslip()
    {
        var grossPay = 1800m;
        var basicSalary = 1200m;
        var housingAllowance = 400m;
        var transportAllowance = 200m;
        
        var socialInsurance = 108m; // 6% of gross
        var incomeTax = 0m; // Bahrain has no income tax
        var loanDeduction = 150m;
        var advanceDeduction = 50m;
        
        var totalEarnings = basicSalary + housingAllowance + transportAllowance;
        var totalDeductions = socialInsurance + incomeTax + loanDeduction + advanceDeduction;
        var netPay = totalEarnings - totalDeductions;

        return new EmployeePayslipModel
        {
            PayslipNumber = "PAY-2025-10-001",
            PayPeriod = "October 2025",
            PayDate = new DateTime(2025, 10, 31),
            WorkingDays = 22,
            TotalDays = 31,

            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "hr@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003",
                CommercialRegistrationNumber = "123456-1"
            },

            Employee = new EmployeeInfo
            {
                EmployeeId = "EMP001",
                FullName = "Ahmed Al-Khalifa",
                Position = "Senior System Administrator",
                Department = "Information Technology",
                JoinDate = new DateTime(2020, 3, 15),
                Nationality = "Bahraini",
                WorkPermitNumber = ""
            },

            Earnings = new List<EarningsItem>
            {
                new() { Description = "Basic Salary", Amount = basicSalary },
                new() { Description = "Housing Allowance", Amount = housingAllowance },
                new() { Description = "Transport Allowance", Amount = transportAllowance }
            },

            Deductions = new List<DeductionItem>
            {
                new() { Description = "Social Insurance (6%)", Amount = socialInsurance },
                new() { Description = "Loan Repayment", Amount = loanDeduction },
                new() { Description = "Advance Deduction", Amount = advanceDeduction }
            },

            BankDetails = new BankDetails
            {
                BankName = "National Bank of Bahrain B.S.C.",
                AccountName = "Ahmed Al-Khalifa",
                AccountNumber = "0123456789",
                IBAN = "BH67 NBOB 0000 1234 5678 90",
                SwiftCode = "NBOBBBMX",
                Branch = "Diplomatic Area Branch"
            },

            Summary = new PayslipSummary
            {
                TotalEarnings = totalEarnings,
                TotalDeductions = totalDeductions,
                GrossPay = grossPay,
                NetPay = netPay
            },

            BenefitBalance = new List<BenefitBalance>()
            {
                new () { BenefitType = "Annual Leave", BalanceAmount = 15 },
                new () { BenefitType = "Indemnity ", BalanceAmount = 122 }
            },

            PreparedBy = "Layla Ahmed - HR Manager",
            Password = null // Set to a password string to enable PDF protection
        };
    }

    public static EmployeePayslipModel GetSampleEmployeePayslipWithPassword()
    {
        var payslip = GetSampleEmployeePayslip();
        payslip.Password = "secure123"; // Password-protected PDF
        return payslip;
    }
    
    public static IncomeStatementModel GetSampleIncomeStatement()
    {
        return new IncomeStatementModel
        {
            ReportTitle = "Income Statement",
            ReportSubtitle = "For the Year Ended December 31, 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Finance Department",
            FromDate = new DateTime(2025, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            TotalRevenue = 5000000m,
            TotalExpenses = 3200000m,
            NetIncome = 1800000m,
            
            ColumnHeaders = new List<string>
            {
                "2025 (BHD)", "2024 (BHD)", "Variance (BHD)", "Variance %"
            },
            
            DataRows = new List<LedgerDataRow>
            {
                new() { RowLabel = "REVENUE", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Sales Revenue", Values = new List<string> { "4,200,000", "3,800,000", "400,000", "10.5%" } },
                new() { RowLabel = "Service Revenue", Values = new List<string> { "800,000", "750,000", "50,000", "6.7%" } },
                new() { RowLabel = "Total Revenue", Values = new List<string> { "5,000,000", "4,550,000", "450,000", "9.9%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "EXPENSES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Cost of Goods Sold", Values = new List<string> { "2,100,000", "1,900,000", "200,000", "10.5%" } },
                new() { RowLabel = "Salaries and Wages", Values = new List<string> { "800,000", "750,000", "50,000", "6.7%" } },
                new() { RowLabel = "Rent and Utilities", Values = new List<string> { "300,000", "280,000", "20,000", "7.1%" } },
                new() { RowLabel = "Marketing Expenses", Values = new List<string> { "250,000", "220,000", "30,000", "13.6%" } },
                new() { RowLabel = "Depreciation", Values = new List<string> { "150,000", "140,000", "10,000", "7.1%" } },
                new() { RowLabel = "Other Operating Expenses", Values = new List<string> { "400,000", "360,000", "40,000", "11.1%" } },
                new() { RowLabel = "Total Expenses", Values = new List<string> { "4,000,000", "3,650,000", "350,000", "9.6%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "OTHER INCOME/EXPENSE", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Interest Income", Values = new List<string> { "20,000", "15,000", "5,000", "33.3%" } },
                new() { RowLabel = "Interest Expense", Values = new List<string> { "(50,000)", "(40,000)", "(10,000)", "25.0%" } },
                new() { RowLabel = "Net Other Income/(Expense)", Values = new List<string> { "(30,000)", "(25,000)", "(5,000)", "20.0%" }, RowType = "Subtotal" }
            },
            
            SummaryRow = new LedgerDataRow
            {
                RowLabel = "NET INCOME",
                Values = new List<string> { "970,000", "875,000", "95,000", "10.9%" },
                RowType = "Total"
            },
            
            FooterNotes = "All figures in Bahraini Dinars (BHD). Net income increased by 10.9% compared to the previous year, primarily due to increased sales revenue and controlled expense growth."
        };
    }
    
    public static FinancialPositionModel GetSampleFinancialPosition()
    {
        return new FinancialPositionModel
        {
            ReportTitle = "Statement of Financial Position",
            ReportSubtitle = "As at December 31, 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Finance Department",
            FromDate = new DateTime(2025, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            TotalAssets = 8500000m,
            TotalLiabilities = 3200000m,
            TotalEquity = 5300000m,
            
            ColumnHeaders = new List<string>
            {
                "2025 (BHD)", "2024 (BHD)", "Variance (BHD)", "Variance %"
            },
            
            DataRows = new List<LedgerDataRow>
            {
                new() { RowLabel = "ASSETS", Values = new List<string>(), RowType = "Header" },
                
                new() { RowLabel = "CURRENT ASSETS", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Cash and Cash Equivalents", Values = new List<string> { "1,500,000", "1,200,000", "300,000", "25.0%" } },
                new() { RowLabel = "Accounts Receivable", Values = new List<string> { "1,200,000", "1,000,000", "200,000", "20.0%" } },
                new() { RowLabel = "Inventory", Values = new List<string> { "800,000", "700,000", "100,000", "14.3%" } },
                new() { RowLabel = "Prepaid Expenses", Values = new List<string> { "100,000", "80,000", "20,000", "25.0%" } },
                new() { RowLabel = "Total Current Assets", Values = new List<string> { "3,600,000", "2,980,000", "620,000", "20.8%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "NON-CURRENT ASSETS", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Property, Plant and Equipment", Values = new List<string> { "4,000,000", "3,800,000", "200,000", "5.3%" } },
                new() { RowLabel = "Accumulated Depreciation", Values = new List<string> { "(800,000)", "(700,000)", "(100,000)", "14.3%" } },
                new() { RowLabel = "Net Property, Plant and Equipment", Values = new List<string> { "3,200,000", "3,100,000", "100,000", "3.2%" } },
                new() { RowLabel = "Intangible Assets", Values = new List<string> { "700,000", "600,000", "100,000", "16.7%" } },
                new() { RowLabel = "Total Non-Current Assets", Values = new List<string> { "3,900,000", "3,700,000", "200,000", "5.4%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "TOTAL ASSETS", Values = new List<string> { "7,500,000", "6,680,000", "820,000", "12.3%" }, RowType = "Total" },
                
                new() { RowLabel = "LIABILITIES AND EQUITY", Values = new List<string>(), RowType = "Header" },
                
                new() { RowLabel = "CURRENT LIABILITIES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Accounts Payable", Values = new List<string> { "800,000", "700,000", "100,000", "14.3%" } },
                new() { RowLabel = "Short-term Debt", Values = new List<string> { "500,000", "400,000", "100,000", "25.0%" } },
                new() { RowLabel = "Accrued Expenses", Values = new List<string> { "300,000", "250,000", "50,000", "20.0%" } },
                new() { RowLabel = "Total Current Liabilities", Values = new List<string> { "1,600,000", "1,350,000", "250,000", "18.5%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "NON-CURRENT LIABILITIES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Long-term Debt", Values = new List<string> { "1,200,000", "1,000,000", "200,000", "20.0%" } },
                new() { RowLabel = "Deferred Tax Liabilities", Values = new List<string> { "400,000", "330,000", "70,000", "21.2%" } },
                new() { RowLabel = "Total Non-Current Liabilities", Values = new List<string> { "1,600,000", "1,330,000", "270,000", "20.3%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "TOTAL LIABILITIES", Values = new List<string> { "3,200,000", "2,680,000", "520,000", "19.4%" }, RowType = "Total" },
                
                new() { RowLabel = "EQUITY", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Share Capital", Values = new List<string> { "2,000,000", "2,000,000", "0", "0.0%" } },
                new() { RowLabel = "Retained Earnings", Values = new List<string> { "2,300,000", "2,000,000", "300,000", "15.0%" } },
                new() { RowLabel = "Total Equity", Values = new List<string> { "4,300,000", "4,000,000", "300,000", "7.5%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "TOTAL LIABILITIES AND EQUITY", Values = new List<string> { "7,500,000", "6,680,000", "820,000", "12.3%" }, RowType = "Total" }
            },
            
            SummaryRow = new LedgerDataRow
            {
                RowLabel = "ACCOUNTING EQUATION BALANCE",
                Values = new List<string> { "Assets = Liabilities + Equity", "7,500,000 = 3,200,000 + 4,300,000", "", "" },
                RowType = "Total"
            },
            
            FooterNotes = "All figures in Bahraini Dinars (BHD). The company maintains a healthy current ratio of 2.25:1, indicating strong short-term liquidity. Equity increased by 7.5% primarily due to retained earnings growth."
        };
    }
    
    public static TrialBalanceModel GetSampleTrialBalance()
    {
        return new TrialBalanceModel
        {
            ReportTitle = "Trial Balance",
            ReportSubtitle = "As at December 31, 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Accounting Department",
            FromDate = new DateTime(2025, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            TotalDebit = 12500000m,
            TotalCredit = 12500000m,
            
            ColumnHeaders = new List<string>
            {
                "Account Code", "Account Name", "Debit (BHD)", "Credit (BHD)"
            },
            
            DataRows = new List<LedgerDataRow>
            {
                new() { RowLabel = "ASSETS", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "1001", Values = new List<string> { "Cash", "1,500,000", "" } },
                new() { RowLabel = "1002", Values = new List<string> { "Accounts Receivable", "1,200,000", "" } },
                new() { RowLabel = "1003", Values = new List<string> { "Inventory", "800,000", "" } },
                new() { RowLabel = "1004", Values = new List<string> { "Prepaid Expenses", "100,000", "" } },
                new() { RowLabel = "1101", Values = new List<string> { "Property, Plant and Equipment", "4,000,000", "" } },
                new() { RowLabel = "1102", Values = new List<string> { "Accumulated Depreciation", "", "800,000" } },
                new() { RowLabel = "1103", Values = new List<string> { "Intangible Assets", "700,000", "" } },
                
                new() { RowLabel = "LIABILITIES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "2001", Values = new List<string> { "Accounts Payable", "", "800,000" } },
                new() { RowLabel = "2002", Values = new List<string> { "Short-term Debt", "", "500,000" } },
                new() { RowLabel = "2003", Values = new List<string> { "Accrued Expenses", "", "300,000" } },
                new() { RowLabel = "2101", Values = new List<string> { "Long-term Debt", "", "1,200,000" } },
                new() { RowLabel = "2102", Values = new List<string> { "Deferred Tax Liabilities", "", "400,000" } },
                
                new() { RowLabel = "EQUITY", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "3001", Values = new List<string> { "Share Capital", "", "2,000,000" } },
                new() { RowLabel = "3002", Values = new List<string> { "Retained Earnings", "", "2,300,000" } },
                
                new() { RowLabel = "REVENUE", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "4001", Values = new List<string> { "Sales Revenue", "", "4,200,000" } },
                new() { RowLabel = "4002", Values = new List<string> { "Service Revenue", "", "800,000" } },
                
                new() { RowLabel = "EXPENSES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "5001", Values = new List<string> { "Cost of Goods Sold", "2,100,000", "" } },
                new() { RowLabel = "5002", Values = new List<string> { "Salaries and Wages", "800,000", "" } },
                new() { RowLabel = "5003", Values = new List<string> { "Rent and Utilities", "300,000", "" } },
                new() { RowLabel = "5004", Values = new List<string> { "Marketing Expenses", "250,000", "" } },
                new() { RowLabel = "5005", Values = new List<string> { "Depreciation", "150,000", "" } },
                new() { RowLabel = "5006", Values = new List<string> { "Other Operating Expenses", "400,000", "" } },
                new() { RowLabel = "5007", Values = new List<string> { "Interest Expense", "50,000", "" } },
                
                new() { RowLabel = "OTHER INCOME", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "6001", Values = new List<string> { "Interest Income", "", "20,000" } }
            },
            
            SummaryRow = new LedgerDataRow
            {
                RowLabel = "TOTALS",
                Values = new List<string> { "", "", "12,500,000", "12,500,000" },
                RowType = "Total"
            },
            
            FooterNotes = "All figures in Bahraini Dinars (BHD). Trial balance is balanced with total debits equal to total credits, confirming the accounting records are mathematically accurate."
        };
    }
    
    public static ComparisonReportModel GetSampleComparisonReport()
    {
        return new ComparisonReportModel
        {
            ReportTitle = "2-Year Comparison Report",
            ReportSubtitle = "Financial Performance Analysis",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Financial Analyst",
            FromDate = new DateTime(2024, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            ComparisonPeriod1 = "Year Ended Dec 31, 2024",
            ComparisonPeriod2 = "Year Ended Dec 31, 2025",
            VarianceAmount = 950000m,
            VariancePercentage = 12.1m,
            
            ColumnHeaders = new List<string>
            {
                "2024 (BHD)", "2025 (BHD)", "Variance (BHD)", "Variance %"
            },
            
            DataRows = new List<LedgerDataRow>
            {
                new() { RowLabel = "REVENUE", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Sales Revenue", Values = new List<string> { "3,800,000", "4,200,000", "400,000", "10.5%" } },
                new() { RowLabel = "Service Revenue", Values = new List<string> { "750,000", "800,000", "50,000", "6.7%" } },
                new() { RowLabel = "Total Revenue", Values = new List<string> { "4,550,000", "5,000,000", "450,000", "9.9%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "EXPENSES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Cost of Goods Sold", Values = new List<string> { "1,900,000", "2,100,000", "200,000", "10.5%" } },
                new() { RowLabel = "Salaries and Wages", Values = new List<string> { "750,000", "800,000", "50,000", "6.7%" } },
                new() { RowLabel = "Rent and Utilities", Values = new List<string> { "280,000", "300,000", "20,000", "7.1%" } },
                new() { RowLabel = "Marketing Expenses", Values = new List<string> { "220,000", "250,000", "30,000", "13.6%" } },
                new() { RowLabel = "Depreciation", Values = new List<string> { "140,000", "150,000", "10,000", "7.1%" } },
                new() { RowLabel = "Other Operating Expenses", Values = new List<string> { "360,000", "400,000", "40,000", "11.1%" } },
                new() { RowLabel = "Total Expenses", Values = new List<string> { "3,650,000", "4,000,000", "350,000", "9.6%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "NET INCOME", Values = new List<string> { "900,000", "1,000,000", "100,000", "11.1%" }, RowType = "Total" },
                
                new() { RowLabel = "BALANCE SHEET ITEMS", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Total Assets", Values = new List<string> { "6,680,000", "7,500,000", "820,000", "12.3%" } },
                new() { RowLabel = "Total Liabilities", Values = new List<string> { "2,680,000", "3,200,000", "520,000", "19.4%" } },
                new() { RowLabel = "Total Equity", Values = new List<string> { "4,000,000", "4,300,000", "300,000", "7.5%" } }
            },
            
            SummaryRow = new LedgerDataRow
            {
                RowLabel = "OVERALL PERFORMANCE",
                Values = new List<string> { "", "", "Improved by 11.1%", "" },
                RowType = "Total"
            },
            
            FooterNotes = "All figures in Bahraini Dinars (BHD). Financial performance improved across all key metrics. Revenue growth outpaced expense growth, resulting in an 11.1% increase in net income. Asset base expanded by 12.3%, supporting future growth initiatives."
        };
    }
    
    public static BudgetComparisonModel GetSampleBudgetComparison()
    {
        return new BudgetComparisonModel
        {
            ReportTitle = "Budget vs Actual Comparison",
            ReportSubtitle = "Annual Performance Report 2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Budget Committee",
            FromDate = new DateTime(2025, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            ComparisonPeriod1 = "Budgeted Amount",
            ComparisonPeriod2 = "Actual Amount",
            VarianceAmount = 150000m,
            VariancePercentage = 3.1m,
            BudgetAmount = 4850000m,
            ActualAmount = 5000000m,
            BudgetVariance = 150000m,
            BudgetVariancePercentage = 3.1m,
            
            ColumnHeaders = new List<string>
            {
                "Budget (BHD)", "Actual (BHD)", "Variance (BHD)", "Variance %"
            },
            
            DataRows = new List<LedgerDataRow>
            {
                new() { RowLabel = "REVENUE", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Sales Revenue", Values = new List<string> { "3,900,000", "4,200,000", "300,000", "7.7%" } },
                new() { RowLabel = "Service Revenue", Values = new List<string> { "850,000", "800,000", "(50,000)", "(5.9%)" } },
                new() { RowLabel = "Total Revenue", Values = new List<string> { "4,750,000", "5,000,000", "250,000", "5.3%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "EXPENSES", Values = new List<string>(), RowType = "Header" },
                new() { RowLabel = "Cost of Goods Sold", Values = new List<string> { "2,000,000", "2,100,000", "100,000", "5.0%" } },
                new() { RowLabel = "Salaries and Wages", Values = new List<string> { "780,000", "800,000", "20,000", "2.6%" } },
                new() { RowLabel = "Rent and Utilities", Values = new List<string> { "320,000", "300,000", "(20,000)", "(6.3%)" } },
                new() { RowLabel = "Marketing Expenses", Values = new List<string> { "280,000", "250,000", "(30,000)", "(10.7%)" } },
                new() { RowLabel = "Depreciation", Values = new List<string> { "160,000", "150,000", "(10,000)", "(6.3%)" } },
                new() { RowLabel = "Other Operating Expenses", Values = new List<string> { "360,000", "400,000", "40,000", "11.1%" } },
                new() { RowLabel = "Total Expenses", Values = new List<string> { "3,900,000", "4,000,000", "100,000", "2.6%" }, RowType = "Subtotal" },
                
                new() { RowLabel = "NET INCOME", Values = new List<string> { "850,000", "1,000,000", "150,000", "17.6%" }, RowType = "Total" }
            },
            
            SummaryRow = new LedgerDataRow
            {
                RowLabel = "BUDGET PERFORMANCE",
                Values = new List<string> { "4,850,000", "5,000,000", "150,000", "3.1%" },
                RowType = "Total"
            },
            
            FooterNotes = "All figures in Bahraini Dinars (BHD). The company exceeded its budget by 3.1%, primarily due to higher than expected sales revenue. Expense control was generally effective, with several categories coming in under budget. Marketing expenses were significantly below budget, which may have impacted revenue growth potential."
        };
    }
    
    /// <summary>
    /// Enhanced 12-Column Budget Comparison Report with Account Grouping
    /// </summary>
    public static EnhancedBudgetComparisonModel GetSampleEnhancedBudgetComparison()
    {
        var months = new List<string>
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        var model = new EnhancedBudgetComparisonModel
        {
            ReportTitle = "12-Column Budget Comparison Report",
            ReportSubtitle = "Monthly Budget vs Actual Analysis by Account Chart - 2025",
            FiscalYear = "2025",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Finance Department",
            FromDate = new DateTime(2025, 1, 1),
            ToDate = new DateTime(2025, 12, 31),
            MonthlyColumns = months,
            ShowVarianceColors = true,
            ShowAccountCodes = true,
            ShowPercentages = true,
            FooterNotes = "This report provides a comprehensive monthly breakdown of budget vs actual performance across all account categories. Variance alerts are triggered when variance exceeds ±10%. Green indicates within 5% variance, yellow indicates 5-10% variance, and red indicates variance exceeding 10%."
        };

        // Operating Expenses Group
        var operatingExpenses = new AccountGroup
        {
            GroupName = "Operating Expenses",
            GroupCode = "5000",
            IsExpanded = true,
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountCode = "5100",
                    AccountName = "Salaries and Wages",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(50000, 52000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 600000,
                        TotalActual = 624000,
                        TotalVariance = 24000,
                        TotalVariancePercentage = 4.0m,
                        AverageMonthlyVariance = 2000,
                        VarianceTrend = "Stable"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "5200",
                    AccountName = "Rent and Utilities",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(25000, 24500, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 300000,
                        TotalActual = 294000,
                        TotalVariance = -6000,
                        TotalVariancePercentage = -2.0m,
                        AverageMonthlyVariance = -500,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "5300",
                    AccountName = "Marketing Expenses",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(15000, 18000, months),
                    IsHighlighted = true,
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 180000,
                        TotalActual = 216000,
                        TotalVariance = 36000,
                        TotalVariancePercentage = 20.0m,
                        AverageMonthlyVariance = 3000,
                        VarianceTrend = "Deteriorating"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "5400",
                    AccountName = "Office Supplies",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(5000, 4800, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 60000,
                        TotalActual = 57600,
                        TotalVariance = -2400,
                        TotalVariancePercentage = -4.0m,
                        AverageMonthlyVariance = -200,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "5500",
                    AccountName = "Professional Services",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(12000, 13500, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 144000,
                        TotalActual = 162000,
                        TotalVariance = 18000,
                        TotalVariancePercentage = 12.5m,
                        AverageMonthlyVariance = 1500,
                        VarianceTrend = "Deteriorating"
                    }
                }
            }
        };

        // Calculate group summary for Operating Expenses
        operatingExpenses.GroupSummary = new AccountGroupSummary
        {
            GroupTotalBudget = operatingExpenses.Accounts.Sum(a => a.AccountSummary.TotalBudget),
            GroupTotalActual = operatingExpenses.Accounts.Sum(a => a.AccountSummary.TotalActual),
            GroupTotalVariance = operatingExpenses.Accounts.Sum(a => a.AccountSummary.TotalVariance),
            GroupTotalVariancePercentage = CalculatePercentage(operatingExpenses.Accounts.Sum(a => a.AccountSummary.TotalActual), operatingExpenses.Accounts.Sum(a => a.AccountSummary.TotalBudget)),
            AccountCount = operatingExpenses.Accounts.Count,
            VarianceAlertCount = operatingExpenses.Accounts.Count(a => Math.Abs(a.AccountSummary.TotalVariancePercentage) > 10)
        };

        // Cost of Goods Sold Group
        var costOfGoodsSold = new AccountGroup
        {
            GroupName = "Cost of Goods Sold",
            GroupCode = "4000",
            IsExpanded = true,
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountCode = "4100",
                    AccountName = "Raw Materials",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(80000, 78000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 960000,
                        TotalActual = 936000,
                        TotalVariance = -24000,
                        TotalVariancePercentage = -2.5m,
                        AverageMonthlyVariance = -2000,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "4200",
                    AccountName = "Direct Labor",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(35000, 36000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 420000,
                        TotalActual = 432000,
                        TotalVariance = 12000,
                        TotalVariancePercentage = 2.9m,
                        AverageMonthlyVariance = 1000,
                        VarianceTrend = "Stable"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "4300",
                    AccountName = "Manufacturing Overhead",
                    AccountType = "Expense",
                    MonthlyData = GenerateMonthlyData(20000, 22000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 240000,
                        TotalActual = 264000,
                        TotalVariance = 24000,
                        TotalVariancePercentage = 10.0m,
                        AverageMonthlyVariance = 2000,
                        VarianceTrend = "Deteriorating"
                    }
                }
            }
        };

        // Calculate group summary for Cost of Goods Sold
        costOfGoodsSold.GroupSummary = new AccountGroupSummary
        {
            GroupTotalBudget = costOfGoodsSold.Accounts.Sum(a => a.AccountSummary.TotalBudget),
            GroupTotalActual = costOfGoodsSold.Accounts.Sum(a => a.AccountSummary.TotalActual),
            GroupTotalVariance = costOfGoodsSold.Accounts.Sum(a => a.AccountSummary.TotalVariance),
            GroupTotalVariancePercentage = CalculatePercentage(costOfGoodsSold.Accounts.Sum(a => a.AccountSummary.TotalActual), costOfGoodsSold.Accounts.Sum(a => a.AccountSummary.TotalBudget)),
            AccountCount = costOfGoodsSold.Accounts.Count,
            VarianceAlertCount = costOfGoodsSold.Accounts.Count(a => Math.Abs(a.AccountSummary.TotalVariancePercentage) > 10)
        };

        // Revenue Group
        var revenue = new AccountGroup
        {
            GroupName = "Revenue",
            GroupCode = "3000",
            IsExpanded = true,
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountCode = "3100",
                    AccountName = "Product Sales",
                    AccountType = "Revenue",
                    MonthlyData = GenerateMonthlyData(150000, 165000, months),
                    IsHighlighted = true,
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 1800000,
                        TotalActual = 1980000,
                        TotalVariance = 180000,
                        TotalVariancePercentage = 10.0m,
                        AverageMonthlyVariance = 15000,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "3200",
                    AccountName = "Service Revenue",
                    AccountType = "Revenue",
                    MonthlyData = GenerateMonthlyData(45000, 48000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 540000,
                        TotalActual = 576000,
                        TotalVariance = 36000,
                        TotalVariancePercentage = 6.7m,
                        AverageMonthlyVariance = 3000,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "3300",
                    AccountName = "Licensing Revenue",
                    AccountType = "Revenue",
                    MonthlyData = GenerateMonthlyData(25000, 23000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 300000,
                        TotalActual = 276000,
                        TotalVariance = -24000,
                        TotalVariancePercentage = -8.0m,
                        AverageMonthlyVariance = -2000,
                        VarianceTrend = "Deteriorating"
                    }
                }
            }
        };

        // Calculate group summary for Revenue
        revenue.GroupSummary = new AccountGroupSummary
        {
            GroupTotalBudget = revenue.Accounts.Sum(a => a.AccountSummary.TotalBudget),
            GroupTotalActual = revenue.Accounts.Sum(a => a.AccountSummary.TotalActual),
            GroupTotalVariance = revenue.Accounts.Sum(a => a.AccountSummary.TotalVariance),
            GroupTotalVariancePercentage = CalculatePercentage(revenue.Accounts.Sum(a => a.AccountSummary.TotalActual), revenue.Accounts.Sum(a => a.AccountSummary.TotalBudget)),
            AccountCount = revenue.Accounts.Count,
            VarianceAlertCount = revenue.Accounts.Count(a => Math.Abs(a.AccountSummary.TotalVariancePercentage) > 10)
        };

        // Capital Expenditures Group
        var capitalExpenditures = new AccountGroup
        {
            GroupName = "Capital Expenditures",
            GroupCode = "6000",
            IsExpanded = true,
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountCode = "6100",
                    AccountName = "Equipment Purchases",
                    AccountType = "Asset",
                    MonthlyData = GenerateMonthlyData(30000, 45000, months),
                    IsHighlighted = true,
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 360000,
                        TotalActual = 540000,
                        TotalVariance = 180000,
                        TotalVariancePercentage = 50.0m,
                        AverageMonthlyVariance = 15000,
                        VarianceTrend = "Deteriorating"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "6200",
                    AccountName = "Software Development",
                    AccountType = "Asset",
                    MonthlyData = GenerateMonthlyData(20000, 18000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 240000,
                        TotalActual = 216000,
                        TotalVariance = -24000,
                        TotalVariancePercentage = -10.0m,
                        AverageMonthlyVariance = -2000,
                        VarianceTrend = "Improving"
                    }
                },
                new AccountDetail
                {
                    AccountCode = "6300",
                    AccountName = "Facility Improvements",
                    AccountType = "Asset",
                    MonthlyData = GenerateMonthlyData(15000, 12000, months),
                    AccountSummary = new AccountSummary
                    {
                        TotalBudget = 180000,
                        TotalActual = 144000,
                        TotalVariance = -36000,
                        TotalVariancePercentage = -20.0m,
                        AverageMonthlyVariance = -3000,
                        VarianceTrend = "Improving"
                    }
                }
            }
        };

        // Calculate group summary for Capital Expenditures
        capitalExpenditures.GroupSummary = new AccountGroupSummary
        {
            GroupTotalBudget = capitalExpenditures.Accounts.Sum(a => a.AccountSummary.TotalBudget),
            GroupTotalActual = capitalExpenditures.Accounts.Sum(a => a.AccountSummary.TotalActual),
            GroupTotalVariance = capitalExpenditures.Accounts.Sum(a => a.AccountSummary.TotalVariance),
            GroupTotalVariancePercentage = CalculatePercentage(capitalExpenditures.Accounts.Sum(a => a.AccountSummary.TotalActual), capitalExpenditures.Accounts.Sum(a => a.AccountSummary.TotalBudget)),
            AccountCount = capitalExpenditures.Accounts.Count,
            VarianceAlertCount = capitalExpenditures.Accounts.Count(a => Math.Abs(a.AccountSummary.TotalVariancePercentage) > 10)
        };

        model.AccountGroups.Add(operatingExpenses);
        model.AccountGroups.Add(costOfGoodsSold);
        model.AccountGroups.Add(revenue);
        model.AccountGroups.Add(capitalExpenditures);

        // Calculate overall totals
        model.TotalBudgetAmount = model.AccountGroups.Sum(g => g.GroupSummary.GroupTotalBudget);
        model.TotalActualAmount = model.AccountGroups.Sum(g => g.GroupSummary.GroupTotalActual);
        model.TotalVarianceAmount = model.TotalActualAmount - model.TotalBudgetAmount;
        model.TotalVariancePercentage = CalculatePercentage(model.TotalActualAmount, model.TotalBudgetAmount);

        return model;
    }

    /// <summary>
    /// Helper method to generate monthly data with some variance
    /// </summary>
    private static List<MonthlyData> GenerateMonthlyData(decimal baseBudget, decimal baseActual, List<string> months)
    {
        var monthlyData = new List<MonthlyData>();
        var ytdBudget = 0m;
        var ytdActual = 0m;
        var random = new Random(42); // Fixed seed for consistent sample data

        for (int i = 0; i < months.Count; i++)
        {
            // Add some random variation to make it more realistic
            var monthBudget = baseBudget + (decimal)(random.NextDouble() - 0.5) * baseBudget * 0.1m;
            var monthActual = baseActual + (decimal)(random.NextDouble() - 0.5) * baseActual * 0.15m;
            
            ytdBudget += monthBudget;
            ytdActual += monthActual;
            
            var monthVariance = monthActual - monthBudget;
            var monthVariancePercentage = monthBudget != 0 ? (monthVariance / monthBudget) * 100 : 0;
            var ytdVariance = ytdActual - ytdBudget;
            var ytdVariancePercentage = ytdBudget != 0 ? (ytdVariance / ytdBudget) * 100 : 0;

            monthlyData.Add(new MonthlyData
            {
                MonthName = months[i],
                BudgetAmount = monthBudget,
                ActualAmount = monthActual,
                VarianceAmount = monthVariance,
                VariancePercentage = monthVariancePercentage,
                YearToDateBudget = ytdBudget,
                YearToDateActual = ytdActual,
                YearToDateVariance = ytdVariance,
                YearToDateVariancePercentage = ytdVariancePercentage
            });
        }

        return monthlyData;
    }

    /// <summary>
    /// Helper method to calculate percentage
    /// </summary>
    private static decimal CalculatePercentage(decimal actual, decimal budget)
    {
        return budget != 0 ? ((actual - budget) / budget) * 100 : 0;
    }
    /// <summary>
    /// Comprehensive Employee Data for Merged Reports
    /// </summary>
    public static EmployeeDataModel GetSampleEmployeeData(EmployeeReportType reportType = EmployeeReportType.Merged)
    {
        var employees = GenerateComprehensiveEmployeeData();
        var model = new EmployeeDataModel
        {
            ReportTitle = GetReportTitle(reportType),
            ReportType = reportType.ToString(),
            ReportDate = DateTime.Now,
            ReportingPeriod = "October 2025",
            
            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "hr@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003",
                CommercialRegistrationNumber = "123456-1"
            },
            
            Employees = employees,
            Summary = CalculateEmployeeSummary(employees),
            PreparedBy = "Layla Ahmed - HR Manager",
            ReviewedBy = "Rashid Al-Khater - Head of IT"
        };

        // Generate specific analysis based on report type
        switch (reportType)
        {
            case EmployeeReportType.Department:
                model.DepartmentAnalysis = GenerateDepartmentAnalysis(employees);
                break;
            case EmployeeReportType.Citizenship:
                model.CitizenshipAnalysis = GenerateCitizenshipAnalysis(employees);
                break;
            case EmployeeReportType.Merged:
                model.DepartmentAnalysis = GenerateDepartmentAnalysis(employees);
                model.CitizenshipAnalysis = GenerateCitizenshipAnalysis(employees);
                model.PayslipData = GenerateSamplePayslipData(employees.First());
                break;
        }

        return model;
    }

    /// <summary>
    /// Generate comprehensive employee data with all required fields
    /// </summary>
    private static List<ComprehensiveEmployee> GenerateComprehensiveEmployeeData()
    {
        return new List<ComprehensiveEmployee>
        {
            new()
            {
                EmployeeId = "EMP001", FullName = "Ahmed Al-Khalifa", Position = "Senior System Administrator",
                Department = "Information Technology", JoinDate = new DateTime(2020, 3, 15),
                Email = "ahmed.k@gulftech.bh", Phone = "+973 3312 4567", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "900101123",
                DateOfBirth = new DateTime(1990, 1, 1), Gender = "Male", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1800m,
                BasicSalary = 1200m, HousingAllowance = 400m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 108m, IncomeTax = 0m, LoanDeduction = 150m, AdvanceDeduction = 50m, OtherDeductions = 0m,
                BankName = "National Bank of Bahrain", AccountNumber = "0123456789", IBAN = "BH67 NBOB 0000 1234 5678 90",
                AnnualLeaveBalance = 15m, SickLeaveBalance = 10m, IndemnityBalance = 122m
            },
            new()
            {
                EmployeeId = "EMP002", FullName = "Sarah Mohammed", Position = "Software Developer",
                Department = "Information Technology", JoinDate = new DateTime(2021, 6, 1),
                Email = "sarah.m@gulftech.bh", Phone = "+973 3345 6789", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "920506456",
                DateOfBirth = new DateTime(1992, 5, 6), Gender = "Female", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1500m,
                BasicSalary = 1000m, HousingAllowance = 300m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 20, LeaveDays = 2,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 90.9m,
                SocialInsurance = 90m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Ahli United Bank", AccountNumber = "9876543210", IBAN = "BH78 AUBK 0000 9876 5432 10",
                AnnualLeaveBalance = 18m, SickLeaveBalance = 12m, IndemnityBalance = 85m
            },
            new()
            {
                EmployeeId = "EMP003", FullName = "Mohammed Al-Mansoori", Position = "Network Engineer",
                Department = "Information Technology", JoinDate = new DateTime(2019, 1, 10),
                Email = "mohammed.a@gulftech.bh", Phone = "+973 3398 7654", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "880110789",
                DateOfBirth = new DateTime(1988, 1, 10), Gender = "Male", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1650m,
                BasicSalary = 1100m, HousingAllowance = 350m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 99m, IncomeTax = 0m, LoanDeduction = 100m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "BBK", AccountNumber = "5555666677", IBAN = "BH45 BBKU 0000 5555 6666 77",
                AnnualLeaveBalance = 20m, SickLeaveBalance = 15m, IndemnityBalance = 180m
            },
            new()
            {
                EmployeeId = "EMP004", FullName = "Fatima Hassan", Position = "Database Administrator",
                Department = "Information Technology", JoinDate = new DateTime(2022, 9, 5),
                Email = "fatima.h@gulftech.bh", Phone = "+973 3356 4321", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "950915234",
                DateOfBirth = new DateTime(1995, 9, 15), Gender = "Female", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1400m,
                BasicSalary = 950m, HousingAllowance = 250m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 21, LeaveDays = 1,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 95.5m,
                SocialInsurance = 84m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 50m, OtherDeductions = 0m,
                BankName = "Al Salam Bank", AccountNumber = "1111222233", IBAN = "BH12 ASBK 0000 1111 2222 33",
                AnnualLeaveBalance = 16m, SickLeaveBalance = 11m, IndemnityBalance = 65m
            },
            new()
            {
                EmployeeId = "EMP005", FullName = "Khalid Ibrahim", Position = "IT Support Specialist",
                Department = "Information Technology", JoinDate = new DateTime(2023, 2, 20),
                Email = "khalid.i@gulftech.bh", Phone = "+973 3334 5678", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "000220567",
                DateOfBirth = new DateTime(2000, 2, 20), Gender = "Male", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 950m,
                BasicSalary = 650m, HousingAllowance = 150m, TransportAllowance = 150m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 57m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "National Bank of Bahrain", AccountNumber = "8888999900", IBAN = "BH89 NBOB 0000 8888 9999 00",
                AnnualLeaveBalance = 14m, SickLeaveBalance = 9m, IndemnityBalance = 25m
            },
            new()
            {
                EmployeeId = "EMP006", FullName = "Noora Ali", Position = "Security Analyst",
                Department = "Information Technology", JoinDate = new DateTime(2021, 11, 8),
                Email = "noora.a@gulftech.bh", Phone = "+973 3367 8901", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "931108890",
                DateOfBirth = new DateTime(1993, 11, 8), Gender = "Female", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1550m,
                BasicSalary = 1050m, HousingAllowance = 300m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 19, LeaveDays = 3,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 86.4m,
                SocialInsurance = 93m, IncomeTax = 0m, LoanDeduction = 75m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Khaleeji Commercial Bank", AccountNumber = "3333444455", IBAN = "BH34 KCBK 0000 3333 4444 55",
                AnnualLeaveBalance = 17m, SickLeaveBalance = 10m, IndemnityBalance = 90m
            },
            new()
            {
                EmployeeId = "EMP007", FullName = "Hamad Yousif", Position = "DevOps Engineer",
                Department = "Information Technology", JoinDate = new DateTime(2020, 7, 12),
                Email = "hamad.y@gulftech.bh", Phone = "+973 3389 0123", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "910712012",
                DateOfBirth = new DateTime(1991, 7, 12), Gender = "Male", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1700m,
                BasicSalary = 1150m, HousingAllowance = 350m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 102m, IncomeTax = 0m, LoanDeduction = 200m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "BBK", AccountNumber = "6666777788", IBAN = "BH67 BBKU 0000 6666 7777 88",
                AnnualLeaveBalance = 19m, SickLeaveBalance = 13m, IndemnityBalance = 110m
            },
            new()
            {
                EmployeeId = "EMP008", FullName = "Mariam Abdullah", Position = "Junior Developer",
                Department = "Information Technology", JoinDate = new DateTime(2024, 1, 15),
                Email = "mariam.a@gulftech.bh", Phone = "+973 3323 4567", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "010115345",
                DateOfBirth = new DateTime(2001, 1, 15), Gender = "Female", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 850m,
                BasicSalary = 600m, HousingAllowance = 100m, TransportAllowance = 150m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 21, LeaveDays = 1,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 95.5m,
                SocialInsurance = 51m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Al Salam Bank", AccountNumber = "9999000011", IBAN = "BH90 ASBK 0000 9999 0000 11",
                AnnualLeaveBalance = 13m, SickLeaveBalance = 8m, IndemnityBalance = 15m
            },
            new()
            {
                EmployeeId = "EMP009", FullName = "Ali Salman", Position = "IT Manager",
                Department = "Information Technology", JoinDate = new DateTime(2018, 4, 1),
                Email = "ali.s@gulftech.bh", Phone = "+973 3345 6789", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "880401678",
                DateOfBirth = new DateTime(1988, 4, 1), Gender = "Male", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 2200m,
                BasicSalary = 1500m, HousingAllowance = 500m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 20, LeaveDays = 2,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 90.9m,
                SocialInsurance = 132m, IncomeTax = 0m, LoanDeduction = 300m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "National Bank of Bahrain", AccountNumber = "1234567890", IBAN = "BH12 NBOB 0000 1234 5678 90",
                AnnualLeaveBalance = 25m, SickLeaveBalance = 18m, IndemnityBalance = 220m
            },
            new()
            {
                EmployeeId = "EMP010", FullName = "Aysha Jamal", Position = "Cloud Architect",
                Department = "Information Technology", JoinDate = new DateTime(2021, 3, 22),
                Email = "aysha.j@gulftech.bh", Phone = "+973 3378 9012", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "920322789",
                DateOfBirth = new DateTime(1992, 3, 22), Gender = "Female", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1900m,
                BasicSalary = 1300m, HousingAllowance = 400m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 114m, IncomeTax = 0m, LoanDeduction = 150m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Ahli United Bank", AccountNumber = "2468135790", IBAN = "BH24 AUBK 0000 2468 1357 90",
                AnnualLeaveBalance = 18m, SickLeaveBalance = 12m, IndemnityBalance = 95m
            },
            new()
            {
                EmployeeId = "EMP011", FullName = "John Smith", Position = "Senior Developer",
                Department = "Information Technology", JoinDate = new DateTime(2020, 8, 15),
                Email = "john.s@gulftech.bh", Phone = "+973 3399 8877", Citizenship = "American",
                Nationality = "American", WorkPermitNumber = "WP-2020-0156", CPRNumber = "",
                DateOfBirth = new DateTime(1985, 8, 15), Gender = "Male", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 2500m,
                BasicSalary = 1800m, HousingAllowance = 500m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 0m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Citi Bank", AccountNumber = "9876543210", IBAN = "BH98 CITI 0000 9876 5432 10",
                AnnualLeaveBalance = 30m, SickLeaveBalance = 20m, IndemnityBalance = 150m
            },
            new()
            {
                EmployeeId = "EMP012", FullName = "Priya Sharma", Position = "Business Analyst",
                Department = "Information Technology", JoinDate = new DateTime(2021, 12, 1),
                Email = "priya.s@gulftech.bh", Phone = "+973 3355 6644", Citizenship = "Indian",
                Nationality = "Indian", WorkPermitNumber = "WP-2021-0234", CPRNumber = "",
                DateOfBirth = new DateTime(1990, 12, 1), Gender = "Female", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1200m,
                BasicSalary = 800m, HousingAllowance = 250m, TransportAllowance = 150m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 21, LeaveDays = 1,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 95.5m,
                SocialInsurance = 0m, IncomeTax = 0m, LoanDeduction = 100m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "HSBC", AccountNumber = "5555666677", IBAN = "BH55 HSBC 0000 5555 6666 77",
                AnnualLeaveBalance = 20m, SickLeaveBalance = 15m, IndemnityBalance = 60m
            },
            new()
            {
                EmployeeId = "EMP013", FullName = "Mohammed Ali", Position = "Project Manager",
                Department = "Operations", JoinDate = new DateTime(2019, 5, 10),
                Email = "mohammed.a@gulftech.bh", Phone = "+973 3377 5533", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "890510123",
                DateOfBirth = new DateTime(1989, 5, 10), Gender = "Male", MaritalStatus = "Married",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 2000m,
                BasicSalary = 1400m, HousingAllowance = 400m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 120m, IncomeTax = 0m, LoanDeduction = 200m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "BBK", AccountNumber = "7777888899", IBAN = "BH77 BBKU 0000 7777 8888 99",
                AnnualLeaveBalance = 22m, SickLeaveBalance = 16m, IndemnityBalance = 160m
            },
            new()
            {
                EmployeeId = "EMP014", FullName = "Rachel Green", Position = "HR Manager",
                Department = "Human Resources", JoinDate = new DateTime(2020, 2, 20),
                Email = "rachel.g@gulftech.bh", Phone = "+973 3366 4422", Citizenship = "British",
                Nationality = "British", WorkPermitNumber = "WP-2020-0089", CPRNumber = "",
                DateOfBirth = new DateTime(1987, 2, 20), Gender = "Female", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1800m,
                BasicSalary = 1200m, HousingAllowance = 400m, TransportAllowance = 200m, OtherAllowances = 0m,
                PerformanceRating = "Excellent", Status = "Active", WorkingDays = 22, LeaveDays = 0,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 100m,
                SocialInsurance = 0m, IncomeTax = 0m, LoanDeduction = 0m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Standard Chartered", AccountNumber = "3333444455", IBAN = "BH33 SCBL 0000 3333 4444 55",
                AnnualLeaveBalance = 28m, SickLeaveBalance = 18m, IndemnityBalance = 120m
            },
            new()
            {
                EmployeeId = "EMP015", FullName = "Hassan Khalaf", Position = "Accountant",
                Department = "Finance", JoinDate = new DateTime(2021, 9, 15),
                Email = "hassan.k@gulftech.bh", Phone = "+973 3355 3311", Citizenship = "Bahraini",
                Nationality = "Bahraini", WorkPermitNumber = "", CPRNumber = "930915678",
                DateOfBirth = new DateTime(1993, 9, 15), Gender = "Male", MaritalStatus = "Single",
                EmploymentType = "Full-time", ContractType = "Permanent", MonthlySalary = 1300m,
                BasicSalary = 900m, HousingAllowance = 250m, TransportAllowance = 150m, OtherAllowances = 0m,
                PerformanceRating = "Good", Status = "Active", WorkingDays = 20, LeaveDays = 2,
                AbsentDays = 0, LateDays = 0, AttendancePercentage = 90.9m,
                SocialInsurance = 78m, IncomeTax = 0m, LoanDeduction = 50m, AdvanceDeduction = 0m, OtherDeductions = 0m,
                BankName = "Al Salam Bank", AccountNumber = "6666777788", IBAN = "BH66 ASBK 0000 6666 7777 88",
                AnnualLeaveBalance = 15m, SickLeaveBalance = 10m, IndemnityBalance = 70m
            }
        };
    }

    /// <summary>
    /// Calculate employee summary statistics
    /// </summary>
    private static EmployeeReportSummary CalculateEmployeeSummary(List<ComprehensiveEmployee> employees)
    {
        var activeEmployees = employees.Count(e => e.Status == "Active");
        var onLeaveEmployees = employees.Count(e => e.Status == "On Leave");
        var terminatedEmployees = employees.Count(e => e.Status == "Terminated");
        var maleEmployees = employees.Count(e => e.Gender == "Male");
        var femaleEmployees = employees.Count(e => e.Gender == "Female");
        var fullTimeEmployees = employees.Count(e => e.EmploymentType == "Full-time");
        var partTimeEmployees = employees.Count(e => e.EmploymentType == "Part-time");
        var contractEmployees = employees.Count(e => e.EmploymentType == "Contract");

        return new EmployeeReportSummary
        {
            TotalEmployees = employees.Count,
            ActiveEmployees = activeEmployees,
            OnLeaveEmployees = onLeaveEmployees,
            TerminatedEmployees = terminatedEmployees,
            TotalSalaryExpense = employees.Sum(e => e.MonthlySalary),
            AverageSalary = employees.Any() ? employees.Average(e => e.MonthlySalary) : 0,
            AverageYearsOfService = employees.Any() ? (decimal)employees.Average(e => e.YearsOfService) : 0,
            OverallAttendanceRate = employees.Any() ? employees.Average(e => e.AttendancePercentage) : 0,
            TotalDepartments = employees.Select(e => e.Department).Distinct().Count(),
            TotalCitizenshipCategories = employees.Select(e => e.Citizenship).Distinct().Count(),
            MaleEmployees = maleEmployees,
            FemaleEmployees = femaleEmployees,
            FullTimeEmployees = fullTimeEmployees,
            PartTimeEmployees = partTimeEmployees,
            ContractEmployees = contractEmployees
        };
    }

    /// <summary>
    /// Generate department-wise analysis
    /// </summary>
    private static List<DepartmentAnalysis> GenerateDepartmentAnalysis(List<ComprehensiveEmployee> employees)
    {
        return employees
            .GroupBy(e => e.Department)
            .Select(g => new DepartmentAnalysis
            {
                DepartmentName = g.Key,
                EmployeeCount = g.Count(),
                ActiveEmployees = g.Count(e => e.Status == "Active"),
                TotalSalaryExpense = g.Sum(e => e.MonthlySalary),
                AverageSalary = g.Average(e => e.MonthlySalary),
                AverageYearsOfService = (decimal)g.Average(e => e.YearsOfService),
                CitizenshipBreakdown = g.GroupBy(e => e.Citizenship)
                    .Select(cb => new CitizenshipBreakdown
                    {
                        Citizenship = cb.Key,
                        Count = cb.Count(),
                        Percentage = (decimal)cb.Count() / g.Count() * 100
                    }).ToList(),
                PerformanceBreakdown = g.GroupBy(e => e.PerformanceRating)
                    .Select(pb => new PerformanceBreakdown
                    {
                        Rating = pb.Key,
                        Count = pb.Count(),
                        Percentage = (decimal)pb.Count() / g.Count() * 100
                    }).ToList(),
                AttendanceRate = g.Average(e => e.AttendancePercentage),
                DepartmentHead = g.OrderByDescending(e => e.JoinDate).First().FullName
            }).ToList();
    }

    /// <summary>
    /// Generate citizenship-wise analysis
    /// </summary>
    private static List<CitizenshipAnalysis> GenerateCitizenshipAnalysis(List<ComprehensiveEmployee> employees)
    {
        var totalEmployees = employees.Count;
        return employees
            .GroupBy(e => e.Citizenship)
            .Select(g => new CitizenshipAnalysis
            {
                Citizenship = g.Key,
                EmployeeCount = g.Count(),
                PercentageOfTotal = (decimal)g.Count() / totalEmployees * 100,
                TotalSalaryExpense = g.Sum(e => e.MonthlySalary),
                AverageSalary = g.Average(e => e.MonthlySalary),
                DepartmentBreakdown = g.GroupBy(e => e.Department)
                    .Select(db => new DepartmentBreakdown
                    {
                        Department = db.Key,
                        Count = db.Count(),
                        Percentage = (decimal)db.Count() / g.Count() * 100
                    }).ToList(),
                GenderBreakdown = g.GroupBy(e => e.Gender)
                    .Select(gb => new GenderBreakdown
                    {
                        Gender = gb.Key,
                        Count = gb.Count(),
                        Percentage = (decimal)gb.Count() / g.Count() * 100
                    }).ToList(),
                AverageYearsOfService = (decimal)g.Average(e => e.YearsOfService)
            }).OrderByDescending(c => c.EmployeeCount).ToList();
    }

    /// <summary>
    /// Generate sample payslip data for an employee
    /// </summary>
    private static EmployeePayslipData GenerateSamplePayslipData(ComprehensiveEmployee employee)
    {
        var earnings = new List<EarningsItem>
        {
            new() { Description = "Basic Salary", Amount = employee.BasicSalary },
            new() { Description = "Housing Allowance", Amount = employee.HousingAllowance },
            new() { Description = "Transport Allowance", Amount = employee.TransportAllowance }
        };

        if (employee.OtherAllowances > 0)
        {
            earnings.Add(new EarningsItem { Description = "Other Allowances", Amount = employee.OtherAllowances });
        }

        var deductions = new List<DeductionItem>();
        if (employee.SocialInsurance > 0)
            deductions.Add(new DeductionItem { Description = "Social Insurance", Amount = employee.SocialInsurance });
        if (employee.IncomeTax > 0)
            deductions.Add(new DeductionItem { Description = "Income Tax", Amount = employee.IncomeTax });
        if (employee.LoanDeduction > 0)
            deductions.Add(new DeductionItem { Description = "Loan Repayment", Amount = employee.LoanDeduction });
        if (employee.AdvanceDeduction > 0)
            deductions.Add(new DeductionItem { Description = "Advance Deduction", Amount = employee.AdvanceDeduction });
        if (employee.OtherDeductions > 0)
            deductions.Add(new DeductionItem { Description = "Other Deductions", Amount = employee.OtherDeductions });

        return new EmployeePayslipData
        {
            PayslipNumber = $"PAY-{DateTime.Now:yyyy-MM}-001",
            PayPeriod = "October 2025",
            PayDate = new DateTime(2025, 10, 31),
            WorkingDays = employee.WorkingDays,
            TotalDays = 31,
            Employee = employee,
            Earnings = earnings,
            Deductions = deductions,
            Summary = new PayslipSummary
            {
                TotalEarnings = earnings.Sum(e => e.Amount),
                TotalDeductions = deductions.Sum(d => d.Amount),
                GrossPay = employee.GrossPay,
                NetPay = employee.NetPay
            },
            BankDetails = new BankDetails
            {
                BankName = employee.BankName,
                AccountName = employee.FullName,
                AccountNumber = employee.AccountNumber,
                IBAN = employee.IBAN
            },
            BenefitBalance = new List<BenefitBalance>
            {
                new() { BenefitType = "Annual Leave", BalanceAmount = employee.AnnualLeaveBalance },
                new() { BenefitType = "Sick Leave", BalanceAmount = employee.SickLeaveBalance },
                new() { BenefitType = "Indemnity", BalanceAmount = employee.IndemnityBalance }
            },
            PreparedBy = "Layla Ahmed - HR Manager"
        };
    }

    /// <summary>
    /// Get report title based on report type
    /// </summary>
    private static string GetReportTitle(EmployeeReportType reportType)
    {
        return reportType switch
        {
            EmployeeReportType.Merged => "Comprehensive Employee Report with Payslip",
            EmployeeReportType.Listing => "Complete Employee Listing Report",
            EmployeeReportType.Citizenship => "Employee Count by Citizenship Report",
            EmployeeReportType.Department => "Department-wise Employee Analysis Report",
            _ => "Employee Report"
        };
    }
}
