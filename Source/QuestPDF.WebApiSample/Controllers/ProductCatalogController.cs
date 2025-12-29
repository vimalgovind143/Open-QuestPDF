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
    [Route("api/product-catalog")]
    public class ProductCatalogController : BasePdfController
    {
        public ProductCatalogController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Product Catalog with sample data
        /// </summary>
        /// <returns>PDF file of sample product catalog</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleProductCatalog();
                var document = new ProductCatalogDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, "product-catalog-sample.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample product catalog");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample product catalog data as JSON
        /// </summary>
        /// <returns>Sample product catalog model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductCatalogModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleProductCatalog());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample product catalog JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Product Catalog with custom data
        /// </summary>
        /// <param name="model">The product catalog data to generate PDF from</param>
        /// <returns>PDF file of custom product catalog</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] ProductCatalogModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.CatalogTitle))
            {
                return BadRequest(new { error = "Invalid request", message = "CatalogTitle is required" });
            }

            try
            {
                var document = new ProductCatalogDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"product-catalog-{DateTime.Now:yyyyMMdd}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom product catalog");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a Product Catalog model without generating PDF
        /// </summary>
        /// <param name="model">The product catalog data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] ProductCatalogModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.CatalogTitle))
                errors.Add("CatalogTitle is required");
            if (model.Categories == null || !model.Categories.Any())
                errors.Add("At least one category is required");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}