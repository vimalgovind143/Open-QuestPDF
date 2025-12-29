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
    [Route("api/purchase-order")]
    public class PurchaseOrderController : BasePdfController
    {
        public PurchaseOrderController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Purchase Order with sample data
        /// </summary>
        /// <returns>PDF file of sample purchase order</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSamplePurchaseOrder();
                var document = new PurchaseOrderDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"purchase-order-{model.PONumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample purchase order");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample purchase order data as JSON
        /// </summary>
        /// <returns>Sample purchase order model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PurchaseOrderModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSamplePurchaseOrder());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample purchase order JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Purchase Order with custom data
        /// </summary>
        /// <param name="model">The purchase order data to generate PDF from</param>
        /// <returns>PDF file of custom purchase order</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] PurchaseOrderModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.PONumber))
            {
                return BadRequest(new { error = "Invalid request", message = "PONumber is required" });
            }

            try
            {
                var document = new PurchaseOrderDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"purchase-order-{model.PONumber}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom purchase order");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a Purchase Order model without generating PDF
        /// </summary>
        /// <param name="model">The purchase order data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] PurchaseOrderModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.PONumber))
                errors.Add("PONumber is required");
            if (string.IsNullOrEmpty(model.Buyer?.CompanyName))
                errors.Add("Buyer CompanyName is required");
            if (string.IsNullOrEmpty(model.Supplier?.CompanyName))
                errors.Add("Supplier CompanyName is required");
            if (model.Items == null || !model.Items.Any())
                errors.Add("At least one item is required");
            if (model.Items?.Any(x => x.Quantity <= 0) == true)
                errors.Add("All items must have quantity greater than 0");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}