using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/project-timeline")]
    public class ProjectTimelineController : BasePdfController
    {
        public ProjectTimelineController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates a Project Timeline with sample data
        /// </summary>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GenerateSample()
        {
            var model = SampleDataGenerator.GetSampleProjectTimelineReport();
            var document = new DynamicColumnReportDocument(model);

            var pdfBytes = document.GeneratePdf();

            return GeneratePdfFile(pdfBytes, "project-timeline-sample.pdf");
        }

        /// <summary>
        /// Gets sample project timeline data as JSON
        /// </summary>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DynamicColumnReportModel> GetSampleJson()
        {
            return Ok(SampleDataGenerator.GetSampleProjectTimelineReport());
        }
    }
}