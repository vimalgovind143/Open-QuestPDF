using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/attendance-report")]
    public class AttendanceReportController : BasePdfController
    {
        public AttendanceReportController(ILogger<BasePdfController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Generates an Attendance Report with sample data
        /// </summary>
        [HttpGet("sample")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GenerateSample()
        {
            var model = SampleDataGenerator.GetSampleAttendanceReport();
            var document = new DynamicColumnReportDocument(model);

            var pdfBytes = document.GeneratePdf();

            return GeneratePdfFile(pdfBytes, "attendance-report-sample.pdf");
        }

        /// <summary>
        /// Gets sample attendance report data as JSON
        /// </summary>
        [HttpGet("sample/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DynamicColumnReportModel> GetSampleJson()
        {
            return Ok(SampleDataGenerator.GetSampleAttendanceReport());
        }
    }
}