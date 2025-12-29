namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Unified Employee Data Model that combines payslip and report functionality
/// Includes comprehensive employee information for all types of employee reports
/// </summary>
public class EmployeeDataModel
{
    /// <summary>
    /// Report metadata
    /// </summary>
    public string ReportTitle { get; set; } = string.Empty;
    public string ReportType { get; set; } = string.Empty; // "Merged", "Listing", "Citizenship", "Department"
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public string ReportingPeriod { get; set; } = string.Empty;
    
    /// <summary>
    /// Company information
    /// </summary>
    public CompanyInfo Company { get; set; } = new();
    
    /// <summary>
    /// List of all employees with comprehensive data
    /// </summary>
    public List<ComprehensiveEmployee> Employees { get; set; } = new();
    
    /// <summary>
    /// Report summary statistics
    /// </summary>
    public EmployeeReportSummary Summary { get; set; } = new();
    
    /// <summary>
    /// Optional payslip data (for individual employee payslips)
    /// </summary>
    public EmployeePayslipData? PayslipData { get; set; }
    
    /// <summary>
    /// Department-wise analysis (for department reports)
    /// </summary>
    public List<DepartmentAnalysis> DepartmentAnalysis { get; set; } = new();
    
    /// <summary>
    /// Citizenship-wise analysis (for citizenship reports)
    /// </summary>
    public List<CitizenshipAnalysis> CitizenshipAnalysis { get; set; } = new();
    
    /// <summary>
    /// Report metadata
    /// </summary>
    public string? Remarks { get; set; }
    public string PreparedBy { get; set; } = string.Empty;
    public string ReviewedBy { get; set; } = string.Empty;
}

