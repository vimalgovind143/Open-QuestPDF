# Company Branding Implementation Guide

This guide explains the branding features added to all PDF documents in the QuestPDF WebAPI Sample.

## What Was Added

### ✅ All Documents Now Include:

#### 1. **Header Logo (Top Right)**
All 6 document types now display your company logo in the top-right corner:
- Standard Tax Invoice
- Receipt Document
- Purchase Order
- Dynamic Column Report
- Product Catalog (shown on left in landscape mode)
- Employee Report

**Specifications:**
- Location: Top right header (or left for catalog)
- Recommended size: 120x60 pixels
- File: `Images/company-logo.png`
- Fallback: "LOGO" placeholder if file missing

#### 2. **Footer Logo with Company Info**
Enhanced footers now include:
- Small company logo (left side)
- Company name and address
- Page numbers

**Specifications:**
- Location: Document footer
- Recommended size: 40x30 pixels
- File: `Images/company-logo-footer.png`
- Fallback: Uses main logo if footer logo missing

#### 3. **Watermark (All Pages)**
Semi-transparent background watermark on every page:
- Centered on page
- 15% opacity (very subtle)
- Applied across all document types

**Specifications:**
- Location: Page background (centered, middle)
- Recommended size: 400x400 pixels (450px for landscape)
- File: `Images/watermark.png`
- Opacity: 15% (automatically applied)
- Best practice: Use light colored/transparent source image

#### 4. **Company Seal/Stamp (Official Documents)**
Official company seal added to signature sections:
- **Tax Invoice:** Bottom signature area (80x80px)
- **Receipt:** Signature section (60x60px)
- **Purchase Order:** Approval section (70x70px)

**Specifications:**
- Location: Signature/approval sections
- Recommended size: 60-80 pixels (square)
- File: `Images/company-seal.png`
- Fallback: Text placeholder ("Company Stamp", "Signature")

## Quick Start

### Step 1: Create Images Folder
```bash
# From the project root
mkdir Images
```

### Step 2: Add Your Images
Place these files in the `Images` folder:
```
Images/
├── company-logo.png           # Required: Main logo
├── company-logo-footer.png    # Optional: Smaller footer version
├── company-seal.png           # Required for official documents
└── watermark.png              # Optional: Background watermark
```

### Step 3: Generate Test PDFs
```bash
# Start the application
dotnet run

# Test endpoints (or use Swagger at http://localhost:5100/swagger)
curl http://localhost:5100/api/pdf/tax-invoice/sample --output test-invoice.pdf
curl http://localhost:5100/api/pdf/product-catalog/sample --output test-catalog.pdf
```

## Document-Specific Details

### Tax Invoice
- ✅ Logo: Top right (120x60px)
- ✅ Watermark: Center background
- ✅ Seal: Signature section (80x80px)
- ✅ Footer logo with company info

### Receipt (A5)
- ✅ Logo: Top right (70x50px, smaller for A5)
- ✅ Watermark: Center background (250px width)
- ✅ Seal: Signature section (60x60px)
- ✅ Footer logo with company name

### Purchase Order
- ✅ Logo: Top right (100x55px)
- ✅ Watermark: Center background
- ✅ Seal: Approval section (70x70px)
- ✅ Footer logo with buyer company info

### Dynamic Column Report
- ✅ Logo: Top right (80x50px)
- ✅ Watermark: Center background
- ✅ Footer: Page numbers only (no logo in this version)

### Product Catalog (Landscape)
- ✅ Logo: Header left (80x60px, different placement for landscape)
- ✅ Watermark: Center background (450px width for landscape)
- ✅ Footer logo with company info

### Employee Report
- ✅ Logo: Header center-right (100x55px)
- ✅ Watermark: Center background
- ✅ Footer: Page numbers with "Confidential" text

## Image Preparation Tips

### Creating a Watermark
1. Use your company logo as base
2. Make it very light (10-20% opacity in your image editor)
3. Save as PNG with transparency
4. The system will apply additional 15% opacity

### Logo Best Practices
- **Format:** PNG with transparent background
- **Resolution:** 300 DPI for print quality
- **Colors:** Match your brand guidelines
- **Aspect Ratio:** Maintain logo proportions
- **File Size:** Keep under 500KB

### Seal/Stamp Design
- Circular design works best
- Include company name and registration number
- High contrast for visibility when printed
- Save with transparent background

## Testing Without Images

The system is designed to work without images:
- Missing logos show placeholder boxes
- Missing seals show text labels
- Missing watermarks are simply omitted
- All documents remain functional

This allows you to:
1. Test the application immediately
2. See placeholder positions before adding real images
3. Deploy without images and add them later

## Image Helper Class

A new `ImageHelper.cs` class manages all images:

```csharp
// Get company logo
var logo = ImageHelper.GetCompanyLogo();

// Get footer logo (falls back to main logo)
var footerLogo = ImageHelper.GetFooterLogo();

// Get company seal
var seal = ImageHelper.GetCompanySeal();

// Get watermark
var watermark = ImageHelper.GetWatermark();
```

The helper automatically:
- Loads images from the `Images` folder
- Returns null for missing images (graceful degradation)
- Handles file reading errors safely

## Customization

### Change Watermark Opacity
Edit the document files and modify the opacity value:
```csharp
container.AlignCenter().AlignMiddle().Width(400).Opacity(0.15f).Image(watermark);
                                                           // ^^^^ Change this value (0.0 to 1.0)
```

### Adjust Logo Sizes
Modify the `.Height()` or `.Width()` values in document code:
```csharp
logoCol.Item().Height(60).Image(logo, ImageScaling.FitArea);
                      // ^^ Adjust height in pixels
```

### Different Watermark Per Document
Modify `ImageHelper.cs` to support multiple watermarks:
```csharp
public static byte[]? GetWatermark(string documentType)
{
    return GetImageBytes($"watermark-{documentType}.png") ?? GetImageBytes("watermark.png");
}
```

## Production Considerations

1. **Image Optimization:** Compress images before deployment
2. **Caching:** Consider caching loaded images in memory for performance
3. **Multiple Brands:** Extend `ImageHelper` to support tenant-specific images
4. **Dynamic Loading:** Load from database or cloud storage instead of filesystem
5. **Error Logging:** Add logging for image loading failures

## Troubleshooting

### Images Not Appearing?
1. Check file names match exactly (case-sensitive)
2. Verify `Images` folder is in the correct location
3. Ensure images are PNG format
4. Check file permissions
5. Restart the application after adding images

### Poor Image Quality?
1. Use higher resolution source images
2. Ensure images are at least 300 DPI
3. Avoid upscaling small images
4. Use vector formats when possible (convert to high-res PNG)

### Watermark Too Dark/Light?
1. Adjust source image opacity in image editor
2. Modify the `.Opacity()` value in code
3. Use lighter/darker source colors

## Support

For detailed image specifications, see: `Images/README.md`

For code implementation details, see: `ImageHelper.cs`

All document classes now include branding support - check individual files in `Documents/` folder.
