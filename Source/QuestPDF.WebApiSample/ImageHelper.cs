using QuestPDF.Infrastructure;

namespace QuestPDF.WebApiSample;

/// <summary>
/// Helper class for managing images in PDF documents
/// Place your logo files in the "Images" folder at the project root
/// </summary>
public static class ImageHelper
{
    private static readonly string ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

    /// <summary>
    /// Gets the company logo image data (for header)
    /// Expected file: Images/company-logo.png
    /// </summary>
    public static byte[]? GetCompanyLogo()
    {
        return GetImageBytes("company-logo.png");
    }

    /// <summary>
    /// Gets the footer logo image data (smaller version for footer)
    /// Expected file: Images/company-logo-footer.png
    /// If not found, falls back to main logo
    /// </summary>
    public static byte[]? GetFooterLogo()
    {
        return GetImageBytes("company-logo-footer.png") ?? GetCompanyLogo();
    }

    /// <summary>
    /// Gets the company seal/stamp image data (for official documents)
    /// Expected file: Images/company-seal.png
    /// </summary>
    public static byte[]? GetCompanySeal()
    {
        return GetImageBytes("company-seal.png");
    }

    /// <summary>
    /// Gets the watermark image data (for background)
    /// Expected file: Images/watermark.png
    /// Should be a semi-transparent image
    /// </summary>
    public static byte[]? GetWatermark()
    {
        return GetImageBytes("watermark.png");
    }

    private static byte[]? GetImageBytes(string fileName)
    {
        try
        {
            var filePath = Path.Combine(ImagePath, fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Creates placeholder image data (for testing without actual images)
    /// </summary>
    public static byte[] CreatePlaceholder(int width, int height, string text)
    {
        // For now, return null - QuestPDF will handle missing images gracefully
        // In production, you would have actual image files
        return Array.Empty<byte>();
    }
}
