using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

public class StandardTaxInvoiceDocument : IDocument
{
    private StandardTaxInvoiceModel Model { get; }

    public StandardTaxInvoiceDocument(StandardTaxInvoiceModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(40);
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(9));

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
                
                // Add watermark layer
                page.Foreground().Element(ComposeWatermark);
            });
    }

    void ComposeWatermark(IContainer container)
    {
        var watermark = ImageHelper.GetWatermark();
        if (watermark != null && watermark.Length > 0)
        {
            container.AlignCenter().AlignMiddle().Width(400).Image(watermark);
        }
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);

            // Tax Invoice Title
            column.Item().BorderBottom(2).BorderColor(Colors.Blue.Darken2).PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("TAX INVOICE / فاتورة ضريبية")
                        .FontSize(20)
                        .Bold()
                        .FontColor(Colors.Blue.Darken2);
                    
                    col.Item().Text(Model.Seller.CompanyName)
                        .FontSize(14)
                        .SemiBold()
                        .FontColor(Colors.Grey.Darken2);
                    
                    if (!string.IsNullOrEmpty(Model.Seller.CompanyNameArabic))
                    {
                        col.Item().Text(Model.Seller.CompanyNameArabic)
                            .FontSize(12)
                            .FontColor(Colors.Grey.Darken1);
                    }
                });

                row.ConstantItem(120).AlignRight().Column(col =>
                {
                    var logo = ImageHelper.GetCompanyLogo();
                    if (logo != null && logo.Length > 0)
                    {
                        col.Item().Height(60).Image(logo, ImageScaling.FitArea);
                    }
                    else
                    {
                        // Placeholder if no logo exists
                        col.Item().Height(60).Background(Colors.Blue.Lighten4)
                            .AlignCenter().AlignMiddle()
                            .Text("LOGO")
                            .FontSize(14)
                            .FontColor(Colors.Blue.Darken1);
                    }
                });
            });

            // Company and Invoice Details
            column.Item().PaddingTop(15).Row(row =>
            {
                // Seller Information
                row.RelativeItem().Column(col =>
                {
                    col.Spacing(3);
                    
                    col.Item().Text("Seller Details / بيانات البائع")
                        .FontSize(10)
                        .SemiBold()
                        .FontColor(Colors.Blue.Darken1);
                    
                    col.Item().BorderLeft(3).BorderColor(Colors.Blue.Darken1).PaddingLeft(8).Column(innerCol =>
                    {
                        innerCol.Spacing(2);
                        innerCol.Item().Text(Model.Seller.Address).FontSize(8);
                        innerCol.Item().Text($"{Model.Seller.City}, {Model.Seller.Country}").FontSize(8);
                        innerCol.Item().Text($"Phone: {Model.Seller.Phone}").FontSize(8);
                        innerCol.Item().Text($"Email: {Model.Seller.Email}").FontSize(8);
                        if (!string.IsNullOrEmpty(Model.Seller.Fax))
                            innerCol.Item().Text($"Fax: {Model.Seller.Fax}").FontSize(8);
                        
                        innerCol.Item().PaddingTop(3).DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                        {
                            text.Span("VAT No: ").SemiBold();
                            text.Span(Model.Seller.VATRegistrationNumber).FontColor(Colors.Red.Darken1);
                        });
                        
                        innerCol.Item().DefaultTextStyle(x => x.FontSize(8)).Text(text =>
                        {
                            text.Span("CR No: ").SemiBold();
                            text.Span(Model.Seller.CommercialRegistrationNumber);
                        });
                    });
                });

                row.ConstantItem(20);

                // Invoice Information
                row.ConstantItem(180).Column(col =>
                {
                    col.Spacing(3);
                    
                    col.Item().Background(Colors.Blue.Darken2).Padding(5).Text("Invoice Information")
                        .FontSize(9)
                        .SemiBold()
                        .FontColor(Colors.White);
                    
                    col.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Column(innerCol =>
                    {
                        innerCol.Spacing(4);
                        
                        ComposeInfoRow(innerCol, "Invoice No:", Model.TaxInvoiceNumber, true);
                        ComposeInfoRow(innerCol, "Invoice Date:", Model.InvoiceDate.ToString("dd-MMM-yyyy"));
                        ComposeInfoRow(innerCol, "Supply Date:", Model.SupplyDate.ToString("dd-MMM-yyyy"));
                        
                        if (!string.IsNullOrEmpty(Model.PurchaseOrderNumber))
                            ComposeInfoRow(innerCol, "PO Number:", Model.PurchaseOrderNumber);
                        
                        if (!string.IsNullOrEmpty(Model.PaymentTerms))
                            ComposeInfoRow(innerCol, "Payment Terms:", Model.PaymentTerms);
                    });
                });
            });

            // Customer Information
            column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(10).Column(col =>
            {
                col.Spacing(3);
                
                col.Item().Text("Bill To / الفاتورة إلى")
                    .FontSize(10)
                    .SemiBold()
                    .FontColor(Colors.Blue.Darken1);
                
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(innerCol =>
                    {
                        innerCol.Spacing(2);
                        innerCol.Item().Text(Model.Customer.CompanyName).FontSize(10).SemiBold();
                        if (!string.IsNullOrEmpty(Model.Customer.CompanyNameArabic))
                            innerCol.Item().Text(Model.Customer.CompanyNameArabic).FontSize(9);
                        innerCol.Item().Text(Model.Customer.Address).FontSize(8);
                        innerCol.Item().Text($"{Model.Customer.City}, {Model.Customer.Country}").FontSize(8);
                    });
                    
                    row.ConstantItem(200).Column(innerCol =>
                    {
                        innerCol.Spacing(2);
                        innerCol.Item().Text($"Phone: {Model.Customer.Phone}").FontSize(8);
                        innerCol.Item().Text($"Email: {Model.Customer.Email}").FontSize(8);
                        innerCol.Item().PaddingTop(2).DefaultTextStyle(x => x.FontSize(8)).Text(text =>
                        {
                            text.Span("VAT Registration No: ").SemiBold();
                            text.Span(Model.Customer.VATRegistrationNumber).FontColor(Colors.Red.Darken1);
                        });
                        innerCol.Item().DefaultTextStyle(x => x.FontSize(8)).Text(text =>
                        {
                            text.Span("CR No: ").SemiBold();
                            text.Span(Model.Customer.CommercialRegistrationNumber);
                        });
                    });
                });
            });
        });
    }

    void ComposeInfoRow(ColumnDescriptor column, string label, string value, bool highlight = false)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Text(label).FontSize(8).SemiBold();
            row.RelativeItem().Text(value).FontSize(8).FontColor(highlight ? Colors.Red.Darken1 : Colors.Black);
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(10);

            // Items Table
            column.Item().Element(ComposeItemsTable);

            // Totals Section
            column.Item().Element(ComposeTotals);

            // Bank Details
            if (Model.BankDetails != null)
            {
                column.Item().Element(ComposeBankDetails);
            }

            // Terms and Conditions
            if (!string.IsNullOrEmpty(Model.TermsAndConditions))
            {
                column.Item().Element(ComposeTermsAndConditions);
            }

            // Notes
            if (!string.IsNullOrEmpty(Model.Notes))
            {
                column.Item().Element(ComposeNotes);
            }

            // Signature Section
            column.Item().Element(ComposeSignatureSection);
        });
    }

    void ComposeItemsTable(IContainer container)
    {
        container.Table(table =>
        {
            // Define columns
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(20);   // No
                columns.RelativeColumn(4);    // Description
                columns.ConstantColumn(35);   // Qty
                columns.ConstantColumn(30);   // UOM
                columns.RelativeColumn(2);    // Unit Price
                columns.RelativeColumn(2);    // Amount
                columns.ConstantColumn(35);   // VAT%
                columns.RelativeColumn(2);    // Total
            });

            // Header
            table.Header(header =>
            {
                header.Cell().Element(HeaderCellStyle).Text("#");
                header.Cell().Element(HeaderCellStyle).Text("Description");
                header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Qty");
                header.Cell().Element(HeaderCellStyle).AlignCenter().Text("UOM");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Unit Price");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Amount");
                header.Cell().Element(HeaderCellStyle).AlignCenter().Text("VAT%");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Total (BHD)");

                IContainer HeaderCellStyle(IContainer c) => c
                    .Background(Colors.Blue.Darken2)
                    .Padding(4)
                    .DefaultTextStyle(x => x.FontSize(7).SemiBold().FontColor(Colors.White));
            });

            // Items
            foreach (var item in Model.Items)
            {
                table.Cell().Element(CellStyle).Text(item.ItemNo.ToString());
                table.Cell().Element(CellStyle).Text(item.Description);
                table.Cell().Element(CellStyle).AlignCenter().Text(item.Quantity.ToString());
                table.Cell().Element(CellStyle).AlignCenter().Text(item.UnitOfMeasure);
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice:N2}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.TotalBeforeVAT:N2}");
                table.Cell().Element(CellStyle).AlignCenter().Text($"{item.VATPercent:N0}%");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.TotalIncludingVAT:N2}");

                IContainer CellStyle(IContainer c) => c
                    .Border(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .Padding(3)
                    .DefaultTextStyle(x => x.FontSize(7));
            }
        });
    }

    void ComposeTotals(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem();

            row.ConstantItem(300).Column(column =>
            {
                column.Spacing(5);

                // Subtotal
                ComposeTotalRow(column, "Subtotal (excluding VAT)", Model.Subtotal, false);

                // VAT Amount
                ComposeTotalRow(column, "VAT Amount (10%)", Model.TotalVATAmount, false, Colors.Red.Darken1);

                // Grand Total
                column.Item().Background(Colors.Blue.Darken2).Padding(8).Row(totalRow =>
                {
                    totalRow.RelativeItem().Text("Grand Total (including VAT)")
                        .FontSize(11)
                        .SemiBold()
                        .FontColor(Colors.White);
                    
                    totalRow.AutoItem().Text($"BHD {Model.GrandTotal:N3}")
                        .FontSize(12)
                        .Bold()
                        .FontColor(Colors.White);
                });

                // Amount in words
                column.Item().PaddingTop(5).Border(1).BorderColor(Colors.Grey.Lighten1)
                    .Padding(6).DefaultTextStyle(x => x.FontSize(8)).Text(text =>
                    {
                        text.Span("Amount in words: ").SemiBold();
                        text.Span(ConvertToWords(Model.GrandTotal)).Italic();
                    });
            });
        });
    }

    void ComposeTotalRow(ColumnDescriptor column, string label, decimal amount, bool bold = false, string? color = null)
    {
        column.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(6).Row(row =>
        {
            var labelText = row.RelativeItem().Text(label).FontSize(9).FontColor(color ?? Colors.Black);
            if (bold) labelText.SemiBold();
            
            var amountText = row.AutoItem().Text($"BHD {amount:N3}").FontSize(9).FontColor(color ?? Colors.Black);
            if (bold) amountText.Bold();
        });
    }

    void ComposeBankDetails(IContainer container)
    {
        container.Border(1).BorderColor(Colors.Blue.Darken1).Padding(10).Column(column =>
        {
            column.Spacing(3);

            column.Item().Text("Bank Details for Payment / تفاصيل البنك للدفع")
                .FontSize(10)
                .SemiBold()
                .FontColor(Colors.Blue.Darken1);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Spacing(2);
                    ComposeBankDetailRow(col, "Bank Name:", Model.BankDetails!.BankName);
                    ComposeBankDetailRow(col, "Account Name:", Model.BankDetails!.AccountName);
                    ComposeBankDetailRow(col, "Account Number:", Model.BankDetails!.AccountNumber);
                });

                row.ConstantItem(20);

                row.RelativeItem().Column(col =>
                {
                    col.Spacing(2);
                    ComposeBankDetailRow(col, "IBAN:", Model.BankDetails!.IBAN);
                    ComposeBankDetailRow(col, "SWIFT Code:", Model.BankDetails!.SwiftCode);
                    ComposeBankDetailRow(col, "Branch:", Model.BankDetails!.Branch);
                });
            });
        });
    }

    void ComposeBankDetailRow(ColumnDescriptor column, string label, string value)
    {
        column.Item().DefaultTextStyle(x => x.FontSize(8)).Text(text =>
        {
            text.Span(label + " ").SemiBold();
            text.Span(value);
        });
    }

    void ComposeTermsAndConditions(IContainer container)
    {
        container.Background(Colors.Grey.Lighten4).Padding(8).Column(column =>
        {
            column.Spacing(3);
            column.Item().Text("Terms & Conditions").FontSize(9).SemiBold();
            column.Item().Text(Model.TermsAndConditions!).FontSize(7).LineHeight(1.2f);
        });
    }

    void ComposeNotes(IContainer container)
    {
        container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(column =>
        {
            column.Spacing(3);
            column.Item().Text("Notes / ملاحظات").FontSize(9).SemiBold();
            column.Item().Text(Model.Notes!).FontSize(8);
        });
    }

    void ComposeSignatureSection(IContainer container)
    {
        container.PaddingTop(20).Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().BorderTop(1).BorderColor(Colors.Grey.Darken1).PaddingTop(5)
                    .Text("Authorized Signature")
                    .FontSize(8)
                    .SemiBold();
                col.Item().Text("For " + Model.Seller.CompanyName).FontSize(7);
            });

            row.ConstantItem(50);

            row.RelativeItem().Column(col =>
            {
                col.Item().BorderTop(1).BorderColor(Colors.Grey.Darken1).PaddingTop(5)
                    .Text("Date")
                    .FontSize(8)
                    .SemiBold();
            });

            row.ConstantItem(50);

            row.RelativeItem().Column(col =>
            {
                var seal = ImageHelper.GetCompanySeal();
                if (seal != null && seal.Length > 0)
                {
                    col.Item().Width(80).Height(80).Image(seal, ImageScaling.FitArea);
                }
                else
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Grey.Darken1).PaddingTop(5)
                        .Text("Company Stamp")
                        .FontSize(8)
                        .SemiBold();
                }
            });
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);
            
            // Footer with logo and company info
            column.Item().Row(row =>
            {
                // Footer logo
                var footerLogo = ImageHelper.GetFooterLogo();
                if (footerLogo != null && footerLogo.Length > 0)
                {
                    row.ConstantItem(40).Height(30).Image(footerLogo, ImageScaling.FitArea);
                    row.ConstantItem(10); // Spacing
                }
                
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(Model.Seller.CompanyName)
                        .FontSize(8)
                        .SemiBold()
                        .FontColor(Colors.Blue.Darken2);
                    col.Item().Text($"{Model.Seller.Address}, {Model.Seller.City}, {Model.Seller.Country}")
                        .FontSize(7)
                        .FontColor(Colors.Grey.Darken1);
                });
            });
            
            column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(5).Row(row =>
            {
                row.RelativeItem().DefaultTextStyle(x => x.FontSize(7).FontColor(Colors.Grey.Darken1)).Text(text =>
                {
                    text.Span("This is a computer-generated invoice and does not require a signature. | ")
                        .Italic();
                    text.Span("For queries, contact: " + Model.Seller.Email);
                });

                row.AutoItem().AlignRight().DefaultTextStyle(x => x.FontSize(8)).Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
            });
        });
    }

    private string ConvertToWords(decimal amount)
    {
        if (amount == 0) return "Zero Bahraini Dinars Only";

        var dinars = (int)amount;
        var fils = (int)((amount - dinars) * 1000);

        var words = ConvertNumberToWords(dinars) + " Bahraini Dinar";
        if (dinars != 1) words += "s";

        if (fils > 0)
        {
            words += " and " + ConvertNumberToWords(fils) + " Fils";
        }

        return words + " Only";
    }

    private string ConvertNumberToWords(int number)
    {
        if (number == 0) return "Zero";

        var words = "";
        
        if (number >= 1000)
        {
            words += ConvertNumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if (number >= 100)
        {
            words += ConvertNumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }

        return words.Trim();
    }
}
