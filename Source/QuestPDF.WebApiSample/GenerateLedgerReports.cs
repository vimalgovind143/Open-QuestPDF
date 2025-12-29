using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample;

/// <summary>
/// Console application to generate sample ledger reports
/// </summary>
public class GenerateLedgerReports
{
    public static void GenerateAllReports()
    {
        Console.WriteLine("Generating Ledger Reports...");
        
        // Generate Income Statement
        GenerateIncomeStatement();
        
        // Generate Financial Position
        GenerateFinancialPosition();
        
        // Generate Trial Balance
        GenerateTrialBalance();
        
        // Generate Comparison Report
        GenerateComparisonReport();
        
        // Generate Budget Comparison Report
        GenerateBudgetComparisonReport();
        
        Console.WriteLine("All reports generated successfully!");
    }
    
    private static void GenerateIncomeStatement()
    {
        Console.WriteLine("Generating Income Statement...");
        var model = SampleDataGenerator.GetSampleIncomeStatement();
        var document = new IncomeStatementDocument(model);
        var pdfBytes = document.GeneratePdf();
        File.WriteAllBytes("income-statement.pdf", pdfBytes);
        Console.WriteLine("Income Statement saved as income-statement.pdf");
    }
    
    private static void GenerateFinancialPosition()
    {
        Console.WriteLine("Generating Financial Position...");
        var model = SampleDataGenerator.GetSampleFinancialPosition();
        var document = new FinancialPositionDocument(model);
        var pdfBytes = document.GeneratePdf();
        File.WriteAllBytes("financial-position.pdf", pdfBytes);
        Console.WriteLine("Financial Position saved as financial-position.pdf");
    }
    
    private static void GenerateTrialBalance()
    {
        Console.WriteLine("Generating Trial Balance...");
        var model = SampleDataGenerator.GetSampleTrialBalance();
        var document = new TrialBalanceDocument(model);
        var pdfBytes = document.GeneratePdf();
        File.WriteAllBytes("trial-balance.pdf", pdfBytes);
        Console.WriteLine("Trial Balance saved as trial-balance.pdf");
    }
    
    private static void GenerateComparisonReport()
    {
        Console.WriteLine("Generating Comparison Report...");
        var model = SampleDataGenerator.GetSampleComparisonReport();
        var document = new ComparisonReportDocument(model);
        var pdfBytes = document.GeneratePdf();
        File.WriteAllBytes("comparison-report.pdf", pdfBytes);
        Console.WriteLine("Comparison Report saved as comparison-report.pdf");
    }
    
    private static void GenerateBudgetComparisonReport()
    {
        Console.WriteLine("Generating Budget Comparison Report...");
        var model = SampleDataGenerator.GetSampleBudgetComparison();
        var document = new BudgetComparisonDocument(model);
        var pdfBytes = document.GeneratePdf();
        File.WriteAllBytes("budget-comparison.pdf", pdfBytes);
        Console.WriteLine("Budget Comparison Report saved as budget-comparison.pdf");
    }
    
    private static void TestEnhancedBudgetComparisonGeneration()
    {
        Console.WriteLine("Testing Enhanced Budget Comparison Generation...");
        
        var model = SampleDataGenerator.GetSampleEnhancedBudgetComparison();
        var document = new EnhancedBudgetComparisonDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Enhanced Budget Comparison PDF generation failed - empty result");
            
        Console.WriteLine($"Enhanced Budget Comparison generated successfully ({pdfBytes.Length} bytes)");
        
        // Additional validation for the enhanced model structure
        if (model.AccountGroups.Count == 0)
            throw new Exception("Enhanced Budget Comparison model has no account groups");
            
        if (model.MonthlyColumns.Count != 12)
            throw new Exception("Enhanced Budget Comparison model should have 12 monthly columns");
            
        foreach (var accountGroup in model.AccountGroups)
        {
            if (accountGroup.Accounts.Count == 0)
                throw new Exception($"Account group '{accountGroup.GroupName}' has no accounts");
                
            foreach (var account in accountGroup.Accounts)
            {
                if (account.MonthlyData.Count != 12)
                    throw new Exception($"Account '{account.AccountName}' should have 12 months of data");
            }
        }
        
        Console.WriteLine("Enhanced Budget Comparison model structure validation passed");
    }
}