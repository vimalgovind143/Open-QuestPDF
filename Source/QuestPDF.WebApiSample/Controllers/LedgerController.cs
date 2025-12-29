using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LedgerController : BasePdfController
{
    public LedgerController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates an Income Statement Report with sample data
    /// </summary>
    [HttpGet("income-statement/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateIncomeStatementSample()
    {
        var model = SampleDataGenerator.GetSampleIncomeStatement();
        var document = new IncomeStatementDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "income-statement-sample.pdf");
    }

    /// <summary>
    /// Gets sample income statement report data as JSON
    /// </summary>
    [HttpGet("income-statement/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IncomeStatementModel> GetIncomeStatementSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleIncomeStatement());
    }

    /// <summary>
    /// Generates a Financial Position (Balance Sheet) Report with sample data
    /// </summary>
    [HttpGet("financial-position/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateFinancialPositionSample()
    {
        var model = SampleDataGenerator.GetSampleFinancialPosition();
        var document = new FinancialPositionDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "financial-position-sample.pdf");
    }

    /// <summary>
    /// Gets sample financial position report data as JSON
    /// </summary>
    [HttpGet("financial-position/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<FinancialPositionModel> GetFinancialPositionSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleFinancialPosition());
    }

    /// <summary>
    /// Generates a Trial Balance Report with sample data
    /// </summary>
    [HttpGet("trial-balance/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateTrialBalanceSample()
    {
        var model = SampleDataGenerator.GetSampleTrialBalance();
        var document = new TrialBalanceDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "trial-balance-sample.pdf");
    }

    /// <summary>
    /// Gets sample trial balance report data as JSON
    /// </summary>
    [HttpGet("trial-balance/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<TrialBalanceModel> GetTrialBalanceSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleTrialBalance());
    }

    /// <summary>
    /// Generates a 2-Year Comparison Report with sample data
    /// </summary>
    [HttpGet("comparison/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateComparisonSample()
    {
        var model = SampleDataGenerator.GetSampleComparisonReport();
        var document = new ComparisonReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "comparison-report-sample.pdf");
    }

    /// <summary>
    /// Gets sample comparison report data as JSON
    /// </summary>
    [HttpGet("comparison/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ComparisonReportModel> GetComparisonSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleComparisonReport());
    }

    /// <summary>
    /// Generates a Budget Comparison Report with sample data
    /// </summary>
    [HttpGet("budget-comparison/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateBudgetComparisonSample()
    {
        var model = SampleDataGenerator.GetSampleBudgetComparison();
        var document = new BudgetComparisonDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "budget-comparison-sample.pdf");
    }

    /// <summary>
    /// Gets sample budget comparison report data as JSON
    /// </summary>
    [HttpGet("budget-comparison/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<BudgetComparisonModel> GetBudgetComparisonSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleBudgetComparison());
    }

    /// <summary>
    /// Generates an Enhanced 12-Column Budget Comparison Report with sample data
    /// </summary>
    [HttpGet("enhanced-budget-comparison/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateEnhancedBudgetComparisonSample()
    {
        var model = SampleDataGenerator.GetSampleEnhancedBudgetComparison();
        var document = new EnhancedBudgetComparisonDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "enhanced-budget-comparison-sample.pdf");
    }

    /// <summary>
    /// Gets sample enhanced budget comparison report data as JSON
    /// </summary>
    [HttpGet("enhanced-budget-comparison/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EnhancedBudgetComparisonModel> GetEnhancedBudgetComparisonSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleEnhancedBudgetComparison());
    }
    
    /// <summary>
    /// Generates all ledger reports with sample data as a ZIP file
    /// </summary>
    [HttpGet("all-reports/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateAllReportsSample()
    {
        // For simplicity, we're returning just one report in this example
        // In a real implementation, you would generate all reports and return them as a ZIP file
        var model = SampleDataGenerator.GetSampleIncomeStatement();
        var document = new IncomeStatementDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "all-ledger-reports-sample.pdf");
    }
}