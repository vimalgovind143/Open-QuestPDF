using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/[controller]")]
    public class ReceiptController : BasePdfController
    {
        public ReceiptController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Receipt with sample data
        /// </summary>
        /// <returns>PDF file of sample receipt</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleReceipt();
                var document = new ReceiptDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"receipt-{model.ReceiptNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample receipt");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample receipt data as JSON
        /// </summary>
        /// <returns>Sample receipt model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReceiptModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleReceipt());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample receipt JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Receipt with custom data
        /// </summary>
        /// <param name="model">The receipt data to generate PDF from</param>
        /// <returns>PDF file of custom receipt</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] ReceiptModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.ReceiptNumber))
            {
                return BadRequest(new { error = "Invalid request", message = "ReceiptNumber is required" });
            }

            try
            {
                var document = new ReceiptDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"receipt-{model.ReceiptNumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom receipt");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a Receipt model without generating PDF
        /// </summary>
        /// <param name="model">The receipt data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] ReceiptModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.ReceiptNumber))
                errors.Add("ReceiptNumber is required");
            if (string.IsNullOrEmpty(model.Customer?.Name))
                errors.Add("Customer Name is required");
            if (model.Items == null || !model.Items.Any())
                errors.Add("At least one item is required");
            if (model.Items?.Any(x => x.Amount < 0) == true)
                errors.Add("All items must have non-negative amounts");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}