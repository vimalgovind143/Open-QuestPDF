namespace QuestPDF.WebApiSample.Models;

public class ReceiptModel
{
    public string ReceiptNumber { get; set; } = string.Empty;
    public DateTime ReceiptDate { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public string? ReferenceNumber { get; set; }
    public string? RelatedInvoiceNumber { get; set; }

    // Company Information
    public CompanyInfo Company { get; set; } = new();

    // Customer Information
    public CustomerInfo Customer { get; set; } = new();

    // Payment Items
    public List<ReceiptItem> Items { get; set; } = new();

    // Additional Information
    public string? Notes { get; set; }
    public string ReceivedBy { get; set; } = string.Empty;

    // Calculated Totals
    public decimal TotalAmount => Items.Sum(x => x.Amount);
}

public class CustomerInfo
{
    public string Name { get; set; } = string.Empty;
    public string? CompanyName { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? VATNumber { get; set; }
}

public class ReceiptItem
{
    public int ItemNo { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
