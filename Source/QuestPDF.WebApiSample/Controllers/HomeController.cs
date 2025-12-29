using Microsoft.AspNetCore.Mvc;
using QuestPDF.WebApiSample.Models;
using System.Diagnostics;

namespace QuestPDF.WebApiSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportGenerator()
        {
            return View();
        }

        public IActionResult GenerateReport(string reportType)
        {
            try
            {
                // Redirect to the appropriate API endpoint based on report type
                switch (reportType)
                {
                    case "tax-invoice":
                        return Redirect("/api/tax-invoice/sample");
                    case "receipt":
                        return Redirect("/api/receipt/sample");
                    case "purchase-order":
                        return Redirect("/api/purchase-order/sample");
                    case "dynamic-report":
                        return Redirect("/api/dynamic-column-report/sample");
                    case "employee-report":
                        return Redirect("/api/employee-report/sample");
                    case "product-catalog":
                        return Redirect("/api/product-catalog/sample");
                    case "income-statement":
                        return Redirect("/api/ledger/income-statement/sample");
                    case "financial-position":
                        return Redirect("/api/ledger/financial-position/sample");
                    case "trial-balance":
                        return Redirect("/api/ledger/trial-balance/sample");
                    case "comparison-report":
                        return Redirect("/api/ledger/comparison/sample");
                    case "budget-comparison":
                        return Redirect("/api/ledger/budget-comparison/sample");
                    case "project-timeline":
                        return Redirect("/api/project-timeline/sample");
                    case "employee-payslip":
                        return Redirect("/api/employee-payslip/sample");
                    case "generic-report":
                        return Redirect("/api/generic-report/sample");
                    case "budget-analysis":
                        return Redirect("/api/budget-analysis/sample");
                    case "attendance-report":
                        return Redirect("/api/attendance-report/sample");
                    case "assets-report":
                        return Redirect("/api/assets-report/sample");
                    case "enhanced-budget-comparison":
                        return Redirect("/api/ledger/enhanced-budget-comparison/sample");
                    case "all-reports":
                        return Redirect("/api/ledger/all-reports/sample");
                    default:
                        return RedirectToAction("ReportGenerator");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating report");
                return RedirectToAction("ReportGenerator");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}