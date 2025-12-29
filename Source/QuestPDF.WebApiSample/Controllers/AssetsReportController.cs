using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/assets-report")]
    public class AssetsReportController : BasePdfController
    {
        public AssetsReportController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates an Assets Report with sample data
        /// </summary>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GenerateSample()
        {
            var model = SampleDataGenerator.GetSampleAssetsReport();
            var document = new DynamicColumnReportDocument(model);

            var pdfBytes = document.GeneratePdf();

            return GeneratePdfFile(pdfBytes, "assets-report-sample.pdf");
        }

        /// <summary>
        /// Gets sample assets report data as JSON
        /// </summary>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DynamicColumnReportModel> GetSampleJson()
        {
            return Ok(SampleDataGenerator.GetSampleAssetsReport());
        }
    }
}