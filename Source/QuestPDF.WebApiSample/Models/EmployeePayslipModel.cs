namespace QuestPDF.WebApiSample.Models;

/// <summary>
/// Model for GCC-compliant Employee Payslip
/// Includes earnings, deductions, bank details, and QR code for authenticity
/// </summary>
public class EmployeePayslipModel
{
    /// <summary>
    /// Unique payslip number/reference
    /// </summary>
    public string PayslipNumber { get; set; } = string.Empty;

    /// <summary>
    /// Pay period (e.g., "October 2025")
    /// </summary>
    public string PayPeriod { get; set; } = string.Empty;

    /// <summary>
    /// Pay date
    /// </summary>
    public DateTime PayDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Working days in the period
    /// </summary>
    public int WorkingDays { get; set; }

    /// <summary>
    /// Total days in the period
    /// </summary>
    public int TotalDays { get; set; }

    /// <summary>
    /// Company information
    /// </summary>
    public CompanyInfo Company { get; set; } = new();

    /// <summary>
    /// Employee information
    /// </summary>
    public EmployeeInfo Employee { get; set; } = new();

    /// <summary>
    /// Earnings breakdown
    /// </summary>
    public List<EarningsItem> Earnings { get; set; } = new();

    /// <summary>
    /// Deductions breakdown
    /// </summary>
    public List<DeductionItem> Deductions { get; set; } = new();

    /// <summary>
    /// Bank details for salary transfer
    /// </summary>
    public BankDetails BankDetails { get; set; } = new();

    /// <summary>
    /// Summary totals
    /// </summary>
    public PayslipSummary Summary { get; set; } = new();

    /// <summary>
    /// Prepared/approved by
    /// </summary>
    public string PreparedBy { get; set; } = string.Empty;

    /// <summary>
    /// Password for PDF protection (optional)
    /// </summary>
    public string? Password { get; set; }

    public List<BenefitBalance> BenefitBalance { get; set; } = new();
}

/// <summary>
/// Employee information for payslip
/// </summary>
public class EmployeeInfo
{
    public string EmployeeId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string WorkPermitNumber { get; set; } = string.Empty;
}

/// <summary>
/// Earnings item
/// </summary>
public class EarningsItem
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

/// <summary>
/// Deduction item
/// </summary>
public class DeductionItem
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

/// <summary>
/// Payslip summary totals
/// </summary>
public class PayslipSummary
{
    public decimal TotalEarnings { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal GrossPay { get; set; }
    public decimal NetPay { get; set; }
}

public class BenefitBalance
{
    public string BenefitType { get; set; } = string.Empty;
    public decimal BalanceAmount { get; set; }
}
