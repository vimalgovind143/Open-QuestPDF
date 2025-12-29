namespace QuestPDF.WebApiSample.Models;

public class StandardTaxInvoiceModel
{
    public string TaxInvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public DateTime SupplyDate { get; set; }
    public string? PurchaseOrderNumber { get; set; }
    public string? PaymentTerms { get; set; }

    // Seller Information (Supplier)
    public CompanyInfo Seller { get; set; } = new();

    // Customer Information (Recipient)
    public CompanyInfo Customer { get; set; } = new();

    // Invoice Items
    public List<TaxInvoiceItem> Items { get; set; } = new();

    // Payment Information
    public BankDetails? BankDetails { get; set; }

    // Additional Notes
    public string? TermsAndConditions { get; set; }
    public string? Notes { get; set; }

    // Calculated Totals
    public decimal Subtotal => Items.Sum(x => x.TotalBeforeVAT);
    public decimal TotalVATAmount => Items.Sum(x => x.VATAmount);
    public decimal GrandTotal => Items.Sum(x => x.TotalIncludingVAT);
}

public class CompanyInfo
{
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyNameArabic { get; set; } = string.Empty;
    public string VATRegistrationNumber { get; set; } = string.Empty;
    public string CommercialRegistrationNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = "Kingdom of Bahrain";
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Fax { get; set; }
}

public class TaxInvoiceItem
{
    public int ItemNo { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? HSNCode { get; set; }
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = "EA"; // EA = Each
    public decimal UnitPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal VATPercent { get; set; } = 10m; // Standard VAT rate is 10%

    // Calculated fields
    public decimal TotalBeforeDiscount => Quantity * UnitPrice;
    public decimal DiscountAmount => TotalBeforeDiscount * (DiscountPercent / 100);
    public decimal TotalAfterDiscount => TotalBeforeDiscount - DiscountAmount;
    public decimal TotalBeforeVAT => TotalAfterDiscount;
    public decimal VATAmount => TotalBeforeVAT * (VATPercent / 100);
    public decimal TotalIncludingVAT => TotalBeforeVAT + VATAmount;
}

public class BankDetails
{
    public string BankName { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string IBAN { get; set; } = string.Empty;
    public string SwiftCode { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
}
