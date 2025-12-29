namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Model for A4 Landscape Product Catalog
/// Demonstrates landscape orientation for wider content
/// </summary>
public class ProductCatalogModel
{
    public string CatalogTitle { get; set; } = string.Empty;
    public string Season { get; set; } = string.Empty;
    public int Year { get; set; }
    public DateTime ValidUntil { get; set; }
    
    public CompanyInfo Company { get; set; } = new();
    public List<ProductCategory> Categories { get; set; } = new();
    
    public string? TermsAndConditions { get; set; }
}

public class ProductCategory
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public decimal ListPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Unit { get; set; } = "EA";
    public int MinOrderQuantity { get; set; } = 1;
    public string AvailabilityStatus { get; set; } = "In Stock";
    public string? LeadTime { get; set; }
}
