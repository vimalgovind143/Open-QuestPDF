using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

public class ReceiptDocument : IDocument
{
    private ReceiptModel Model { get; }

    public ReceiptDocument(ReceiptModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A5);
            page.Margin(30);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(10));

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
            container.AlignCenter().AlignMiddle().Width(250).Image(watermark);
        }
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);

            column.Item().AlignCenter().Text("PAYMENT RECEIPT")
                .FontSize(22)
                .Bold()
                .FontColor(Colors.Green.Darken2);

            column.Item().BorderBottom(2).BorderColor(Colors.Green.Darken2).PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(Model.Company.CompanyName).FontSize(14).SemiBold();
                    col.Item().Text(Model.Company.Address).FontSize(9);
                    col.Item().Text($"{Model.Company.City}, {Model.Company.Country}").FontSize(9);
                    col.Item().Text($"Phone: {Model.Company.Phone}").FontSize(9);
                    col.Item().Text($"Email: {Model.Company.Email}").FontSize(9);
                });

                // Logo in header
                row.ConstantItem(70).Column(logoCol =>
                {
                    var logo = ImageHelper.GetCompanyLogo();
                    if (logo != null && logo.Length > 0)
                    {
                        logoCol.Item().Height(50).Image(logo, ImageScaling.FitArea);
                    }
                });

                row.ConstantItem(150).Column(col =>
                {
                    col.Spacing(2);
                    col.Item().Background(Colors.Green.Lighten4).Padding(8).Column(innerCol =>
                    {
                        innerCol.Item().DefaultTextStyle(x => x.FontSize(10)).Text(text =>
                        {
                            text.Span("Receipt No: ").SemiBold();
                            text.Span(Model.ReceiptNumber).FontColor(Colors.Green.Darken2);
                        });

                        innerCol.Item().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                        {
                            text.Span("Date: ").SemiBold();
                            text.Span(Model.ReceiptDate.ToString("dd-MMM-yyyy"));
                        });

                        if (!string.IsNullOrEmpty(Model.RelatedInvoiceNumber))
                        {
                            innerCol.Item().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                            {
                                text.Span("Invoice: ").SemiBold();
                                text.Span(Model.RelatedInvoiceNumber);
                            });
                        }
                    });
                });
            });

            column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(8).Column(col =>
            {
                col.Item().Text("Received From").FontSize(10).SemiBold().FontColor(Colors.Green.Darken1);
                col.Item().PaddingTop(3).Text(Model.Customer.Name).FontSize(11).SemiBold();
                
                if (!string.IsNullOrEmpty(Model.Customer.CompanyName))
                    col.Item().Text(Model.Customer.CompanyName).FontSize(10);
                
                if (!string.IsNullOrEmpty(Model.Customer.Address))
                    col.Item().Text(Model.Customer.Address).FontSize(9);
                
                if (!string.IsNullOrEmpty(Model.Customer.Phone))
                    col.Item().Text($"Phone: {Model.Customer.Phone}").FontSize(9);
            });
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(10);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);
                    columns.RelativeColumn();
                    columns.ConstantColumn(120);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("#");
                    header.Cell().Element(HeaderStyle).Text("Description");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Amount (BHD)");

                    IContainer HeaderStyle(IContainer c) => c
                        .Background(Colors.Green.Darken2)
                        .Padding(6)
                        .DefaultTextStyle(x => x.FontSize(10).SemiBold().FontColor(Colors.White));
                });

                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.ItemNo.ToString());
                    table.Cell().Element(CellStyle).Text(item.Description);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Amount:N3}");

                    IContainer CellStyle(IContainer c) => c
                        .Border(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Padding(6);
                }
            });

            column.Item().AlignRight().Background(Colors.Green.Darken3).Padding(12).Column(col =>
            {
                col.Item().Text(text =>
                {
                    text.Span("TOTAL AMOUNT RECEIVED: ").FontSize(12).SemiBold().FontColor(Colors.White);
                    text.Span($"BHD {Model.TotalAmount:N3}").FontSize(14).Bold().FontColor(Colors.White);
                });
            });

            column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Payment Method").FontSize(9).SemiBold();
                    col.Item().Text(Model.PaymentMethod).FontSize(10);
                });

                if (!string.IsNullOrEmpty(Model.ReferenceNumber))
                {
                    row.ConstantItem(20);
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Reference Number").FontSize(9).SemiBold();
                        col.Item().Text(Model.ReferenceNumber).FontSize(10);
                    });
                }
            });

            if (!string.IsNullOrEmpty(Model.Notes))
            {
                column.Item().Background(Colors.Grey.Lighten4).Padding(8).Column(col =>
                {
                    col.Item().Text("Notes").FontSize(9).SemiBold();
                    col.Item().Text(Model.Notes).FontSize(9);
                });
            }

            column.Item().PaddingTop(20).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                        .Text("Received By").FontSize(9).SemiBold();
                    col.Item().Text(Model.ReceivedBy).FontSize(9);
                });

                row.ConstantItem(40);

                row.RelativeItem().Column(col =>
                {
                    var seal = ImageHelper.GetCompanySeal();
                    if (seal != null && seal.Length > 0)
                    {
                        col.Item().Width(60).Height(60).Image(seal, ImageScaling.FitArea);
                    }
                    else
                    {
                        col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                            .Text("Signature").FontSize(9).SemiBold();
                    }
                });
            });
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                var footerLogo = ImageHelper.GetFooterLogo();
                if (footerLogo != null && footerLogo.Length > 0)
                {
                    row.ConstantItem(30).Height(25).Image(footerLogo, ImageScaling.FitArea);
                    row.ConstantItem(8);
                }
                
                row.RelativeItem().Text(Model.Company.CompanyName)
                    .FontSize(8)
                    .FontColor(Colors.Grey.Darken1);
            });
            
            column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(5)
                .AlignCenter().Text("Thank you for your payment!")
                .FontSize(10).Italic().FontColor(Colors.Green.Darken1);
        });
    }
}
