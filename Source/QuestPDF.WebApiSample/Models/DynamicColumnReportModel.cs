namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Model for a dynamic column report showing data with varying number of columns
/// Useful for reports where columns are determined at runtime (e.g., monthly sales by region)
/// </summary>
public class DynamicColumnReportModel
{
    public string ReportTitle { get; set; } = string.Empty;
    public string ReportSubtitle { get; set; } = string.Empty;
    public DateTime GeneratedDate { get; set; } = DateTime.Now;
    public string GeneratedBy { get; set; } = string.Empty;
    
    // Column headers - dynamically defined
    public List<string> ColumnHeaders { get; set; } = new();
    
    // Data rows - each row contains values for each column
    public List<DynamicDataRow> DataRows { get; set; } = new();
    
    // Optional summary row (totals, averages, etc.)
    public DynamicDataRow? SummaryRow { get; set; }
    
    // Report metadata
    public string? FooterNotes { get; set; }
}

public class DynamicDataRow
{
    public string RowLabel { get; set; } = string.Empty;
    public List<string> Values { get; set; } = new();
    public bool IsHighlighted { get; set; } = false;
}
