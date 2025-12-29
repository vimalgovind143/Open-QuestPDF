# SVG to PNG Conversion Guide

I've created SVG versions of your branding images. Now you need to convert them to PNG format for use in the PDF documents.

## Created SVG Files

✅ **company-logo.svg** - Main header logo (240x120)  
✅ **company-logo-footer.svg** - Footer logo (80x60)  
✅ **company-seal.svg** - Official company seal (160x160)  
✅ **watermark.svg** - Background watermark (800x800)  

## Conversion Methods

### Option 1: Online Converter (EASIEST - No Installation Required)

**CloudConvert (Free, No Signup Required):**
1. Visit: https://cloudconvert.com/svg-to-png
2. Upload each SVG file
3. Click "Convert"
4. Download the PNG files
5. Save them in the `Images` folder (keep the same names, just .png extension)

**Alternative Online Tools:**
- https://svgtopng.com/
- https://convertio.co/svg-png/
- https://www.online-convert.com/

### Option 2: Using PowerShell Script (Automated)

I've created a PowerShell script for you:

```powershell
# Run from the Images folder
.\convert-svg-to-png.ps1
```

The script will:
- Detect if you have Inkscape or ImageMagick installed
- Automatically convert all SVG files to PNG
- Provide installation instructions if no converter found

### Option 3: Browser Method (Manual but Simple)

**For each SVG file:**

1. **Open in Browser:**
   - Right-click the SVG file
   - Select "Open with" → Choose your web browser (Chrome/Edge/Firefox)

2. **Take Screenshot or Export:**
   
   **Chrome/Edge Method:**
   - Press F12 (open DevTools)
   - Press Ctrl+Shift+P
   - Type "screenshot" and select "Capture node screenshot"
   - Click on the SVG element and save

   **Firefox Method:**
   - Right-click on the SVG
   - Select "Take a Screenshot"
   - Select the area and save

3. **Save as PNG:**
   - Save with the correct filename (e.g., `company-logo.png`)
   - Place in the `Images` folder

### Option 4: Install Inkscape (Best for Future Editing)

**Inkscape is free and professional:**

1. Download from: https://inkscape.org/release/
2. Install (use default settings)
3. Run the PowerShell script, or:
   - Open each SVG in Inkscape
   - File → Export PNG Image
   - Set DPI to 300 (high quality)
   - Export

### Option 5: Install ImageMagick (Command Line)

**For developers comfortable with command line:**

1. Download from: https://imagemagick.org/script/download.php
2. Install (make sure to check "Add to PATH")
3. Restart terminal/PowerShell
4. Run:
   ```powershell
   magick convert -density 300 -background none company-logo.svg company-logo.png
   magick convert -density 300 -background none company-logo-footer.svg company-logo-footer.png
   magick convert -density 300 -background none company-seal.svg company-seal.png
   magick convert -density 300 -background none watermark.svg watermark.png
   ```

## Verification

After conversion, you should have these PNG files:
```
Images/
├── company-logo.png          ✓ Required
├── company-logo-footer.png   ✓ Required
├── company-seal.png          ✓ Required
├── watermark.png             ✓ Required
```

## Testing

Once you have PNG files:

1. **Restart the application:**
   ```bash
   dotnet run
   ```

2. **Generate a test PDF:**
   ```bash
   curl http://localhost:5100/api/pdf/tax-invoice/sample --output test-invoice.pdf
   ```

3. **Open the PDF and verify:**
   - Logo appears in top-right header
   - Watermark is visible (very light) in background
   - Company seal appears in signature section
   - Footer logo shows at bottom

## Customization

Once converted, you can:
- Edit the PNG files in any image editor
- Replace with your actual company logos
- Adjust colors to match your brand
- Keep the SVG files as templates for future changes

## Recommended Image Specifications

For best results when creating final versions:
- **Format:** PNG with transparent background
- **Resolution:** 300 DPI
- **Color Mode:** RGB
- **Compression:** Optimize for web (reasonable file size)

## Need Help?

If you have issues:
1. Ensure SVG files are in the `Images` folder
2. Try the online converter method (easiest)
3. Check the generated PNG files are not corrupted
4. Verify filenames match exactly (case-sensitive)

The application will work with placeholders if conversion fails, so you can always convert later!
