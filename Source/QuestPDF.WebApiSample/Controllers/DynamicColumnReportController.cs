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
    [Route("api/dynamic-column-report")]
    public class DynamicColumnReportController : BasePdfController
    {
        public DynamicColumnReportController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Dynamic Column Report with sample data
        /// </summary>
        /// <returns>PDF file of sample dynamic column report</returns>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateSample()
        {
            try
            {
                var model = SampleDataGenerator.GetSampleDynamicColumnReport();
                var document = new DynamicColumnReportDocument(model);

                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, "dynamic-report-sample.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample dynamic column report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Gets sample dynamic column report data as JSON
        /// </summary>
        /// <returns>Sample dynamic column report model</returns>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DynamicColumnReportModel> GetSampleJson()
        {
            try
            {
                return Ok(SampleDataGenerator.GetSampleDynamicColumnReport());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sample dynamic column report JSON");
                return StatusCode(500, new { error = "Failed to generate JSON", message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a Dynamic Column Report with custom data
        /// </summary>
        /// <param name="model">The report data to generate PDF from</param>
        /// <returns>PDF file of custom dynamic column report</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateCustom([FromBody] DynamicColumnReportModel model)
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
                var document = new DynamicColumnReportDocument(model);
                var pdfBytes = document.GeneratePdf();

                return GeneratePdfFile(pdfBytes, $"dynamic-report-{DateTime.Now:yyyyMMdd}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating custom dynamic column report");
                return StatusCode(500, new { error = "Failed to generate PDF", message = ex.Message });
            }
        }

        /// <summary>
        /// Validates a Dynamic Column Report model without generating PDF
        /// </summary>
        /// <param name="model">The report data to validate</param>
        /// <returns>Validation result</returns>
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Validate([FromBody] DynamicColumnReportModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "Invalid request", message = "Model cannot be null" });
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.ReportTitle))
                errors.Add("ReportTitle is required");
            if (model.ColumnHeaders == null || !model.ColumnHeaders.Any())
                errors.Add("ColumnHeaders are required");
            if (model.DataRows == null || !model.DataRows.Any())
                errors.Add("At least one data row is required");

            if (errors.Any())
            {
                return BadRequest(new { error = "Validation failed", messages = errors });
            }

            return Ok(new { valid = true, message = "Model is valid" });
        }
    }
}