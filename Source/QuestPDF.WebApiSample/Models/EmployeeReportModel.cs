namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Model for A4 Portrait Employee Report
/// Demonstrates portrait orientation for standard document layouts
/// </summary>
public class EmployeeReportModel
{
    public string ReportTitle { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public string ReportingPeriod { get; set; } = string.Empty;
    
    public CompanyInfo Company { get; set; } = new();
    public List<EmployeeRecord> Employees { get; set; } = new();
    
    public EmployeeSummary Summary { get; set; } = new();
    
    public string? Remarks { get; set; }
    public string PreparedBy { get; set; } = string.Empty;
    public string ReviewedBy { get; set; } = string.Empty;
}

public class EmployeeRecord
{
    public string EmployeeId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal MonthlySalary { get; set; }
    public int WorkingDays { get; set; }
    public int LeaveDays { get; set; }
    public string PerformanceRating { get; set; } = string.Empty;
    public string Status { get; set; } = "Active";
}

public class EmployeeSummary
{
    public int TotalEmployees { get; set; }
    public int ActiveEmployees { get; set; }
    public int OnLeaveEmployees { get; set; }
    public decimal TotalSalaryExpense { get; set; }
    public decimal AverageSalary { get; set; }
}
