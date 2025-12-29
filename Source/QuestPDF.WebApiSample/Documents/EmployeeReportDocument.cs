using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// Employee Report Document in A4 Portrait
/// Demonstrates portrait orientation for standard vertical document layouts
/// </summary>
public class EmployeeReportDocument : IDocument
{
    private EmployeeReportModel Model { get; }

    public EmployeeReportDocument(EmployeeReportModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // A4 Portrait orientation (default)
            page.Size(PageSizes.A4.Portrait());
            page.Margin(40);
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
            container.AlignCenter().AlignMiddle().Width(400).Image(watermark);
        }
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(10);

            // Company header
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(Model.Company.CompanyName)
                        .FontSize(16)
                        .Bold()
                        .FontColor(Colors.Blue.Darken3);
                    col.Item().Text(Model.Company.Address).FontSize(9);
                    col.Item().Text($"{Model.Company.City}, {Model.Company.Country}").FontSize(9);
                });

                row.ConstantItem(100).Column(logoCol =>
                {
                    var logo = ImageHelper.GetCompanyLogo();
                    if (logo != null && logo.Length > 0)
                    {
                        logoCol.Item().Height(55).Image(logo, ImageScaling.FitArea);
                    }
                });
                
                row.ConstantItem(150).Column(col =>
                {
                    col.Item().AlignRight().Text($"Phone: {Model.Company.Phone}").FontSize(9);
                    col.Item().AlignRight().Text($"Email: {Model.Company.Email}").FontSize(9);
                });
            });

            column.Item().LineHorizontal(2).LineColor(Colors.Blue.Darken3);

            // Report title section
            column.Item().Background(Colors.Blue.Lighten4).Padding(12).Column(col =>
            {
                col.Item().AlignCenter().Text(Model.ReportTitle)
                    .FontSize(18)
                    .Bold()
                    .FontColor(Colors.Blue.Darken3);
                
                col.Item().AlignCenter().Text(Model.Department)
                    .FontSize(12)
                    .SemiBold()
                    .FontColor(Colors.Blue.Darken2);
            });

            // Report metadata
            column.Item().PaddingTop(5).Row(row =>
            {
                row.RelativeItem().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                {
                    text.Span("Report Date: ").SemiBold();
                    text.Span(Model.ReportDate.ToString("dd MMMM yyyy"));
                });

                row.RelativeItem().AlignRight().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                {
                    text.Span("Period: ").SemiBold();
                    text.Span(Model.ReportingPeriod);
                });
            });
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(15);

            // Summary section
            column.Item().Element(ComposeSummary);

            // Employee records table
            column.Item().Element(ComposeEmployeeTable);

            // Remarks section
            if (!string.IsNullOrEmpty(Model.Remarks))
            {
                column.Item().Element(ComposeRemarks);
            }

            // Signatures
            column.Item().Element(ComposeSignatures);
        });
    }

    void ComposeSummary(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Background(Colors.Blue.Darken2).Padding(8)
                .Text("SUMMARY")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.White);

            column.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Row(row =>
            {
                row.RelativeItem().Background(Colors.Blue.Lighten5).Padding(10).Column(col =>
                {
                    col.Item().Text("Total Employees").FontSize(8).FontColor(Colors.Grey.Darken1);
                    col.Item().Text(Model.Summary.TotalEmployees.ToString())
                        .FontSize(16)
                        .Bold()
                        .FontColor(Colors.Blue.Darken3);
                });

                row.RelativeItem().Background(Colors.Green.Lighten5).Padding(10).Column(col =>
                {
                    col.Item().Text("Active").FontSize(8).FontColor(Colors.Grey.Darken1);
                    col.Item().Text(Model.Summary.ActiveEmployees.ToString())
                        .FontSize(16)
                        .Bold()
                        .FontColor(Colors.Green.Darken2);
                });

                row.RelativeItem().Background(Colors.Orange.Lighten5).Padding(10).Column(col =>
                {
                    col.Item().Text("On Leave").FontSize(8).FontColor(Colors.Grey.Darken1);
                    col.Item().Text(Model.Summary.OnLeaveEmployees.ToString())
                        .FontSize(16)
                        .Bold()
                        .FontColor(Colors.Orange.Darken2);
                });

                row.RelativeItem().Background(Colors.Purple.Lighten5).Padding(10).Column(col =>
                {
                    col.Item().Text("Total Salary Expense").FontSize(8).FontColor(Colors.Grey.Darken1);
                    col.Item().Text($"BHD {Model.Summary.TotalSalaryExpense:N0}")
                        .FontSize(14)
                        .Bold()
                        .FontColor(Colors.Purple.Darken2);
                });

                row.RelativeItem().Background(Colors.Teal.Lighten5).Padding(10).Column(col =>
                {
                    col.Item().Text("Average Salary").FontSize(8).FontColor(Colors.Grey.Darken1);
                    col.Item().Text($"BHD {Model.Summary.AverageSalary:N0}")
                        .FontSize(14)
                        .Bold()
                        .FontColor(Colors.Teal.Darken2);
                });
            });
        });
    }

    void ComposeEmployeeTable(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Background(Colors.Blue.Darken2).Padding(8)
                .Text("EMPLOYEE DETAILS")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.White);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(50);   // ID
                    columns.RelativeColumn(2);    // Name
                    columns.RelativeColumn(2);    // Position
                    columns.ConstantColumn(70);   // Join Date
                    columns.ConstantColumn(70);   // Salary
                    columns.ConstantColumn(45);   // Working Days
                    columns.ConstantColumn(45);   // Leave Days
                    columns.ConstantColumn(50);   // Rating
                    columns.ConstantColumn(50);   // Status
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("ID");
                    header.Cell().Element(HeaderStyle).Text("Employee Name");
                    header.Cell().Element(HeaderStyle).Text("Position");
                    header.Cell().Element(HeaderStyle).Text("Join Date");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Salary");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Work Days");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Leave");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Rating");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Status");

                    IContainer HeaderStyle(IContainer c) => c
                        .Background(Colors.Blue.Darken3)
                        .Padding(6)
                        .DefaultTextStyle(x => x.FontSize(8).Bold().FontColor(Colors.White));
                });

                // Employee rows
                foreach (var employee in Model.Employees)
                {
                    var isActive = employee.Status == "Active";
                    var bgColor = isActive ? Colors.White : Colors.Grey.Lighten4;

                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.EmployeeId).FontSize(8);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.FullName).FontSize(9).SemiBold();
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.Position).FontSize(8);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.JoinDate.ToString("dd-MMM-yy")).FontSize(8);
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignRight().Text($"BHD {employee.MonthlySalary:N0}").FontSize(8);
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(employee.WorkingDays.ToString()).FontSize(8);
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(employee.LeaveDays.ToString()).FontSize(8);
                    
                    // Performance rating with color
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(text =>
                    {
                        var color = employee.PerformanceRating == "Excellent" ? Colors.Green.Darken1 :
                                   employee.PerformanceRating == "Good" ? Colors.Blue.Darken1 :
                                   employee.PerformanceRating == "Average" ? Colors.Orange.Darken1 :
                                   Colors.Red.Darken1;
                        
                        text.Span(employee.PerformanceRating).FontSize(8).Bold().FontColor(color);
                    });
                    
                    // Status badge
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(text =>
                    {
                        var color = isActive ? Colors.Green.Darken1 : Colors.Grey.Darken1;
                        text.Span(employee.Status).FontSize(8).Bold().FontColor(color);
                    });

                    IContainer CellStyle(IContainer c, string backgroundColor) => c
                        .Border(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Background(backgroundColor)
                        .Padding(5);
                }
            });
        });
    }

    void ComposeRemarks(IContainer container)
    {
        container.Background(Colors.Yellow.Lighten4).Border(1).BorderColor(Colors.Yellow.Darken2).Padding(10).Column(column =>
        {
            column.Item().Text("Remarks:").FontSize(10).Bold().FontColor(Colors.Yellow.Darken4);
            column.Item().PaddingTop(5).Text(Model.Remarks).FontSize(9).LineHeight(1.3f);
        });
    }

    void ComposeSignatures(IContainer container)
    {
        container.PaddingTop(20).Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                    .Text("Prepared By").FontSize(9).SemiBold();
                col.Item().Text(Model.PreparedBy).FontSize(9);
                col.Item().Text($"Date: {Model.ReportDate:dd-MMM-yyyy}").FontSize(8).FontColor(Colors.Grey.Darken1);
            });

            row.ConstantItem(50);

            row.RelativeItem().Column(col =>
            {
                col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                    .Text("Reviewed By").FontSize(9).SemiBold();
                col.Item().Text(Model.ReviewedBy).FontSize(9);
                col.Item().Text("Signature: ______________").FontSize(8).FontColor(Colors.Grey.Darken1);
            });
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.BorderTop(1).BorderColor(Colors.Blue.Darken2).PaddingTop(5).Row(row =>
        {
            row.RelativeItem().Text("Confidential - For Internal Use Only")
                .FontSize(8)
                .Italic()
                .FontColor(Colors.Red.Darken1);

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
