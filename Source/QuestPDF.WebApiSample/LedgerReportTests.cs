using System;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample;

/// <summary>
/// Test class to verify ledger report functionality
/// </summary>
public static class LedgerReportTests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Running Ledger Report Tests...");
        
        try
        {
            TestIncomeStatementGeneration();
            TestFinancialPositionGeneration();
            TestTrialBalanceGeneration();
            TestComparisonReportGeneration();
            TestBudgetComparisonGeneration();
            TestEnhancedBudgetComparisonGeneration();
            
            Console.WriteLine("All Ledger Report Tests Passed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ledger Report Tests Failed: {ex.Message}");
            throw;
        }
    }
    
    private static void TestIncomeStatementGeneration()
    {
        Console.WriteLine("Testing Income Statement Generation...");
        
        var model = SampleDataGenerator.GetSampleIncomeStatement();
        var document = new IncomeStatementDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Income Statement PDF generation failed - empty result");
            
        Console.WriteLine($"Income Statement generated successfully ({pdfBytes.Length} bytes)");
    }
    
    private static void TestFinancialPositionGeneration()
    {
        Console.WriteLine("Testing Financial Position Generation...");
        
        var model = SampleDataGenerator.GetSampleFinancialPosition();
        var document = new FinancialPositionDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Financial Position PDF generation failed - empty result");
            
        Console.WriteLine($"Financial Position generated successfully ({pdfBytes.Length} bytes)");
    }
    
    private static void TestTrialBalanceGeneration()
    {
        Console.WriteLine("Testing Trial Balance Generation...");
        
        var model = SampleDataGenerator.GetSampleTrialBalance();
        var document = new TrialBalanceDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Trial Balance PDF generation failed - empty result");
            
        Console.WriteLine($"Trial Balance generated successfully ({pdfBytes.Length} bytes)");
    }
    
    private static void TestComparisonReportGeneration()
    {
        Console.WriteLine("Testing Comparison Report Generation...");
        
        var model = SampleDataGenerator.GetSampleComparisonReport();
        var document = new ComparisonReportDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Comparison Report PDF generation failed - empty result");
            
        Console.WriteLine($"Comparison Report generated successfully ({pdfBytes.Length} bytes)");
    }
    
    private static void TestBudgetComparisonGeneration()
    {
        Console.WriteLine("Testing Budget Comparison Generation...");
        
        var model = SampleDataGenerator.GetSampleBudgetComparison();
        var document = new BudgetComparisonDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        if (pdfBytes == null || pdfBytes.Length == 0)
            throw new Exception("Budget Comparison PDF generation failed - empty result");
            
        Console.WriteLine($"Budget Comparison generated successfully ({pdfBytes.Length} bytes)");
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