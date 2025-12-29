using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace QuestPDF.WebApiSample.Controllers;

/// <summary>
/// Base controller for PDF generation endpoints providing common functionality
/// </summary>
[ApiController]
public class BasePdfController : ControllerBase
{
    protected readonly ILogger<BasePdfController> _logger;

    public BasePdfController(ILogger<BasePdfController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Generates a PDF file response with proper content type and headers
    /// </summary>
    /// <param name="pdfBytes">The PDF byte array</param>
    /// <param name="fileName">The filename for the download</param>
    /// <returns>File result with PDF content</returns>
    protected IActionResult GeneratePdfFile(byte[] pdfBytes, string fileName)
    {
        return File(pdfBytes, "application/pdf", fileName);
    }

    /// <summary>
    /// Generates a PDF file with content disposition inline (for browser viewing)
    /// </summary>
    /// <param name="pdfBytes">The PDF byte array</param>
    /// <param name="fileName">The filename</param>
    /// <returns>Inline file result for browser display</returns>
    protected IActionResult GeneratePdfInline(byte[] pdfBytes, string fileName)
    {
        Response.Headers["Content-Disposition"] = $"inline; filename={fileName}";
        return File(pdfBytes, "application/pdf");
    }

    /// <summary>
    /// Creates a standardized success response for PDF generation
    /// </summary>
    /// <param name="pdfBytes">The PDF byte array</param>
    /// <param name="fileName">The filename</param>
    /// <param name="metadata">Optional metadata about the generated document</param>
    /// <returns>Success response with PDF and metadata</returns>
    protected IActionResult GeneratePdfWithMetadata(byte[] pdfBytes, string fileName, object? metadata = null)
    {
        var response = new
        {
            success = true,
            fileName = fileName,
            contentType = "application/pdf",
            contentLength = pdfBytes.Length,
            generatedAt = DateTime.UtcNow,
            metadata = metadata
        };

        Response.Headers["X-Generated-At"] = DateTime.UtcNow.ToString("o");
        Response.Headers["X-Content-Length"] = pdfBytes.Length.ToString();

        return File(pdfBytes, "application/pdf", fileName);
    }

    /// <summary>
    /// Creates a JSON success response with document information
    /// </summary>
    /// <param name="documentType">Type of document generated</param>
    /// <param name="documentId">ID of the document</param>
    /// <param name="additionalData">Any additional data to include</param>
    /// <returns>JSON success response</returns>
    protected IActionResult CreateSuccessResponse(string documentType, string documentId, object? additionalData = null)
    {
        var response = new
        {
            success = true,
            documentType = documentType,
            documentId = documentId,
            generatedAt = DateTime.UtcNow,
            downloadUrl = $"/api/{documentType.ToLower()}/{documentId}",
            additionalData = additionalData
        };

        return Ok(response);
    }

    /// <summary>
    /// Creates a standardized error response
    /// </summary>
    /// <param name="errorCode">Error code identifier</param>
    /// <param name="message">Error message</param>
    /// <param name="details">Optional error details</param>
    /// <returns>JSON error response</returns>
    protected IActionResult CreateErrorResponse(string errorCode, string message, object? details = null)
    {
        var response = new
        {
            success = false,
            error = new
            {
                code = errorCode,
                message = message,
                details = details,
                timestamp = DateTime.UtcNow
            }
        };

        return BadRequest(response);
    }

    /// <summary>
    /// Logs PDF generation event
    /// </summary>
    /// <param name="documentType">Type of document</param>
    /// <param name="documentId">Document identifier</param>
    /// <param name="success">Whether generation was successful</param>
    /// <param name="durationMs">Generation duration in milliseconds</param>
    protected void LogPdfGeneration(string documentType, string documentId, bool success, long durationMs)
    {
        _logger.LogInformation("PDF generated: Type={DocumentType}, Id={DocumentId}, Success={Success}, Duration={DurationMs}ms",
            documentType, documentId, success, durationMs);
    }
}