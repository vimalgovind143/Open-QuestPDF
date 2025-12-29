using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// Comprehensive Employee Document that can generate different types of employee reports
/// Supports Merged, Listing, Citizenship, and Department-wise reports
/// </summary>
public class EmployeeMergedDocument : IDocument
{
    private EmployeeDataModel Model { get; }

    public EmployeeMergedDocument(EmployeeDataModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => new DocumentMetadata
    {
        Title = Model.ReportTitle,
        Author = Model.Company.CompanyName,
        Subject = $"{Model.ReportType} Report - {Model.ReportingPeriod}",
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

            // Title and company info with QR code for merged reports
            column.Item().BorderBottom(2).BorderColor(Colors.Blue.Darken2).PaddingBottom(10).Row(row =>
            {
                // QR Code for merged/payslip reports
                if (Model.ReportType == "Merged" && Model.PayslipData != null)
                {
                    row.ConstantItem(80).Column(qrCol =>
                    {
                        var qrCode = QRCodeHelper.GeneratePayslipDataQRCode(
                            Model.PayslipData.PayslipNumber,
                            Model.PayslipData.Employee.EmployeeId,
                            Model.PayslipData.Employee.FullName,
                            Model.PayslipData.Summary.NetPay,
                            Model.PayslipData.PayDate
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
                }

                // Title and company info
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(Model.ReportTitle.ToUpper())
                        .FontSize(18)
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

            // Report details
            column.Item().Background(Colors.Blue.Lighten5).Padding(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text =>
                    {
                        text.Span("Report Type: ").SemiBold();
                        text.Span(Model.ReportType);
                    });

                    col.Item().Text(text =>
                    {
                        text.Span("Report Period: ").SemiBold();
                        text.Span(Model.ReportingPeriod);
                    });

                    col.Item().Text(text =>
                    {
                        text.Span("Report Date: ").SemiBold();
                        text.Span(Model.ReportDate.ToString("dd-MMM-yyyy"));
                    });
                });

                row.RelativeItem().Column(col =>
                {
                    if (Model.Summary.TotalEmployees > 0)
                    {
                        col.Item().Text(text =>
                        {
                            text.Span("Total Employees: ").SemiBold();
                            text.Span(Model.Summary.TotalEmployees.ToString());
                        });

                        col.Item().Text(text =>
                        {
                            text.Span("Active Employees: ").SemiBold();
                            text.Span(Model.Summary.ActiveEmployees.ToString());
                        });

                        col.Item().Text(text =>
                        {
                            text.Span("Total Salary Expense: ").SemiBold().FontColor(Colors.Green.Darken2);
                            text.Span($"BHD {Model.Summary.TotalSalaryExpense:N3}").Bold().FontColor(Colors.Green.Darken2);
                        });
                    }
                });
            });
        });
    }

    void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(15);

            // Summary section
            column.Item().Element(ComposeSummary);

            // Report-specific content
            switch (Model.ReportType)
            {
                case "Merged":
                    column.Item().Element(ComposeMergedReport);
                    break;
                case "Listing":
                    column.Item().Element(ComposeEmployeeListing);
                    break;
                case "Citizenship":
                    column.Item().Element(ComposeCitizenshipReport);
                    break;
                case "Department":
                    column.Item().Element(ComposeDepartmentReport);
                    break;
            }

            // Remarks and signatures
            if (!string.IsNullOrEmpty(Model.Remarks))
            {
                column.Item().Element(ComposeRemarks);
            }

