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
    [Route("api/generic-report")]
    public class GenericReportController : BasePdfController
    {
        public GenericReportController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Generic Report with sample data
        /// </summary>
        /// <returns>PDF file of sample generic report</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleGenericReport();
                var document = new GenericReportDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, "generic-report-sample.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample generic report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample generic report data as JSON
        /// </summary>
        /// <returns>Sample generic report model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GenericReportModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleGenericReport());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample generic report JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample Arabic generic report data as JSON
        /// </summary>
        /// <returns>Sample Arabic generic report model</returns>
        [HttpGet("sample/arabic/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GenericReportModel> GetSampleArabicJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleGenericReportArabic());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample Arabic generic report JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Generic Report with custom data
        /// </summary>
        /// <param name="model">The report data to generate PDF from</param>
        /// <returns>PDF file of custom generic report</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] GenericReportModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            if (string.IsNullOrEmpty(model.ReportName))
            {
                return BadRequest(new { error = "Invalid request", message = "ReportName is required" });
            }

            try
            {
                var document = new GenericReportDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"generic-report-{DateTime.Now:yyyyMMdd}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom generic report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a Generic Report model without generating PDF
        /// </summary>
        /// <param name="model">The report data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] GenericReportModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.ReportName))
                errors.Add("ReportName is required");
            if (model.ColumnNames == null || !model.ColumnNames.Any())
                errors.Add("ColumnNames are required");
            if (model.Data == null || !model.Data.Any())
                errors.Add("At least one data row is required");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}