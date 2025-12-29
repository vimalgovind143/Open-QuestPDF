using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// Enhanced 12-Column Budget Comparison Document in Landscape Mode
/// Features account chart grouping, monthly breakdowns, and variance analysis
/// </summary>
public class EnhancedBudgetComparisonDocument : IDocument
{
    private EnhancedBudgetComparisonModel Model { get; }

    public EnhancedBudgetComparisonDocument(EnhancedBudgetComparisonModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // Use landscape orientation for better column visibility
            page.Size(PageSizes.A4.Landscape());
            page.Margin(30);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Calibri));
            
            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
            
            // Add watermark
            page.Foreground().Element(ComposeWatermark);
        });
    }

    protected virtual void ComposeWatermark(IContainer container)
    {
        var watermark = ImageHelper.GetWatermark();
        if (watermark != null && watermark.Length > 0)
        {
            container.AlignCenter().AlignMiddle().Width(500).Image(watermark);
        }
    }

    protected virtual void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(6);

            // Company logo and title row
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    var logo = ImageHelper.GetCompanyLogo();
                    if (logo != null && logo.Length > 0)
                    {
                        col.Item().Height(40).Image(logo, ImageScaling.FitArea);
                    }
                });

                row.ConstantItem(200).AlignRight().Column(col =>
                {
                    col.Item().AlignRight().Text($"Fiscal Year: {Model.FiscalYear}")
                        .FontSize(10).SemiBold().FontColor(Colors.Blue.Darken2);
                    col.Item().AlignRight().Text($"Generated: {Model.GeneratedDate:dd-MMM-yyyy HH:mm}")
                        .FontSize(8).FontColor(Colors.Grey.Darken1);
                });
            });

            // Report title
            column.Item().AlignCenter().Text(Model.ReportTitle)
                .FontSize(18).Bold().FontColor(Colors.Blue.Darken3);

            // Report subtitle
            if (!string.IsNullOrEmpty(Model.ReportSubtitle))
            {
                column.Item().AlignCenter().Text(Model.ReportSubtitle)
                    .FontSize(11).FontColor(Colors.Grey.Darken1);
            }

            // Date range and key metrics
            column.Item().BorderBottom(2).BorderColor(Colors.Blue.Darken2).PaddingBottom(8).Row(row =>
            {
                row.RelativeItem().Text($"Period: {Model.FromDate:dd-MMM-yyyy} to {Model.ToDate:dd-MMM-yyyy}")
                    .FontSize(9).FontColor(Colors.Grey.Darken2);

                row.RelativeItem().AlignRight().Column(col =>
                {
                    col.Item().AlignRight().Text($"Total Budget: {Model.TotalBudgetAmount:N2} BHD")
                        .FontSize(9).SemiBold().FontColor(Colors.Green.Darken2);
                    col.Item().AlignRight().Text($"Total Actual: {Model.TotalActualAmount:N2} BHD")
                        .FontSize(9).SemiBold().FontColor(Colors.Blue.Darken2);
                    col.Item().AlignRight().Text($"Total Variance: {Model.TotalVarianceAmount:N2} BHD ({Model.TotalVariancePercentage:F1}%)")
                        .FontSize(9).SemiBold().FontColor(GetVarianceColor(Model.TotalVariancePercentage));
                });
            });
        });
    }

    protected virtual void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(8);

            // Executive Summary
            column.Item().Element(ComposeExecutiveSummary);

            // Monthly breakdown table
            column.Item().Element(ComposeMonthlyBreakdownTable);

            // Account group details
            foreach (var accountGroup in Model.AccountGroups)
            {
                column.Item().Element(c => ComposeAccountGroup(c, accountGroup));
            }

            // Footer notes
            if (!string.IsNullOrEmpty(Model.FooterNotes))
            {
                column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(8).Column(col =>
                {
                    col.Item().Text("Notes:").FontSize(9).SemiBold().FontColor(Colors.Grey.Darken2);
                    col.Item().Text(Model.FooterNotes).FontSize(8).FontColor(Colors.Grey.Darken1);
                });
            }
        });
    }

    protected virtual void ComposeExecutiveSummary(IContainer container)
    {
        container.Background(Colors.Blue.Lighten4).Border(1).BorderColor(Colors.Blue.Lighten2).Padding(10).Column(column =>
        {
            column.Spacing(4);
            
            column.Item().Text("Executive Summary").FontSize(11).Bold().FontColor(Colors.Blue.Darken2);
            
            column.Item().Row(row =>
            {
                row.RelativeItem().Text($"• Total Account Groups: {Model.AccountGroups.Count}").FontSize(9);
                row.RelativeItem().Text($"• Total Accounts: {Model.AccountGroups.Sum(g => g.Accounts.Count)}").FontSize(9);
                row.RelativeItem().Text($"• Variance Alerts: {Model.AccountGroups.Sum(g => g.GroupSummary.VarianceAlertCount)}").FontSize(9);
            });
            
            column.Item().Text($"• Overall Performance: {GetPerformanceDescription(Model.TotalVariancePercentage)}")
                .FontSize(9).FontColor(GetVarianceColor(Model.TotalVariancePercentage));
        });
    }

    protected virtual void ComposeMonthlyBreakdownTable(IContainer container)
    {
        container.Table(table =>
        {
            // Define 12 columns for monthly data + summary columns
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(80);  // Account Code
                columns.RelativeColumn(2);    // Account Name
                columns.RelativeColumn();     // Jan
                columns.RelativeColumn();     // Feb
                columns.RelativeColumn();     // Mar
                columns.RelativeColumn();     // Apr
                columns.RelativeColumn();     // May
                columns.RelativeColumn();     // Jun
                columns.RelativeColumn();     // Jul
                columns.RelativeColumn();     // Aug
                columns.RelativeColumn();     // Sep
                columns.RelativeColumn();     // Oct
                columns.RelativeColumn();     // Nov
                columns.RelativeColumn();     // Dec
                columns.RelativeColumn();     // YTD Budget
                columns.RelativeColumn();     // YTD Actual
                columns.RelativeColumn();     // YTD Variance
                columns.RelativeColumn();     // YTD Variance %
            });

            // Header row
            table.Header(header =>
            {
                header.Cell().Element(HeaderStyle).Text("Code").SemiBold();
                header.Cell().Element(HeaderStyle).Text("Account Name").SemiBold();
                
                foreach (var month in Model.MonthlyColumns)
                {
                    header.Cell().Element(HeaderStyle).AlignCenter().Text(month.Substring(0, 3)).SemiBold();
                }
                
                header.Cell().Element(HeaderStyle).AlignCenter().Text("YTD Budget").SemiBold();
                header.Cell().Element(HeaderStyle).AlignCenter().Text("YTD Actual").SemiBold();
                header.Cell().Element(HeaderStyle).AlignCenter().Text("YTD Var").SemiBold();
                header.Cell().Element(HeaderStyle).AlignCenter().Text("YTD Var %").SemiBold();

                IContainer HeaderStyle(IContainer c) => c
                    .Background(Colors.Blue.Darken3)
                    .Padding(4)
                    .DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.White).Bold());
            });

            // Data rows for all accounts
            foreach (var accountGroup in Model.AccountGroups)
            {
                // Group header row - need to handle this differently since ColSpan is not available
                // We'll use a separate table for group headers
                table.Cell().Element(c => GroupHeaderStyle(c)).Text($"{accountGroup.GroupCode}").FontSize(8).Bold();
                table.Cell().Element(c => GroupHeaderStyle(c)).Text($"{accountGroup.GroupName} ({accountGroup.Accounts.Count} accounts)").FontSize(8).Bold().FontColor(Colors.Blue.Darken2);
                
                // Empty cells for the remaining columns in group header row
                for (int i = 0; i < 15; i++)
                {
                    table.Cell().Element(c => GroupHeaderStyle(c)).Text("").FontSize(8);
                }

                // Account rows
                foreach (var account in accountGroup.Accounts)
                {
                    // Account code
                    table.Cell().Element(c => AccountCellStyle(c, account)).Text(account.AccountCode).FontSize(8);
                    
                    // Account name
                    table.Cell().Element(c => AccountCellStyle(c, account)).Text(account.AccountName).FontSize(8).SemiBold();
                    
                    // Monthly data
                    for (int i = 0; i < account.MonthlyData.Count && i < 12; i++)
                    {
                        var monthData = account.MonthlyData[i];
                        table.Cell().Element(c => MonthlyCellStyle(c, monthData.VariancePercentage))
                            .AlignRight().Text($"{monthData.ActualAmount:N0}").FontSize(8);
                    }
                    
                    // YTD columns
                    table.Cell().Element(c => AccountCellStyle(c, account)).AlignRight()
                        .Text($"{account.AccountSummary.TotalBudget:N0}").FontSize(8);
                    table.Cell().Element(c => AccountCellStyle(c, account)).AlignRight()
                        .Text($"{account.AccountSummary.TotalActual:N0}").FontSize(8);
                    table.Cell().Element(c => AccountCellStyle(c, account)).AlignRight()
                        .Text($"{account.AccountSummary.TotalVariance:N0}").FontSize(8);
                    table.Cell().Element(c => AccountCellStyle(c, account)).AlignRight()
                        .Text($"{account.AccountSummary.TotalVariancePercentage:F1}%").FontSize(8);
                }

                // Group summary row
                table.Cell().Element(c => GroupSummaryStyle(c)).Text("GROUP TOTAL").FontSize(8).Bold();
                table.Cell().Element(c => GroupSummaryStyle(c)).Text(accountGroup.GroupName).FontSize(8).Bold();
                
                // Monthly totals for group
                for (int i = 0; i < 12; i++)
                {
                    var monthTotal = accountGroup.Accounts.Sum(a => i < a.MonthlyData.Count ? a.MonthlyData[i].ActualAmount : 0);
                    table.Cell().Element(c => GroupSummaryStyle(c)).AlignRight().Text($"{monthTotal:N0}").FontSize(8).Bold();
                }
                
                table.Cell().Element(c => GroupSummaryStyle(c)).AlignRight()
                    .Text($"{accountGroup.GroupSummary.GroupTotalBudget:N0}").FontSize(8).Bold();
                table.Cell().Element(c => GroupSummaryStyle(c)).AlignRight()
                    .Text($"{accountGroup.GroupSummary.GroupTotalActual:N0}").FontSize(8).Bold();
                table.Cell().Element(c => GroupSummaryStyle(c)).AlignRight()
                    .Text($"{accountGroup.GroupSummary.GroupTotalVariance:N0}").FontSize(8).Bold();
                table.Cell().Element(c => GroupSummaryStyle(c)).AlignRight()
                    .Text($"{accountGroup.GroupSummary.GroupTotalVariancePercentage:F1}%").FontSize(8).Bold();
            }
        });
    }

    protected virtual void ComposeAccountGroup(IContainer container, AccountGroup accountGroup)
    {
        container.Column(column =>
        {
            column.Spacing(6);
            
            // Group header
            column.Item().Background(Colors.Grey.Lighten2).Padding(6).Row(row =>
            {
                row.RelativeItem().Text($"{accountGroup.GroupCode} - {accountGroup.GroupName}")
                    .FontSize(11).Bold().FontColor(Colors.Blue.Darken2);
                row.ConstantItem(100).AlignRight().Text($"{accountGroup.Accounts.Count} accounts")
                    .FontSize(9).FontColor(Colors.Grey.Darken1);
            });

            // Group details table
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // Headers
                table.Header(header =>
                {
                    header.Cell().Element(Style => MiniHeaderStyle(Style)).Text("Account").SemiBold();
                    header.Cell().Element(Style => MiniHeaderStyle(Style)).AlignCenter().Text("Budget").SemiBold();
                    header.Cell().Element(Style => MiniHeaderStyle(Style)).AlignCenter().Text("Actual").SemiBold();
                    header.Cell().Element(Style => MiniHeaderStyle(Style)).AlignCenter().Text("Variance").SemiBold();
                    header.Cell().Element(Style => MiniHeaderStyle(Style)).AlignCenter().Text("Var %").SemiBold();
                });

                // Account details
                foreach (var account in accountGroup.Accounts)
                {
                    table.Cell().Element(c => MiniCellStyle(c, account.IsHighlighted))
                        .Text($"{account.AccountCode} - {account.AccountName}").FontSize(8);
                    table.Cell().Element(c => MiniCellStyle(c, account.IsHighlighted)).AlignRight()
                        .Text($"{account.AccountSummary.TotalBudget:N0}").FontSize(8);
                    table.Cell().Element(c => MiniCellStyle(c, account.IsHighlighted)).AlignRight()
                        .Text($"{account.AccountSummary.TotalActual:N0}").FontSize(8);
                    table.Cell().Element(c => MiniCellStyle(c, account.IsHighlighted)).AlignRight()
                        .Text($"{account.AccountSummary.TotalVariance:N0}").FontSize(8)
                        .FontColor(GetVarianceColor(account.AccountSummary.TotalVariancePercentage));
                    table.Cell().Element(c => MiniCellStyle(c, account.IsHighlighted)).AlignRight()
                        .Text($"{account.AccountSummary.TotalVariancePercentage:F1}%").FontSize(8)
                        .FontColor(GetVarianceColor(account.AccountSummary.TotalVariancePercentage));
                }
            });
        });
    }

    protected virtual void ComposeFooter(IContainer container)
    {
        container.AlignCenter().DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.Grey.Darken1)).Row(row =>
        {
            row.RelativeItem().AlignLeft().Text($"Generated by: {Model.GeneratedBy}");
            row.RelativeItem().AlignCenter().Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
            row.RelativeItem().AlignRight().Text($"Printed: {DateTime.Now:dd-MMM-yyyy HH:mm}");
        });
    }

    // Style helper methods
    protected virtual IContainer MiniHeaderStyle(IContainer container) => container
        .Background(Colors.Grey.Lighten2)
        .Padding(4)
        .Border(1)
        .BorderColor(Colors.Grey.Lighten1);

    protected virtual IContainer MiniCellStyle(IContainer container, bool isHighlighted) => container
        .Border(1)
        .BorderColor(Colors.Grey.Lighten1)
        .Background(isHighlighted ? Colors.Yellow.Lighten4 : Colors.White)
        .Padding(4);

    protected virtual IContainer AccountCellStyle(IContainer container, AccountDetail account) => container
        .Border(1)
        .BorderColor(Colors.Grey.Lighten2)
        .Background(account.IsHighlighted ? Colors.Yellow.Lighten4 : Colors.White)
        .Padding(3);

    protected virtual IContainer MonthlyCellStyle(IContainer container, decimal variancePercentage) => container
        .Border(1)
        .BorderColor(Colors.Grey.Lighten2)
        .Background(GetVarianceBackgroundColor(variancePercentage))
        .Padding(3);

    protected virtual IContainer GroupHeaderStyle(IContainer container) => container
        .Background(Colors.Blue.Lighten3)
        .Border(1)
        .BorderColor(Colors.Blue.Lighten2)
        .Padding(6);

    protected virtual IContainer GroupSummaryStyle(IContainer container) => container
        .Background(Colors.Grey.Lighten3)
        .Border(1)
        .BorderColor(Colors.Grey.Darken1)
        .Padding(4);

    protected virtual string GetPerformanceDescription(decimal variancePercentage)
    {
        if (Math.Abs(variancePercentage) <= 5) return "On Target";
        if (Math.Abs(variancePercentage) <= 10) return "Slightly Off Target";
        if (variancePercentage > 10) return "Over Budget";
        return "Under Budget";
    }

    protected virtual string GetVarianceBackgroundColor(decimal variancePercentage)
    {
        if (Math.Abs(variancePercentage) <= 5) return Colors.Green.Lighten4;
        if (Math.Abs(variancePercentage) <= 10) return Colors.Yellow.Lighten4;
        return Colors.Red.Lighten4;
    }

    protected virtual string GetVarianceColor(decimal variancePercentage)
    {
        if (Math.Abs(variancePercentage) <= 5) return Colors.Green.Darken2;
        if (Math.Abs(variancePercentage) <= 10) return Colors.Orange.Darken2;
        return Colors.Red.Darken2;
    }
}