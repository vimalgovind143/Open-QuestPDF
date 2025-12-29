namespace QuestPDF.WebApiSample.Models;

public class PurchaseOrderModel
{
    public string PONumber { get; set; } = string.Empty;
    public DateTime PODate { get; set; }
    public DateTime RequiredDate { get; set; }
    public string? DeliveryTerms { get; set; }
    public string? PaymentTerms { get; set; }
    public string ShippingMethod { get; set; } = "Standard Delivery";

    // Buyer Information (Company issuing the PO)
    public CompanyInfo Buyer { get; set; } = new();

    // Supplier Information (Company receiving the PO)
    public CompanyInfo Supplier { get; set; } = new();

    // Shipping Address (if different from buyer)
    public ShippingAddress? ShipTo { get; set; }

    // Purchase Order Items
    public List<PurchaseOrderItem> Items { get; set; } = new();

    // Additional Information
    public string? SpecialInstructions { get; set; }
    public string? TermsAndConditions { get; set; }
    public string PreparedBy { get; set; } = string.Empty;
    public string? ApprovedBy { get; set; }

    // Calculated Totals
    public decimal Subtotal => Items.Sum(x => x.TotalAmount);
    public decimal TaxAmount => Items.Sum(x => x.TaxAmount);
    public decimal TotalAmount => Items.Sum(x => x.TotalWithTax);
}

public class ShippingAddress
{
    public string AttentionTo { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? Phone { get; set; }
}

public class PurchaseOrderItem
{
    public int ItemNo { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = "EA";
    public decimal UnitPrice { get; set; }
    public decimal TaxPercent { get; set; }
    public DateTime? ExpectedDeliveryDate { get; set; }

    // Calculated fields
    public decimal TotalAmount => Quantity * UnitPrice;
    public decimal TaxAmount => TotalAmount * (TaxPercent / 100);
    public decimal TotalWithTax => TotalAmount + TaxAmount;
}
