using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// Product Catalog Document in A4 Landscape
/// Demonstrates landscape orientation for wider content layouts
/// </summary>
public class ProductCatalogDocument : IDocument
{
    private ProductCatalogModel Model { get; }

    public ProductCatalogDocument(ProductCatalogModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // A4 Landscape orientation
            page.Size(PageSizes.A4.Landscape());
            page.Margin(30);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(9));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
            
            // Add watermark
            page.Foreground().Element(ComposeWatermark);
        });
    }

    void ComposeWatermark(IContainer container)
    {
        var watermark = ImageHelper.GetWatermark();
        if (watermark != null && watermark.Length > 0)
        {
            container.AlignCenter().AlignMiddle().Width(450).Image(watermark);
        }
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);

            // Title Section
            column.Item().Background(Colors.Teal.Darken3).Padding(12).Row(row =>
            {
                // Logo on left
                var logo = ImageHelper.GetCompanyLogo();
                if (logo != null && logo.Length > 0)
                {
                    row.ConstantItem(80).Height(60).Image(logo, ImageScaling.FitArea);
                    row.ConstantItem(15);
                }
                
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(Model.CatalogTitle)
                        .FontSize(22)
                        .Bold()
                        .FontColor(Colors.White);
                    
                    col.Item().Text($"{Model.Season} {Model.Year}")
                        .FontSize(14)
                        .FontColor(Colors.Teal.Lighten4);
                });

                row.ConstantItem(200).Column(col =>
                {
                    col.Item().AlignRight().Text(Model.Company.CompanyName)
                        .FontSize(12)
                        .SemiBold()
                        .FontColor(Colors.White);
                    col.Item().AlignRight().Text(Model.Company.Phone)
                        .FontSize(9)
                        .FontColor(Colors.Teal.Lighten3);
                    col.Item().AlignRight().Text(Model.Company.Email)
                        .FontSize(9)
                        .FontColor(Colors.Teal.Lighten3);
                });
            });

            // Valid until banner
            column.Item().Background(Colors.Orange.Darken1).Padding(6).AlignCenter()
                .Text($"Valid Until: {Model.ValidUntil:dd MMMM yyyy}")
                .FontSize(11)
                .Bold()
                .FontColor(Colors.White);
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(15);

            foreach (var category in Model.Categories)
            {
                column.Item().Element(c => ComposeCategory(c, category));
            }

            // Terms and Conditions
            if (!string.IsNullOrEmpty(Model.TermsAndConditions))
            {
                column.Item().PageBreak();
                column.Item().Column(col =>
                {
                    col.Item().Background(Colors.Grey.Darken2).Padding(8)
                        .Text("TERMS AND CONDITIONS")
                        .FontSize(14)
                        .Bold()
                        .FontColor(Colors.White);

                    col.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10)
                        .Text(Model.TermsAndConditions)
                        .FontSize(9)
                        .LineHeight(1.3f);
                });
            }
        });
    }

    void ComposeCategory(IContainer container, ProductCategory category)
    {
        container.Column(column =>
        {
            column.Spacing(8);

            // Category header
            column.Item().Background(Colors.Teal.Darken1).Padding(8).Row(row =>
            {
                row.RelativeItem().Text(category.CategoryName)
                    .FontSize(14)
                    .Bold()
                    .FontColor(Colors.White);
                
                if (!string.IsNullOrEmpty(category.Description))
                {
                    row.RelativeItem().AlignRight().Text(category.Description)
                        .FontSize(10)
                        .Italic()
                        .FontColor(Colors.Teal.Lighten4);
                }
            });

            // Products table
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(80);   // Product Code
                    columns.RelativeColumn(2);    // Product Name
                    columns.RelativeColumn(3);    // Description
                    columns.RelativeColumn(2);    // Specifications
                    columns.ConstantColumn(70);   // List Price
                    columns.ConstantColumn(70);   // Discount Price
                    columns.ConstantColumn(50);   // Unit
                    columns.ConstantColumn(50);   // Min Qty
                    columns.ConstantColumn(80);   // Availability
                    columns.ConstantColumn(70);   // Lead Time
                });

                // Table header
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Code");
                    header.Cell().Element(HeaderStyle).Text("Product Name");
                    header.Cell().Element(HeaderStyle).Text("Description");
                    header.Cell().Element(HeaderStyle).Text("Specifications");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("List Price");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Discount");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Unit");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Min Qty");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Status");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Lead Time");

                    IContainer HeaderStyle(IContainer c) => c
                        .Background(Colors.Teal.Darken2)
                        .Padding(5)
                        .DefaultTextStyle(x => x.FontSize(8).Bold().FontColor(Colors.White));
                });

                // Product rows
                foreach (var product in category.Products)
                {
                    var hasDiscount = product.DiscountPrice.HasValue && product.DiscountPrice.Value < product.ListPrice;
                    
                    table.Cell().Element(CellStyle).Text(product.ProductCode).FontSize(8);
                    table.Cell().Element(CellStyle).Text(product.ProductName).FontSize(9).SemiBold();
                    table.Cell().Element(CellStyle).Text(product.Description).FontSize(8);
                    table.Cell().Element(CellStyle).Text(product.Specifications).FontSize(8);
                    
                    // List price with strikethrough if discount exists
                    table.Cell().Element(CellStyle).AlignRight().Text(text =>
                    {
                        if (hasDiscount)
                        {
                            text.Span($"BHD {product.ListPrice:N2}").Strikethrough().FontSize(8).FontColor(Colors.Grey.Medium);
                        }
                        else
                        {
                            text.Span($"BHD {product.ListPrice:N2}").FontSize(9).Bold();
                        }
                    });
                    
                    // Discount price
                    table.Cell().Element(CellStyle).AlignRight().Text(text =>
                    {
                        if (hasDiscount)
                        {
                            text.Span($"BHD {product.DiscountPrice:N2}").FontSize(9).Bold().FontColor(Colors.Red.Darken1);
                        }
                    });
                    
                    table.Cell().Element(CellStyle).AlignCenter().Text(product.Unit).FontSize(8);
                    table.Cell().Element(CellStyle).AlignCenter().Text(product.MinOrderQuantity.ToString()).FontSize(8);
                    
                    // Availability with color coding
                    table.Cell().Element(CellStyle).AlignCenter().Text(text =>
                    {
                        var color = product.AvailabilityStatus.Contains("Stock") ? Colors.Green.Darken1 :
                                   product.AvailabilityStatus.Contains("Order") ? Colors.Orange.Darken1 :
                                   Colors.Red.Darken1;
                        
                        text.Span(product.AvailabilityStatus).FontSize(8).Bold().FontColor(color);
                    });
                    
                    table.Cell().Element(CellStyle).AlignCenter().Text(product.LeadTime ?? "-").FontSize(8);

                    IContainer CellStyle(IContainer c) => c
                        .Border(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Padding(5);
                }
            });
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.BorderTop(1).BorderColor(Colors.Teal.Darken2).PaddingTop(5).Row(row =>
        {
            row.RelativeItem().DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.Grey.Darken1)).Text(text =>
            {
                text.Span($"{Model.Company.CompanyName} | ");
                text.Span($"{Model.Company.Address}, {Model.Company.City}");
            });

            row.ConstantItem(100).AlignRight().DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.Grey.Darken1)).Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        });
    }
}