            column.Item().Element(ComposeSignatures);
        });
    }

    void ComposeSummary(IContainer container)
    {
        container.Background(Colors.Blue.Lighten5).Padding(15).Column(column =>
        {
            column.Item().Text("EMPLOYEE SUMMARY")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.Blue.Darken3)
                .AlignCenter();

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Total Employees:").SemiBold();
                    col.Item().Text(Model.Summary.TotalEmployees.ToString()).FontSize(14).Bold();
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Active Employees:").SemiBold();
                    col.Item().Text(Model.Summary.ActiveEmployees.ToString()).FontSize(14).Bold().FontColor(Colors.Green.Darken2);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("On Leave:").SemiBold();
                    col.Item().Text(Model.Summary.OnLeaveEmployees.ToString()).FontSize(14).Bold().FontColor(Colors.Orange.Darken2);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Total Departments:").SemiBold();
                    col.Item().Text(Model.Summary.TotalDepartments.ToString()).FontSize(14).Bold();
                });
            });

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Total Salary Expense:").SemiBold();
                    col.Item().Text($"BHD {Model.Summary.TotalSalaryExpense:N3}").FontSize(14).Bold().FontColor(Colors.Green.Darken3);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Average Salary:").SemiBold();
                    col.Item().Text($"BHD {Model.Summary.AverageSalary:N3}").FontSize(14).Bold();
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Avg Years of Service:").SemiBold();
                    col.Item().Text($"{Model.Summary.AverageYearsOfService:F1} years").FontSize(14).Bold();
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Attendance Rate:").SemiBold();
                    col.Item().Text($"{Model.Summary.OverallAttendanceRate:F1}%").FontSize(14).Bold().FontColor(Colors.Blue.Darken2);
                });
            });
        });
    }

    void ComposeMergedReport(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(15);

            // Employee payslip section
            if (Model.PayslipData != null)
            {
                column.Item().Element(ComposeEmployeePayslip);
            }

            // Employee listing section
            column.Item().Element(ComposeEmployeeListing);

            // Citizenship analysis
            if (Model.CitizenshipAnalysis.Any())
            {
                column.Item().Element(ComposeCitizenshipReport);
            }

            // Department analysis
            if (Model.DepartmentAnalysis.Any())
            {
                column.Item().Element(ComposeDepartmentReport);
            }
        });
    }

    void ComposeEmployeePayslip(IContainer container)
    {
        if (Model.PayslipData == null) return;

        var payslip = Model.PayslipData;
        container.Background(Colors.Grey.Lighten4).Padding(12).Column(column =>
        {
            column.Item().Text("EMPLOYEE PAYSLIP")
                .FontSize(11)
                .SemiBold()
                .FontColor(Colors.Blue.Darken2);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text => { text.Span("Employee ID: ").SemiBold(); text.Span(payslip.Employee.EmployeeId); });
                    col.Item().Text(text => { text.Span("Full Name: ").SemiBold(); text.Span(payslip.Employee.FullName); });
                    col.Item().Text(text => { text.Span("Position: ").SemiBold(); text.Span(payslip.Employee.Position); });
                    col.Item().Text(text => { text.Span("Department: ").SemiBold(); text.Span(payslip.Employee.Department); });
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(text => { text.Span("Payslip No: ").SemiBold(); text.Span(payslip.PayslipNumber); });
                    col.Item().Text(text => { text.Span("Pay Period: ").SemiBold(); text.Span(payslip.PayPeriod); });
                    col.Item().Text(text => { text.Span("Net Pay: ").SemiBold().FontColor(Colors.Green.Darken2); text.Span($"BHD {payslip.Summary.NetPay:N3}").Bold().FontColor(Colors.Green.Darken2); });
                });
            });

            // Earnings and Deductions
            column.Item().Row(row =>
            {
                row.RelativeItem().Element(c => ComposeEarningsTable(c, payslip.Earnings, payslip.Summary.TotalEarnings));
                row.ConstantItem(20);
                row.RelativeItem().Element(c => ComposeDeductionsTable(c, payslip.Deductions, payslip.Summary.TotalDeductions));
            });
        });
    }

    void ComposeEarningsTable(IContainer container, List<EarningsItem> earnings, decimal total)
    {
        container.Column(column =>
        {
            column.Item().Text("EARNINGS")
                .FontSize(10)
                .SemiBold()
                .FontColor(Colors.Green.Darken2);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(70);
                });

                foreach (var earning in earnings)
                {
                    table.Cell().Element(CellStyle).Text(earning.Description).FontSize(8);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{earning.Amount:N3}").FontSize(8);
                }

                table.Cell().Element(TotalStyle).Text("TOTAL").Bold().FontSize(8);
                table.Cell().Element(TotalStyle).AlignRight().Text($"{total:N3}").Bold().FontSize(8);
            });
        });
    }

    void ComposeDeductionsTable(IContainer container, List<DeductionItem> deductions, decimal total)
    {
        container.Column(column =>
        {
            column.Item().Text("DEDUCTIONS")
                .FontSize(10)
                .SemiBold()
                .FontColor(Colors.Red.Darken2);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.ConstantColumn(70);
                });

                foreach (var deduction in deductions)
                {
                    table.Cell().Element(CellStyle).Text(deduction.Description).FontSize(8);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{deduction.Amount:N3}").FontSize(8);
                }

                table.Cell().Element(TotalStyle).Text("TOTAL").Bold().FontSize(8);
                table.Cell().Element(TotalStyle).AlignRight().Text($"{total:N3}").Bold().FontSize(8);
            });
        });
    }

    void ComposeEmployeeListing(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Background(Colors.Blue.Darken2).Padding(8)
                .Text("EMPLOYEE LISTING")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.White);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(40);   // ID
                    columns.RelativeColumn(2);    // Name
                    columns.RelativeColumn(1.5f); // Position
                    columns.RelativeColumn(1);    // Department
                    columns.ConstantColumn(60);   // Citizenship
                    columns.ConstantColumn(60);   // Join Date
                    columns.ConstantColumn(70);   // Salary
                    columns.ConstantColumn(40);   // Rating
                    columns.ConstantColumn(40);   // Status
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("ID").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Employee Name").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Position").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Department").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Citizenship").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Join Date").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Salary").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Rating").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Status").FontSize(7);
                });

                // Employee rows
                foreach (var employee in Model.Employees.Take(20)) // Limit to 20 for readability
                {
                    var isActive = employee.Status == "Active";
                    var bgColor = isActive ? Colors.White : Colors.Grey.Lighten4;

                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.EmployeeId).FontSize(7);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.FullName).FontSize(8).SemiBold();
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.Position).FontSize(7);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.Department).FontSize(7);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.Citizenship).FontSize(7);
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(employee.JoinDate.ToString("dd-MMM-yy")).FontSize(7);
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignRight().Text($"BHD {employee.MonthlySalary:N0}").FontSize(7);
                    
                    // Performance rating with color
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(text =>
                    {
                        var color = employee.PerformanceRating == "Excellent" ? Colors.Green.Darken1 :
                                   employee.PerformanceRating == "Good" ? Colors.Blue.Darken1 :
                                   employee.PerformanceRating == "Average" ? Colors.Orange.Darken1 :
                                   Colors.Red.Darken1;
                        
                        text.Span(employee.PerformanceRating).FontSize(7).Bold().FontColor(color);
                    });
                    
                    // Status badge
                    table.Cell().Element(c => CellStyle(c, bgColor)).AlignCenter().Text(text =>
                    {
                        var color = isActive ? Colors.Green.Darken1 : Colors.Grey.Darken1;
                        text.Span(employee.Status).FontSize(7).Bold().FontColor(color);
                    });
                }
            });

            if (Model.Employees.Count > 20)
            {
                column.Item().AlignCenter().Text($"... and {Model.Employees.Count - 20} more employees")
                    .FontSize(8)
                    .Italic()
                    .FontColor(Colors.Grey.Darken1);
            }
        });
    }

    void ComposeCitizenshipReport(IContainer container)
    {
        if (!Model.CitizenshipAnalysis.Any()) return;

        container.Column(column =>
        {
            column.Item().Background(Colors.Blue.Darken2).Padding(8)
                .Text("EMPLOYEE COUNT BY CITIZENSHIP")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.White);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);    // Citizenship
                    columns.ConstantColumn(60);   // Count
                    columns.ConstantColumn(70);   // Percentage
                    columns.ConstantColumn(80);   // Avg Salary
                    columns.RelativeColumn(1.5f); // Departments
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Citizenship").FontSize(8);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Count").FontSize(8);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Percentage").FontSize(8);
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Avg Salary").FontSize(8);
                    header.Cell().Element(HeaderStyle).Text("Departments").FontSize(8);
                });

                // Citizenship rows
                foreach (var citizenship in Model.CitizenshipAnalysis)
                {
                    table.Cell().Element(CellStyle).Text(citizenship.Citizenship).FontSize(9).SemiBold();
                    table.Cell().Element(CellStyle).AlignCenter().Text(citizenship.EmployeeCount.ToString()).FontSize(9);
                    table.Cell().Element(CellStyle).AlignCenter().Text($"{citizenship.PercentageOfTotal:F1}%").FontSize(9);
                    table.Cell().Element(CellStyle).AlignRight().Text($"BHD {citizenship.AverageSalary:N0}").FontSize(9);
                    table.Cell().Element(CellStyle).Text(string.Join(", ", citizenship.DepartmentBreakdown.Take(3).Select(d => d.Department))).FontSize(7);
                }
            });

            // Citizenship breakdown details
            column.Item().Element(ComposeCitizenshipBreakdown);
        });
    }

    void ComposeCitizenshipBreakdown(IContainer container)
    {
        container.Background(Colors.Grey.Lighten4).Padding(10).Column(column =>
        {
            column.Item().Text("CITIZENSHIP BREAKDOWN DETAILS")
                .FontSize(10)
                .SemiBold()
                .FontColor(Colors.Blue.Darken2);

            foreach (var citizenship in Model.CitizenshipAnalysis.Take(3)) // Show top 3
            {
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"{citizenship.Citizenship} ({citizenship.EmployeeCount} employees)")
                            .FontSize(9).SemiBold();

                        // Gender breakdown
                        col.Item().Row(genderRow =>
                        {
                            genderRow.RelativeItem().Text("Gender: ").FontSize(8);
                            foreach (var gender in citizenship.GenderBreakdown)
                            {
                                genderRow.RelativeItem().Text($"{gender.Gender}: {gender.Count} ({gender.Percentage:F1}%)").FontSize(8);
                            }
                        });

                        // Department breakdown
                        col.Item().Row(deptRow =>
                        {
                            deptRow.RelativeItem().Text("Depts: ").FontSize(8);
                            foreach (var dept in citizenship.DepartmentBreakdown.Take(3))
                            {
                                deptRow.RelativeItem().Text($"{dept.Department}: {dept.Count}").FontSize(8);
                            }
                        });
                    });

                    row.ConstantItem(10);
                });
            }
        });
    }

    void ComposeDepartmentReport(IContainer container)
    {
        if (!Model.DepartmentAnalysis.Any()) return;

        container.Column(column =>
        {
            column.Item().Background(Colors.Blue.Darken2).Padding(8)
                .Text("DEPARTMENT-WISE EMPLOYEE ANALYSIS")
                .FontSize(12)
                .Bold()
                .FontColor(Colors.White);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);    // Department
                    columns.ConstantColumn(50);   // Employees
                    columns.ConstantColumn(50);   // Active
                    columns.ConstantColumn(80);   // Total Salary
                    columns.ConstantColumn(70);   // Avg Salary
                    columns.ConstantColumn(60);   // Attendance
                    columns.ConstantColumn(80);   // Department Head
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("Department").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Total").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Active").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Total Salary").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Avg Salary").FontSize(7);
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Attendance").FontSize(7);
                    header.Cell().Element(HeaderStyle).Text("Department Head").FontSize(7);
                });

                // Department rows
                foreach (var dept in Model.DepartmentAnalysis)
                {
                    table.Cell().Element(CellStyle).Text(dept.DepartmentName).FontSize(8).SemiBold();
                    table.Cell().Element(CellStyle).AlignCenter().Text(dept.EmployeeCount.ToString()).FontSize(8);
                    table.Cell().Element(CellStyle).AlignCenter().Text(dept.ActiveEmployees.ToString()).FontSize(8);
                    table.Cell().Element(CellStyle).AlignRight().Text($"BHD {dept.TotalSalaryExpense:N0}").FontSize(8);
                    table.Cell().Element(CellStyle).AlignRight().Text($"BHD {dept.AverageSalary:N0}").FontSize(8);
                    table.Cell().Element(CellStyle).AlignCenter().Text($"{dept.AttendanceRate:F1}%").FontSize(8);
                    table.Cell().Element(CellStyle).Text(dept.DepartmentHead).FontSize(7);
                }
            });

            // Department breakdown details
            column.Item().Element(ComposeDepartmentBreakdown);
        });
    }

    void ComposeDepartmentBreakdown(IContainer container)
    {
        container.Background(Colors.Grey.Lighten4).Padding(10).Column(column =>
        {
            column.Item().Text("DEPARTMENT BREAKDOWN DETAILS")
                .FontSize(10)
                .SemiBold()
                .FontColor(Colors.Blue.Darken2);

            foreach (var dept in Model.DepartmentAnalysis.Take(3)) // Show top 3
            {
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"{dept.DepartmentName} - {dept.DepartmentHead}")
                            .FontSize(9).SemiBold();

                        col.Item().Text($"Employees: {dept.EmployeeCount} (Active: {dept.ActiveEmployees})")
                            .FontSize(8);

                        col.Item().Text($"Avg Service: {dept.AverageYearsOfService:F1} years, Attendance: {dept.AttendanceRate:F1}%")
                            .FontSize(8);

                        // Citizenship breakdown
                        col.Item().Row(citRow =>
                        {
                            citRow.RelativeItem().Text("Citizenship: ").FontSize(8);
                            foreach (var cit in dept.CitizenshipBreakdown.Take(3))
                            {
                                citRow.RelativeItem().Text($"{cit.Citizenship}: {cit.Count}").FontSize(8);
                            }
                        });

                        // Performance breakdown
                        col.Item().Row(perfRow =>
                        {
                            perfRow.RelativeItem().Text("Performance: ").FontSize(8);
                            foreach (var perf in dept.PerformanceBreakdown.Take(3))
                            {
                                perfRow.RelativeItem().Text($"{perf.Rating}: {perf.Count}").FontSize(8);
                            }
                        });
                    });

                    row.ConstantItem(10);
                });
            }
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

    IContainer CellStyle(IContainer c, string backgroundColor) => c
        .Border(1)
        .BorderColor(Colors.Grey.Lighten2)
        .Background(backgroundColor)
        .Padding(4);

    IContainer TotalStyle(IContainer c) => c
        .Background(Colors.Grey.Lighten3)
        .Border(1)
        .BorderColor(Colors.Grey.Lighten1)
        .Padding(4);
}