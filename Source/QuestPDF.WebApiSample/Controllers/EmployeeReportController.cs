using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/employee-report")]
    public class EmployeeReportController : BasePdfController
    {
        public EmployeeReportController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates an Employee Report with sample data
        /// </summary>
        /// <returns>PDF file of sample employee report</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleEmployeeReport();
                var document = new EmployeeReportDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, "employee-report-sample.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample employee report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample employee report data as JSON
        /// </summary>
        /// <returns>Sample employee report model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeReportModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleEmployeeReport());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample employee report JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates an Employee Report with custom data
        /// </summary>
        /// <param name="model">The employee report data to generate PDF from</param>
        /// <returns>PDF file of custom employee report</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] EmployeeReportModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.ReportTitle))
            {
                return BadRequest(new { error = "Invalid request", message = "ReportTitle is required" });
            }

            try
            {
                var document = new EmployeeReportDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"employee-report-{DateTime.Now:yyyyMMdd}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom employee report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates an Employee Report model without generating PDF
        /// </summary>
        /// <param name="model">The employee report data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] EmployeeReportModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.ReportTitle))
                errors.Add("ReportTitle is required");
            if (string.IsNullOrEmpty(model.Department))
                errors.Add("Department is required");
            if (model.Employees == null || !model.Employees.Any())
                errors.Add("At least one employee is required");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}