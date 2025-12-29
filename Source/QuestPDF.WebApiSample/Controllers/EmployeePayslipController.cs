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
    [Route("api/employee-payslip")]
    public class EmployeePayslipController : BasePdfController
    {
        public EmployeePayslipController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates an Employee Payslip with sample data
        /// </summary>
        /// <returns>PDF file of sample payslip</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleEmployeePayslip();
                var document = new EmployeePayslipDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"payslip-{model.PayslipNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample payslip");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample employee payslip data as JSON
        /// </summary>
        /// <returns>Sample payslip model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeePayslipModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleEmployeePayslip());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample payslip JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates an Employee Payslip with sample data and password protection
        /// </summary>
        /// <returns>PDF file of password-protected sample payslip</returns>
        [HttpGet("sample/password-protected")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSamplePasswordProtected()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleEmployeePayslipWithPassword();
                var document = new EmployeePayslipDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"payslip-{model.PayslipNumber}-protected.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating password-protected sample payslip");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates an Employee Payslip with custom data
        /// </summary>
        /// <param name="model">The payslip data to generate PDF from</param>
        /// <returns>PDF file of custom payslip</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] EmployeePayslipModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.PayslipNumber))
            {
                return BadRequest(new { error = "Invalid request", message = "PayslipNumber is required" });
            }

            try
            {
                var document = new EmployeePayslipDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"payslip-{model.PayslipNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom payslip");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates an Employee Payslip model without generating PDF
        /// </summary>
        /// <param name="model">The payslip data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] EmployeePayslipModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.PayslipNumber))
                errors.Add("PayslipNumber is required");
            if (string.IsNullOrEmpty(model.Employee?.FullName))
                errors.Add("Employee FullName is required");
            if (string.IsNullOrEmpty(model.Employee?.EmployeeId))
                errors.Add("Employee EmployeeId is required");
            if (model.Earnings == null || !model.Earnings.Any())
                errors.Add("At least one earning item is required");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}