# PowerShell script to convert SVG to PNG
# This script uses common methods to convert SVG files to PNG

Write-Host "SVG to PNG Converter for QuestPDF Branding Images" -ForegroundColor Cyan
Write-Host "====================================================`n" -ForegroundColor Cyan

$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path

# Check if we have SVG files
$svgFiles = Get-ChildItem -Path $scriptPath -Filter "*.svg"

if ($svgFiles.Count -eq 0) {
    Write-Host "No SVG files found in the Images folder." -ForegroundColor Red
    exit
}

Write-Host "Found $($svgFiles.Count) SVG file(s) to convert`n" -ForegroundColor Green

# Method 1: Try using Inkscape (if installed)
$inkscapePath = "C:\Program Files\Inkscape\bin\inkscape.exe"
if (Test-Path $inkscapePath) {
    Write-Host "Using Inkscape for conversion..." -ForegroundColor Green
    foreach ($svg in $svgFiles) {
        $pngFile = $svg.FullName -replace '\.svg$', '.png'
        Write-Host "Converting $($svg.Name) to PNG..."
        & $inkscapePath $svg.FullName --export-filename=$pngFile --export-dpi=300
    }
    Write-Host "`nConversion complete! PNG files created." -ForegroundColor Green
    exit
}

# Method 2: Try using ImageMagick (if installed)
try {
    $magickVersion = magick --version 2>$null
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Using ImageMagick for conversion..." -ForegroundColor Green
        foreach ($svg in $svgFiles) {
            $pngFile = $svg.FullName -replace '\.svg$', '.png'
            Write-Host "Converting $($svg.Name) to PNG..."
            magick convert -density 300 -background none $svg.FullName $pngFile
        }
        Write-Host "`nConversion complete! PNG files created." -ForegroundColor Green
        exit
    }
} catch {}

# If no converter found, provide instructions
Write-Host "`nNo SVG converter found on your system." -ForegroundColor Yellow
Write-Host "`nTo convert SVG to PNG, you have several options:" -ForegroundColor White
Write-Host "`n1. ONLINE CONVERTER (Easiest):" -ForegroundColor Cyan
Write-Host "   - Visit: https://cloudconvert.com/svg-to-png" -ForegroundColor White
Write-Host "   - Upload each SVG file and download the PNG" -ForegroundColor White

Write-Host "`n2. INSTALL INKSCAPE (Recommended):" -ForegroundColor Cyan
Write-Host "   - Download from: https://inkscape.org/release/" -ForegroundColor White
Write-Host "   - Install and run this script again" -ForegroundColor White

Write-Host "`n3. INSTALL IMAGEMAGICK:" -ForegroundColor Cyan
Write-Host "   - Download from: https://imagemagick.org/script/download.php" -ForegroundColor White
Write-Host "   - Install and run this script again" -ForegroundColor White

Write-Host "`n4. MANUAL CONVERSION:" -ForegroundColor Cyan
Write-Host "   - Open each SVG in a web browser" -ForegroundColor White
Write-Host "   - Take a screenshot or use browser dev tools to export" -ForegroundColor White
Write-Host "   - Save as PNG with transparent background" -ForegroundColor White

Write-Host "`nPress any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
