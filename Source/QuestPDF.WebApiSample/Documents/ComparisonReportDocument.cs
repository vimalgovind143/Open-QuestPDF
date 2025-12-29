using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

/// <summary>
/// Comparison Report Document (2 Year Comparison)
/// </summary>
public class ComparisonReportDocument : LedgerReportDocument
{
    private new ComparisonReportModel Model { get; }

    public ComparisonReportDocument(ComparisonReportModel model) : base(model)
    {
        Model = model;
    }

    protected override void ComposeContent(IContainer container)
    {
        container.PaddingTop(20).Column(column =>
        {
            column.Spacing(10);

            // Summary information
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Comparison Period 1: {Model.ComparisonPeriod1}").FontSize(12).SemiBold();
                    col.Item().Text($"Comparison Period 2: {Model.ComparisonPeriod2}").FontSize(12).SemiBold();
                    col.Item().PaddingTop(5).Text($"Variance Amount: {Model.VarianceAmount:N2}").FontSize(12).SemiBold();
                    col.Item().Text($"Variance Percentage: {Model.VariancePercentage:F2}%").FontSize(12).SemiBold();
                });
            });

            // Data table
            column.Item().Table(table =>
            {
                // Define columns - first column for row labels, rest for data
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2); // Row label column (wider)
                    for (int i = 0; i < Model.ColumnHeaders.Count; i++)
                    {
                        columns.RelativeColumn(); // Data columns (equal width)
                    }
                });

                // Header row
                table.Header(header =>
                {
                    // First header cell
                    header.Cell().Element(HeaderStyle).Text("Description").SemiBold();
                    
                    // Dynamic header cells
                    foreach (var headerText in Model.ColumnHeaders)
                    {
                        header.Cell().Element(HeaderStyle).AlignCenter().Text(headerText).SemiBold();
                    }

                    IContainer HeaderStyle(IContainer c) => c
                        .Background(Colors.Blue.Darken3)
                        .Padding(8)
                        .DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.White));
                });

                // Data rows
                foreach (var dataRow in Model.DataRows)
                {
                    var bgColor = GetRowBackgroundColor(dataRow);
                    
                    // Row label cell
                    table.Cell().Element(c => CellStyle(c, bgColor)).Text(dataRow.RowLabel)
                        .SemiBold();
                    
                    // Dynamic data cells
                    for (int i = 0; i < Model.ColumnHeaders.Count; i++)
                    {
                        var value = i < dataRow.Values.Count ? dataRow.Values[i] : "";
                        table.Cell().Element(c => CellStyle(c, bgColor)).AlignRight().Text(value);
                    }
                }

                // Summary row if exists
                if (Model.SummaryRow != null)
                {
                    table.Cell().Element(c => SummaryCellStyle(c)).Text(Model.SummaryRow.RowLabel).Bold();
                    
                    for (int i = 0; i < Model.ColumnHeaders.Count; i++)
                    {
                        var value = i < Model.SummaryRow.Values.Count ? Model.SummaryRow.Values[i] : "";
                        table.Cell().Element(c => SummaryCellStyle(c)).AlignRight().Text(value).Bold();
                    }
                }

                IContainer CellStyle(IContainer c, string bgColor) => c
                    .Border(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .Background(bgColor)
                    .Padding(8);

                IContainer SummaryCellStyle(IContainer c) => c
                    .Border(1)
                    .BorderColor(Colors.Blue.Darken3)
                    .Background(Colors.Blue.Lighten4)
                    .Padding(8);
            });

            // Footer notes
            if (!string.IsNullOrEmpty(Model.FooterNotes))
            {
                column.Item().PaddingTop(15).Background(Colors.Grey.Lighten4).Padding(10).Column(col =>
                {
                    col.Item().Text("Notes:").FontSize(9).SemiBold();
                    col.Item().Text(Model.FooterNotes).FontSize(9);
                });
            }
        });
    }
}