using QRCoder;

namespace QuestPDF.WebApiSample;

/// <summary>
/// Helper class for generating QR codes for PDF documents
/// </summary>
public static class QRCodeHelper
{
    /// <summary>
    /// Generates a QR code image as byte array
    /// </summary>
    /// <param name="data">The data to encode in the QR code</param>
    /// <param name="pixelsPerModule">Size of each QR module (default: 20)</param>
    /// <returns>PNG image as byte array</returns>
    public static byte[] GenerateQRCode(string data, int pixelsPerModule = 20)
    {
        if (string.IsNullOrEmpty(data))
            return Array.Empty<byte>();

        try
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(pixelsPerModule);
        }
        catch
        {
            return Array.Empty<byte>();
        }
    }

    /// <summary>
    /// Generates a verification URL QR code for payslip authenticity
    /// </summary>
    /// <param name="payslipNumber">The payslip number</param>
    /// <param name="employeeId">The employee ID</param>
    /// <param name="baseUrl">Base URL for verification (optional)</param>
    /// <returns>PNG image as byte array</returns>
    public static byte[] GeneratePayslipQRCode(string payslipNumber, string employeeId, string? baseUrl = null)
    {
        baseUrl ??= "https://verify.company.com/payslip";
        var verificationUrl = $"{baseUrl}?ref={payslipNumber}&emp={employeeId}";
        return GenerateQRCode(verificationUrl);
    }

    /// <summary>
    /// Generates a QR code with structured payslip data
    /// </summary>
    /// <param name="payslipNumber">The payslip number</param>
    /// <param name="employeeId">The employee ID</param>
    /// <param name="employeeName">The employee name</param>
    /// <param name="netPay">Net pay amount</param>
    /// <param name="payDate">Pay date</param>
    /// <returns>PNG image as byte array</returns>
    public static byte[] GeneratePayslipDataQRCode(
        string payslipNumber, 
        string employeeId, 
        string employeeName, 
        decimal netPay, 
        DateTime payDate)
    {
        var qrData = $"PAYSLIP|{payslipNumber}|{employeeId}|{employeeName}|{netPay:F3}|{payDate:yyyy-MM-dd}";
        return GenerateQRCode(qrData);
    }
}
