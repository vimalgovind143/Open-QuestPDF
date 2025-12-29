using System;
using System.Collections.Generic;

namespace QuestPDF.WebApiSample.Models;

public class LedgerReportModel
{
    public string ReportTitle { get; set; } = string.Empty;
    public string ReportSubtitle { get; set; } = string.Empty;
    public DateTime GeneratedDate { get; set; } = DateTime.Now;
    public string GeneratedBy { get; set; } = string.Empty;
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    
    public List<string> ColumnHeaders { get; set; } = new();
    public List<LedgerDataRow> DataRows { get; set; } = new();
    public LedgerDataRow? SummaryRow { get; set; }
    public string FooterNotes { get; set; } = string.Empty;
}

public class LedgerDataRow
{
    public string RowLabel { get; set; } = string.Empty;
    public List<string> Values { get; set; } = new();
    public bool IsHighlighted { get; set; } = false;
    public string RowType { get; set; } = "Normal"; // Normal, Header, Total, Subtotal
}

// Specific models for each report type
public class IncomeStatementModel : LedgerReportModel
{
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal NetIncome { get; set; }
}

public class FinancialPositionModel : LedgerReportModel
{
    public decimal TotalAssets { get; set; }
    public decimal TotalLiabilities { get; set; }
    public decimal TotalEquity { get; set; }
}

public class TrialBalanceModel : LedgerReportModel
{
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
}

public class ComparisonReportModel : LedgerReportModel
{
    public string ComparisonPeriod1 { get; set; } = string.Empty;
    public string ComparisonPeriod2 { get; set; } = string.Empty;
    public decimal VarianceAmount { get; set; }
    public decimal VariancePercentage { get; set; }
}

public class BudgetComparisonModel : ComparisonReportModel
{
    public decimal BudgetAmount { get; set; }
    public decimal ActualAmount { get; set; }
    public decimal BudgetVariance { get; set; }
    public decimal BudgetVariancePercentage { get; set; }
}

/// <summary>
/// Enhanced 12-Column Budget Comparison Model with Account Grouping
/// </summary>
public class EnhancedBudgetComparisonModel : LedgerReportModel
{
    public string ReportTitle { get; set; } = "12-Column Budget Comparison Report";
    public string ReportSubtitle { get; set; } = "Monthly Budget vs Actual Analysis by Account";
    public string FiscalYear { get; set; } = "2025";
    
    // 12 column headers for monthly comparison
    public List<string> MonthlyColumns { get; set; } = new();
    
    // Account grouping structure
    public List<AccountGroup> AccountGroups { get; set; } = new();
    
    // Summary statistics
    public decimal TotalBudgetAmount { get; set; }
    public decimal TotalActualAmount { get; set; }
    public decimal TotalVarianceAmount { get; set; }
    public decimal TotalVariancePercentage { get; set; }
    
    // Report metadata
    public bool ShowVarianceColors { get; set; } = true;
    public bool ShowAccountCodes { get; set; } = true;
    public bool ShowPercentages { get; set; } = true;
}

/// <summary>
/// Account Group for hierarchical reporting
/// </summary>
public class AccountGroup
{
    public string GroupName { get; set; } = string.Empty;
    public string GroupCode { get; set; } = string.Empty;
    public List<AccountDetail> Accounts { get; set; } = new();
    public AccountGroupSummary GroupSummary { get; set; } = new();
    public bool IsExpanded { get; set; } = true;
}

/// <summary>
/// Individual Account Detail
/// </summary>
public class AccountDetail
{
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public List<MonthlyData> MonthlyData { get; set; } = new();
    public AccountSummary AccountSummary { get; set; } = new();
    public string AccountType { get; set; } = "Expense"; // Revenue, Expense, Asset, Liability
    public bool IsHighlighted { get; set; } = false;
}

/// <summary>
/// Monthly data for each account
/// </summary>
public class MonthlyData
{
    public string MonthName { get; set; } = string.Empty;
    public decimal BudgetAmount { get; set; }
    public decimal ActualAmount { get; set; }
    public decimal VarianceAmount { get; set; }
    public decimal VariancePercentage { get; set; }
    public decimal YearToDateBudget { get; set; }
    public decimal YearToDateActual { get; set; }
    public decimal YearToDateVariance { get; set; }
    public decimal YearToDateVariancePercentage { get; set; }
}

/// <summary>
/// Account summary calculations
/// </summary>
public class AccountSummary
{
    public decimal TotalBudget { get; set; }
    public decimal TotalActual { get; set; }
    public decimal TotalVariance { get; set; }
    public decimal TotalVariancePercentage { get; set; }
    public decimal AverageMonthlyVariance { get; set; }
    public string VarianceTrend { get; set; } = "Stable"; // Improving, Deteriorating, Stable
}

/// <summary>
/// Account group summary
/// </summary>
public class AccountGroupSummary
{
    public decimal GroupTotalBudget { get; set; }
    public decimal GroupTotalActual { get; set; }
    public decimal GroupTotalVariance { get; set; }
    public decimal GroupTotalVariancePercentage { get; set; }
    public int AccountCount { get; set; }
    public int VarianceAlertCount { get; set; } // Accounts with variance > 10%
}