/// <summary>
/// Comprehensive employee information including all fields needed for various reports
/// </summary>
public class ComprehensiveEmployee
{
    /// <summary>
    /// Basic employee information
    /// </summary>
    public string EmployeeId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    
    /// <summary>
    /// Personal and demographic information
    /// </summary>
    public string Citizenship { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string WorkPermitNumber { get; set; } = string.Empty;
    public string CPRNumber { get; set; } = string.Empty; // Bahrain CPR
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string MaritalStatus { get; set; } = string.Empty;
    
    /// <summary>
    /// Employment details
    /// </summary>
    public string EmploymentType { get; set; } = string.Empty; // Full-time, Part-time, Contract
    public string ContractType { get; set; } = string.Empty; // Permanent, Temporary
    public decimal MonthlySalary { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal HousingAllowance { get; set; }
    public decimal TransportAllowance { get; set; }
    public decimal OtherAllowances { get; set; }
    
    /// <summary>
    /// Performance and attendance
    /// </summary>
    public string PerformanceRating { get; set; } = string.Empty;
    public string Status { get; set; } = "Active"; // Active, On Leave, Terminated
    public int WorkingDays { get; set; }
    public int LeaveDays { get; set; }
    public int AbsentDays { get; set; }
    public int LateDays { get; set; }
    public decimal AttendancePercentage { get; set; }
    
    /// <summary>
    /// Benefits and deductions
    /// </summary>
    public decimal SocialInsurance { get; set; }
    public decimal IncomeTax { get; set; }
    public decimal LoanDeduction { get; set; }
    public decimal AdvanceDeduction { get; set; }
    public decimal OtherDeductions { get; set; }
    
    /// <summary>
    /// Bank details
    /// </summary>
    public string BankName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string IBAN { get; set; } = string.Empty;
    
    /// <summary>
    /// Leave balances
    /// </summary>
    public decimal AnnualLeaveBalance { get; set; }
    public decimal SickLeaveBalance { get; set; }
    public decimal IndemnityBalance { get; set; }
    
    /// <summary>
    /// Calculated fields
    /// </summary>
    public decimal GrossPay => BasicSalary + HousingAllowance + TransportAllowance + OtherAllowances;
    public decimal TotalDeductions => SocialInsurance + IncomeTax + LoanDeduction + AdvanceDeduction + OtherDeductions;
    public decimal NetPay => GrossPay - TotalDeductions;
    public int YearsOfService => (int)Math.Floor((DateTime.Now - JoinDate).TotalDays / 365.25);
}

/// <summary>
/// Employee payslip data for individual payslip generation
/// </summary>
public class EmployeePayslipData
{
    public string PayslipNumber { get; set; } = string.Empty;
    public string PayPeriod { get; set; } = string.Empty;
    public DateTime PayDate { get; set; } = DateTime.Now;
    public int WorkingDays { get; set; }
    public int TotalDays { get; set; }
    public ComprehensiveEmployee Employee { get; set; } = new();
    public List<EarningsItem> Earnings { get; set; } = new();
    public List<DeductionItem> Deductions { get; set; } = new();
    public PayslipSummary Summary { get; set; } = new();
    public BankDetails BankDetails { get; set; } = new();
    public List<BenefitBalance> BenefitBalance { get; set; } = new();
    public string PreparedBy { get; set; } = string.Empty;
}

/// <summary>
/// Department-wise analysis for department reports
/// </summary>
public class DepartmentAnalysis
{
    public string DepartmentName { get; set; } = string.Empty;
    public int EmployeeCount { get; set; }
    public int ActiveEmployees { get; set; }
    public decimal TotalSalaryExpense { get; set; }
    public decimal AverageSalary { get; set; }
    public decimal AverageYearsOfService { get; set; }
    public List<CitizenshipBreakdown> CitizenshipBreakdown { get; set; } = new();
    public List<PerformanceBreakdown> PerformanceBreakdown { get; set; } = new();
    public decimal AttendanceRate { get; set; }
    public string DepartmentHead { get; set; } = string.Empty;
}

/// <summary>
/// Citizenship-wise analysis for citizenship reports
/// </summary>
public class CitizenshipAnalysis
{
    public string Citizenship { get; set; } = string.Empty;
    public int EmployeeCount { get; set; }
    public decimal PercentageOfTotal { get; set; }
    public decimal TotalSalaryExpense { get; set; }
    public decimal AverageSalary { get; set; }
    public List<DepartmentBreakdown> DepartmentBreakdown { get; set; } = new();
    public List<GenderBreakdown> GenderBreakdown { get; set; } = new();
    public decimal AverageYearsOfService { get; set; }
}

/// <summary>
/// Enhanced employee report summary with more comprehensive statistics
/// </summary>
public class EmployeeReportSummary
{
    public int TotalEmployees { get; set; }
    public int ActiveEmployees { get; set; }
    public int OnLeaveEmployees { get; set; }
    public int TerminatedEmployees { get; set; }
    public decimal TotalSalaryExpense { get; set; }
    public decimal AverageSalary { get; set; }
    public decimal AverageYearsOfService { get; set; }
    public decimal OverallAttendanceRate { get; set; }
    public int TotalDepartments { get; set; }
    public int TotalCitizenshipCategories { get; set; }
    public int MaleEmployees { get; set; }
    public int FemaleEmployees { get; set; }
    public int FullTimeEmployees { get; set; }
    public int PartTimeEmployees { get; set; }
    public int ContractEmployees { get; set; }
}

/// <summary>
/// Supporting breakdown classes for analysis
/// </summary>
public class CitizenshipBreakdown
{
    public string Citizenship { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

public class PerformanceBreakdown
{
    public string Rating { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

public class DepartmentBreakdown
{
    public string Department { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

public class GenderBreakdown
{
    public string Gender { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

/// <summary>
/// Report type enumeration for easy identification
/// </summary>
public enum EmployeeReportType
{
    Merged,        // Combined payslip and report
    Listing,       // Complete employee listing
    Citizenship,    // Citizenship-wise analysis
    Department     // Department-wise analysis
}