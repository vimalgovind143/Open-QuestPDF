using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/tax-invoice")]
    public class TaxInvoiceController : BasePdfController
    {
        public TaxInvoiceController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Standard TAX Invoice with sample data
        /// </summary>
        /// <returns>PDF file of sample tax invoice</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleTaxInvoice();
                var document = new StandardTaxInvoiceDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"tax-invoice-{model.TaxInvoiceNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample tax invoice");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample TAX invoice data as JSON
        /// </summary>
        /// <returns>Sample tax invoice model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StandardTaxInvoiceModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleTaxInvoice());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample tax invoice JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Standard TAX Invoice with custom data
        /// </summary>
        /// <param name="model">The tax invoice data to generate PDF from</param>
        /// <returns>PDF file of custom tax invoice</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] StandardTaxInvoiceModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.TaxInvoiceNumber))
            {
                return BadRequest(new { error = "Invalid request", message = "TaxInvoiceNumber is required" });
            }

            try
            {
                var document = new StandardTaxInvoiceDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"tax-invoice-{model.TaxInvoiceNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom tax invoice");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a TAX invoice model without generating PDF
        /// </summary>
        /// <param name="model">The tax invoice data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] StandardTaxInvoiceModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.TaxInvoiceNumber))
                errors.Add("TaxInvoiceNumber is required");
            if (string.IsNullOrEmpty(model.Seller?.CompanyName))
                errors.Add("Seller CompanyName is required");
            if (string.IsNullOrEmpty(model.Customer?.CompanyName))
                errors.Add("Customer CompanyName is required");
            if (model.Items == null || !model.Items.Any())
                errors.Add("At least one item is required");
            if (model.Items?.Any(x => x.Quantity <= 0) == true)
                errors.Add("All items must have quantity greater than 0");
            if (model.Items?.Any(x => x.UnitPrice < 0) == true)
                errors.Add("All items must have non-negative unit price");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}