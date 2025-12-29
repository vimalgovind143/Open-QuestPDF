# Images Folder

Place your company images in this folder for use in PDF documents.

## Required Image Files

### 1. **company-logo.png**
- **Usage:** Main company logo displayed in document headers (top right)
- **Recommended Size:** 120x60 pixels (width x height)
- **Format:** PNG with transparent background preferred
- **Example placement:** 
  - Tax Invoice (top right)
  - Receipt (top right)
  - Purchase Order (top right)
  - Employee Report (header right)
  - Dynamic Column Report (header right)
  - Product Catalog (header left)

### 2. **company-logo-footer.png** (Optional)
- **Usage:** Smaller version of logo for document footers
- **Recommended Size:** 40x30 pixels (width x height)
- **Format:** PNG with transparent background
- **Fallback:** If not provided, the main `company-logo.png` will be used
- **Example placement:** All document footers

### 3. **company-seal.png**
- **Usage:** Official company stamp/seal for signatures
- **Recommended Size:** 80x80 pixels (square)
- **Format:** PNG with transparent background or circular design
- **Example placement:**
  - Tax Invoice (signature section)
  - Receipt (signature section)
  - Purchase Order (approval section)

### 4. **watermark.png**
- **Usage:** Background watermark on all pages
- **Recommended Size:** 400x400 pixels (square)
- **Format:** PNG with transparency (semi-transparent, 15% opacity will be applied)
- **Note:** Should be a light/subtle design (e.g., company logo in very light gray)
- **Example placement:** Center of all document pages

## Image Guidelines

1. **File Names:** Use exact filenames as listed above (case-sensitive on some systems)
2. **Format:** PNG is recommended for transparency support
3. **Quality:** Use high-resolution images for better print quality (300 DPI recommended)
4. **File Size:** Keep images optimized (<500KB each) for faster PDF generation
5. **Transparency:** Use transparent backgrounds for logos and seals for professional appearance

## Example Folder Structure

```
Images/
├── company-logo.png              # Main header logo
├── company-logo-footer.png       # Optional footer logo
├── company-seal.png              # Official seal/stamp
├── watermark.png                 # Background watermark
└── README.md                     # This file
```

## Testing Without Images

If images are not present, the system will gracefully handle their absence:
- **Logos:** Placeholder boxes with "LOGO" text will appear
- **Seals:** Text placeholders like "Company Stamp" or "Signature" will be shown
- **Watermarks:** No watermark will be applied

This allows you to test the application without having actual image files.

## Adding Your Images

1. Create or obtain your company images
2. Rename them according to the filenames above
3. Place them in this `Images` folder
4. Restart the application (if running)
5. Generate PDFs to see your images in place

## Image Preparation Tips

### For Logos:
- Use transparent backgrounds
- Keep text and details clear and readable
- Avoid excessive detail that might not scale well
- Test at different sizes

### For Seals:
- Circular or official stamp design works best
- Include company name and registration if applicable
- High contrast for better visibility

### For Watermarks:
- Use very light colors (10-20% opacity in source)
- Simple design (company logo or text)
- Large enough to cover page but not distract from content

## Need Help?

If you're having trouble with images:
1. Check file names match exactly (including case)
2. Ensure images are in PNG format
3. Verify images are not corrupted
4. Check image file permissions
5. Review console logs for any error messages
