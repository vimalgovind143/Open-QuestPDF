namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Generic report model for flexible PDF generation
/// Allows passing report name, date filter, column names, and data rows
/// </summary>
public class GenericReportModel
{
    /// <summary>
    /// The name/title of the report
    /// </summary>
    public string ReportName { get; set; } = string.Empty;

    /// <summary>
    /// Date filter or period (e.g., "October 2025", "2025-10-01 to 2025-10-31")
    /// </summary>
    public string DateFilter { get; set; } = string.Empty;

    /// <summary>
    /// Column names for the data table
    /// </summary>
    public List<string> ColumnNames { get; set; } = new();

    /// <summary>
    /// Data rows - each row is a list of string values corresponding to columns
    /// </summary>
    public List<List<string>> Data { get; set; } = new();

    /// <summary>
    /// Optional summary/total row
    /// </summary>
    public List<string>? SummaryRow { get; set; }

    /// <summary>
    /// Optional footer notes
    /// </summary>
    public string? FooterNotes { get; set; }

    /// <summary>
    /// Who generated the report (optional)
    /// </summary>
    public string? GeneratedBy { get; set; }

    /// <summary>
    /// Page orientation: "Portrait" or "Landscape" (default: Portrait)
    /// </summary>
    public string PageOrientation { get; set; } = "Portrait";

    /// <summary>
    /// Base64 encoded header logo image (optional)
    /// </summary>
    public string? HeaderLogoBase64 { get; set; }

    /// <summary>
    /// Base64 encoded footer logo image (optional)
    /// </summary>
    public string? FooterLogoBase64 { get; set; }

    /// <summary>
    /// Text direction: "LTR" (Left-to-Right) or "RTL" (Right-to-Left)
    /// Use "RTL" for Arabic, Hebrew, Persian, etc. Default is "LTR"
    /// </summary>
    public string TextDirection { get; set; } = "LTR";
}