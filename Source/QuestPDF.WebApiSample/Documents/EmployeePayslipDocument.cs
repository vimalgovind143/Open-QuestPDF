using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// GCC-compliant Employee Payslip Document
/// Features QR code for authenticity, password protection, and full branding
/// </summary>
public class EmployeePayslipDocument : IDocument
{
    private EmployeePayslipModel Model { get; }

    public EmployeePayslipDocument(EmployeePayslipModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => new DocumentMetadata
    {
        Title = $"Payslip - {Model.Employee.FullName} - {Model.PayPeriod}",
        Author = Model.Company.CompanyName,
        Subject = $"Salary Payslip for {Model.PayPeriod}",
        Creator = "QuestPDF Web API Sample"
    };

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(25);
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
            container.AlignCenter().AlignMiddle().Width(300).Image(watermark);
        }
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);

            // Title and company info with QR code
            column.Item().BorderBottom(2).BorderColor(Colors.Blue.Darken2).PaddingBottom(10).Row(row =>
            {
                // QR Code in top left
                row.ConstantItem(80).Column(qrCol =>
                {
                    var qrCode = QRCodeHelper.GeneratePayslipDataQRCode(
                        Model.PayslipNumber,
                        Model.Employee.EmployeeId,
                        Model.Employee.FullName,
                        Model.Summary.NetPay,
                        Model.PayDate
                    );
                    
                    if (qrCode != null && qrCode.Length > 0)
                    {
                        qrCol.Item().Width(75).Height(75).Image(qrCode, ImageScaling.FitArea);
                        qrCol.Item().Text("Scan to Verify")
                            .FontSize(7)
                            .AlignCenter()
                            .Italic()
                            .FontColor(Colors.Grey.Darken1);
                    }
                });

                row.ConstantItem(10); // Spacing

                // Title and company info
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("EMPLOYEE PAYSLIP")
                        .FontSize(20)
                        .Bold()
                        .FontColor(Colors.Blue.Darken3);

                    col.Item().Text(Model.Company.CompanyName)
                        .FontSize(13)
                        .SemiBold();

                    col.Item().Text(Model.Company.Address)
                        .FontSize(8);
                    col.Item().Text($"{Model.Company.City}, {Model.Company.Country}")
                        .FontSize(8);
                });

                // Logo in header
                row.ConstantItem(80).Column(logoCol =>
                {
                    var logo = ImageHelper.GetCompanyLogo();
                    if (logo != null && logo.Length > 0)
                    {
                        logoCol.Item().Height(60).Image(logo, ImageScaling.FitArea);
                    }
                });
            });

            // Payslip details
            column.Item().Background(Colors.Blue.Lighten5).Padding(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text =>
                    {
                        text.Span("Payslip No: ").SemiBold();
                        text.Span(Model.PayslipNumber);
                    });

                    col.Item().Text(text =>
                    {
                        text.Span("Pay Period: ").SemiBold();
                        text.Span(Model.PayPeriod);
                    });

                    col.Item().Text(text =>
                    {
                        text.Span("Pay Date: ").SemiBold();
                        text.Span(Model.PayDate.ToString("dd-MMM-yyyy"));
                    });
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text =>
                    {
                        text.Span("Working Days: ").SemiBold();
                        text.Span($"{Model.WorkingDays}/{Model.TotalDays}");
                    });

                    col.Item().Text(text =>
                    {
                        text.Span("Net Pay: ").SemiBold().FontColor(Colors.Green.Darken2);
                        text.Span($"BHD {Model.Summary.NetPay:N3}").Bold().FontColor(Colors.Green.Darken2);
                    });
                });
            });
        });
    }

    void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(15);

            // Employee Information
            column.Item().Element(ComposeEmployeeInfo);

            // Earnings and Deductions side by side
            column.Item().Row(row =>
            {
                row.RelativeItem().Element(ComposeEarnings);
                row.ConstantItem(20); // Spacing
                row.RelativeItem().Element(ComposeDeductions);
            });

            // Summary totals
            column.Item().Element(ComposeSummary);

            // Benefit Balance
            column.Item().Element(ComposeBenefitBalance);

            // Bank Details
            column.Item().Element(ComposeBankDetails);

            // Signatures only (QR code moved to header)
            column.Item().Element(ComposeSignatures);
        });
    }

    void ComposeEmployeeInfo(IContainer container)
    {
        container.Background(Colors.Grey.Lighten4).Padding(12).Column(column =>
        {
            column.Item().Text("EMPLOYEE INFORMATION")
                .FontSize(11)
                .SemiBold()
                .FontColor(Colors.Blue.Darken2);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text => { text.Span("Employee ID: ").SemiBold(); text.Span(Model.Employee.EmployeeId); });
                    col.Item().Text(text => { text.Span("Full Name: ").SemiBold(); text.Span(Model.Employee.FullName); });
                    col.Item().Text(text => { text.Span("Position: ").SemiBold(); text.Span(Model.Employee.Position); });
                    col.Item().Text(text => { text.Span("Department: ").SemiBold(); text.Span(Model.Employee.Department); });
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text => { text.Span("Join Date: ").SemiBold(); text.Span(Model.Employee.JoinDate.ToString("dd-MMM-yyyy")); });
                    col.Item().Text(text => { text.Span("Nationality: ").SemiBold(); text.Span(Model.Employee.Nationality); });
                    if (!string.IsNullOrEmpty(Model.Employee.WorkPermitNumber))
                        col.Item().Text(text => { text.Span("Work Permit: ").SemiBold(); text.Span(Model.Employee.WorkPermitNumber); });
                });
            });
        });
    }

    void ComposeEarnings(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("EARNINGS")
                .FontSize(11)
                .SemiBold()
                .FontColor(Colors.Green.Darken2);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(80);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Description");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Amount (BHD)");
                });

                foreach (var earning in Model.Earnings)
                {
                    table.Cell().Element(CellStyle).Text(earning.Description);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{earning.Amount:N3}");
                }

                // Total earnings
                table.Cell().Element(TotalStyle).Text("TOTAL EARNINGS").Bold();
                table.Cell().Element(TotalStyle).AlignRight().Text($"{Model.Summary.TotalEarnings:N3}").Bold();
            });
        });
    }

    void ComposeDeductions(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("DEDUCTIONS")
                .FontSize(11)
                .SemiBold()
                .FontColor(Colors.Red.Darken2);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(80);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Description");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Amount (BHD)");
                });

                foreach (var deduction in Model.Deductions)
                {
                    table.Cell().Element(CellStyle).Text(deduction.Description);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{deduction.Amount:N3}");
                }

                // Total deductions
                table.Cell().Element(TotalStyle).Text("TOTAL DEDUCTIONS").Bold();
                table.Cell().Element(TotalStyle).AlignRight().Text($"{Model.Summary.TotalDeductions:N3}").Bold();
            });
        });
    }

    void ComposeSummary(IContainer container)
    {
        container.Background(Colors.Blue.Lighten5).Padding(15).Column(column =>
        {
            column.Item().Text("PAYSLIP SUMMARY")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.Blue.Darken3)
                .AlignCenter();

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Gross Pay:").SemiBold();
                    col.Item().Text($"BHD {Model.Summary.GrossPay:N3}").FontSize(14).Bold();
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Total Deductions:").SemiBold();
                    col.Item().Text($"BHD {Model.Summary.TotalDeductions:N3}").FontSize(14).Bold().FontColor(Colors.Red.Darken2);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Net Pay:").SemiBold();
                    col.Item().Text($"BHD {Model.Summary.NetPay:N3}").FontSize(16).Bold().FontColor(Colors.Green.Darken3);
                });
            });
        });
    }

    void ComposeBankDetails(IContainer container)
    {
        container.Background(Colors.Grey.Lighten4).Padding(10).Column(column =>
        {
            column.Item().Text("BANK DETAILS FOR SALARY TRANSFER")
                .FontSize(9)
                .SemiBold()
                .FontColor(Colors.Grey.Darken2);

            column.Item().Text($"Bank: {Model.BankDetails.BankName}");
            column.Item().Text($"Account Name: {Model.BankDetails.AccountName}");
            column.Item().Text($"Account Number: {Model.BankDetails.AccountNumber}");
            column.Item().Text($"IBAN: {Model.BankDetails.IBAN}");
        });
    }

    void ComposeBenefitBalance(IContainer container)
    {
        if (Model.BenefitBalance == null || !Model.BenefitBalance.Any())
            return;

        container.Background(Colors.Grey.Lighten4).Padding(12).Column(column =>
        {
            column.Item().Text("BENEFIT BALANCE")
                .FontSize(11)
                .SemiBold()
                .FontColor(Colors.Blue.Darken2);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(80);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Benefit Type");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Balance (BHD)");
                });

                foreach (var benefit in Model.BenefitBalance)
                {
                    table.Cell().Element(CellStyle).Text(benefit.BenefitType);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{benefit.BalanceAmount:N3}");
                }
            });
        });
    }

    void ComposeSignatures(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("This payslip is computer generated and does not require signature.")
                .FontSize(8)
                .Italic()
                .FontColor(Colors.Grey.Darken1);

            column.Item().PaddingTop(15).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(4)
                        .Text("Prepared By").FontSize(8).SemiBold();
                    col.Item().Text(Model.PreparedBy).FontSize(8);
                    col.Item().Text(Model.Company.CompanyName).FontSize(7);
                });

                row.ConstantItem(30);

                row.RelativeItem().Column(col =>
                {
                    var seal = ImageHelper.GetCompanySeal();
                    if (seal != null && seal.Length > 0)
                    {
                        col.Item().Width(50).Height(50).Image(seal, ImageScaling.FitArea);
                        col.Item().Text("Official Seal").FontSize(7).AlignCenter();
                    }
                    else
                    {
                        col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(4)
                            .Text("Company Seal").FontSize(8).SemiBold();
                    }
                });
            });
        });
    }



    void ComposeFooter(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(5).Row(row =>
            {
                var footerLogo = ImageHelper.GetFooterLogo();
                if (footerLogo != null && footerLogo.Length > 0)
                {
                    row.ConstantItem(30).Height(20).Image(footerLogo, ImageScaling.FitArea);
                    row.ConstantItem(8);
                }

                row.RelativeItem().Text(Model.Company.CompanyName)
                    .FontSize(7)
                    .FontColor(Colors.Grey.Darken1);
            });

            column.Item().AlignCenter().Text("This is a confidential document. Keep it secure.")
                .FontSize(7).Italic().FontColor(Colors.Grey.Darken2);
        });
    }

    // Helper methods for consistent styling
    IContainer HeaderStyle(IContainer c) => c
        .Background(Colors.Grey.Darken1)
        .Padding(4)
        .DefaultTextStyle(x => x.FontSize(8).SemiBold().FontColor(Colors.White));

    IContainer CellStyle(IContainer c) => c
        .Border(1)
        .BorderColor(Colors.Grey.Lighten2)
        .Padding(4);

    IContainer TotalStyle(IContainer c) => c
        .Background(Colors.Grey.Lighten3)
        .Border(1)
        .BorderColor(Colors.Grey.Lighten1)
        .Padding(4);
}
