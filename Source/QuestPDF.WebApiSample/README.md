# QuestPDF Web API Sample

A real-time PDF generation web API built with **ASP.NET Core** and **QuestPDF**. This sample demonstrates how to generate professional PDF documents on-demand through RESTful endpoints.

## Features

✅ **Real-time PDF Generation** - Generate PDFs dynamically via HTTP requests  
✅ **RESTful API** - Easy-to-use endpoints for PDF creation  
✅ **Swagger UI** - Interactive API documentation and testing  
✅ **Multiple Document Types** - Various business document templates  
✅ **Sample Data** - Pre-built examples to get started quickly  
✅ **Dynamic Layouts** - Reports with variable columns determined at runtime  
✅ **Multiple Orientations** - Both A4 Portrait and Landscape formats  
✅ **Branding Support** - Add company logos, seals, and watermarks to all documents  
✅ **POST Endpoints** - Submit custom data to generate personalized PDFs  
✅ **Validation Endpoints** - Validate document models before generation  
✅ **Global Exception Handling** - Consistent error responses across all endpoints  
✅ **Health Check Endpoint** - Monitor API availability at `/health`  
✅ **Enhanced Base Controller** - Reusable helper methods for PDF generation  
✅ **QR Code Support** - Authenticity verification for payslips  
✅ **Password Protection** - Optional 128-bit PDF encryption  

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- Your favorite HTTP client (browser, Postman, curl, etc.)

### Running the Application

1. **Navigate to the project directory:**
   ```bash
   cd Source\QuestPDF.WebApiSample
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

4. **Access Swagger UI:**
   Open your browser and navigate to:
   - HTTP: http://localhost:5100/swagger
   - HTTPS: https://localhost:5001/swagger

5. **Health Check:**
   - http://localhost:5100/health

---

## API Endpoints

### Financial Ledger Reports

#### 1. Income Statement
Professional income statement showing revenue, expenses, and net income for a period.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/income-statement/sample` | Generate sample income statement |
| GET | `/api/ledger/income-statement/sample/json` | Get sample data as JSON |

**Example:**
```bash
curl http://localhost:5100/api/ledger/income-statement/sample --output income-statement.pdf
```

---

#### 2. Financial Position (Balance Sheet)
Statement of financial position showing assets, liabilities, and equity at a point in time.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/financial-position/sample` | Generate sample financial position |
| GET | `/api/ledger/financial-position/sample/json` | Get sample data as JSON |

**Example:**
```bash
curl http://localhost:5100/api/ledger/financial-position/sample --output financial-position.pdf
```

---

#### 3. Trial Balance
Complete trial balance listing all ledger accounts with debit and credit balances.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/trial-balance/sample` | Generate sample trial balance |
| GET | `/api/ledger/trial-balance/sample/json` | Get sample data as JSON |

**Example:**
```bash
curl http://localhost:5100/api/ledger/trial-balance/sample --output trial-balance.pdf
```

---

#### 4. 2-Year Comparison Report
Financial performance comparison across two periods with variance analysis.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/comparison/sample` | Generate sample comparison report |
| GET | `/api/ledger/comparison/sample/json` | Get sample data as JSON |

**Example:**
```bash
curl http://localhost:5100/api/ledger/comparison/sample --output comparison-report.pdf
```

---

#### 5. Budget Comparison Report
Comparison of actual results against budgeted amounts with variance analysis.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/budget-comparison/sample` | Generate sample budget comparison |
| GET | `/api/ledger/budget-comparison/sample/json` | Get sample data as JSON |

**Example:**
```bash
curl http://localhost:5100/api/ledger/budget-comparison/sample --output budget-comparison.pdf
```

---

#### 6. Enhanced 12-Column Budget Comparison Report ⭐
Comprehensive monthly budget analysis with account grouping in landscape mode.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/enhanced-budget-comparison/sample` | Generate enhanced budget comparison |
| GET | `/api/ledger/enhanced-budget-comparison/sample/json` | Get sample data as JSON |

**Key Features:**
- **12 Monthly Columns**: Full year breakdown with monthly budget vs actual data
- **Account Chart Grouping**: Hierarchical organization by account categories
- **Landscape Orientation**: Optimized layout for wide table display
- **Variance Color Coding**: Visual indicators for performance
  - 🟢 Green: Within 5% variance (On Target)
  - 🟡 Yellow: 5-10% variance (Slightly Off Target)
  - 🔴 Red: >10% variance (Significant Variance)

**Example:**
```bash
curl http://localhost:5100/api/ledger/enhanced-budget-comparison/sample --output enhanced-budget-comparison.pdf
```

---

#### 7. All Ledger Reports
Generate all ledger reports at once.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ledger/all-reports/sample` | Generate all ledger reports |

**Example:**
```bash
curl http://localhost:5100/api/ledger/all-reports/sample --output all-ledger-reports.pdf
```

---

### Core Business Documents

#### 1. Standard TAX Invoice
Professional tax invoice with VAT calculations, multi-page support, and Arabic text.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tax-invoice/sample` | Generate sample TAX invoice |
| POST | `/api/tax-invoice` | Generate custom TAX invoice |
| GET | `/api/tax-invoice/sample/json` | Get sample data as JSON |
| POST | `/api/tax-invoice/validate` | Validate TAX invoice model |

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/tax-invoice/sample --output tax-invoice.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/tax-invoice \
  -H "Content-Type: application/json" \
  -d @tax-invoice-data.json \
  --output custom-invoice.pdf

# Validate before generation
curl -X POST http://localhost:5100/api/tax-invoice/validate \
  -H "Content-Type: application/json" \
  -d @tax-invoice-data.json
```

---

#### 2. Receipt Document
Compact A5 receipt for payment confirmations.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/receipt/sample` | Generate sample receipt |
| POST | `/api/receipt` | Generate custom receipt |
| GET | `/api/receipt/sample/json` | Get sample data as JSON |
| POST | `/api/receipt/validate` | Validate receipt model |

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/receipt/sample --output receipt.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/receipt \
  -H "Content-Type: application/json" \
  -d @receipt-data.json \
  --output custom-receipt.pdf
```

---

#### 3. Purchase Order
Comprehensive purchase order with delivery details and approval signatures.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/purchase-order/sample` | Generate sample purchase order |
| POST | `/api/purchase-order` | Generate custom purchase order |
| GET | `/api/purchase-order/sample/json` | Get sample data as JSON |
| POST | `/api/purchase-order/validate` | Validate purchase order model |

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/purchase-order/sample --output purchase-order.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/purchase-order \
  -H "Content-Type: application/json" \
  -d @po-data.json \
  --output custom-po.pdf
```

---

### Dynamic Column Reports

#### Dynamic Column Report
Flexible report with variable columns determined at runtime - perfect for sales reports, analytics, or any data with changing column structures.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/dynamic-column-report/sample` | Generate sample report |
| POST | `/api/dynamic-column-report` | Generate custom report |
| GET | `/api/dynamic-column-report/sample/json` | Get sample data as JSON |
| POST | `/api/dynamic-column-report/validate` | Validate report model |

**Key Features:**
- Variable number of columns
- Highlighted rows for emphasis
- Summary row support
- Ideal for quarterly reports, regional analysis

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/dynamic-column-report/sample --output dynamic-report.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/dynamic-column-report \
  -H "Content-Type: application/json" \
  -d @report-data.json \
  --output custom-report.pdf
```

---

#### Employee Attendance Report (Dynamic Columns)
Daily attendance tracking with dynamic date columns - perfect for HR departments monitoring employee presence.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pdf/attendance-report/sample` | Generate sample attendance report |
| POST | `/api/pdf/attendance-report` | Generate custom attendance report |
| GET | `/api/pdf/attendance-report/sample/json` | Get sample data as JSON |

**Key Features:**
- Daily attendance columns (P/A/L indicators)
- Summary statistics (Present/Absent/Late days)
- Attendance percentage calculation
- Department-level totals

**Example:**
```bash
curl http://localhost:5100/api/pdf/attendance-report/sample --output attendance-report.pdf
```

---

#### IT Assets Distribution Report (Dynamic Columns)
Asset tracking across multiple locations and status categories - ideal for IT asset management.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pdf/assets-report/sample` | Generate sample assets report |
| POST | `/api/pdf/assets-report` | Generate custom assets report |
| GET | `/api/pdf/assets-report/sample/json` | Get sample data as JSON |

**Key Features:**
- Location-based asset distribution
- Status tracking (Active/Maintenance/Retired)
- Asset type categorization
- Total counts and summaries

**Example:**
```bash
curl http://localhost:5100/api/pdf/assets-report/sample --output assets-report.pdf
```

---

#### Budget Analysis Report (Dynamic Columns)
Budget vs actual spending analysis with monthly breakdown - perfect for financial tracking and variance analysis.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pdf/budget-analysis/sample` | Generate sample budget analysis |
| POST | `/api/pdf/budget-analysis` | Generate custom budget analysis |
| GET | `/api/pdf/budget-analysis/sample/json` | Get sample data as JSON |

**Key Features:**
- Monthly actual vs budget comparison
- Year-to-date totals and variances
- Budget utilization percentages
- Highlighted over/under-budget categories

**Example:**
```bash
curl http://localhost:5100/api/pdf/budget-analysis/sample --output budget-analysis.pdf
```

---

#### Project Timeline Report (Dynamic Columns)
Project milestone tracking with status indicators - ideal for project management and progress monitoring.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pdf/project-timeline/sample` | Generate sample project timeline |
| POST | `/api/pdf/project-timeline` | Generate custom project timeline |
| GET | `/api/pdf/project-timeline/sample/json` | Get sample data as JSON |

**Key Features:**
- Milestone progress tracking (✓/In Progress/Pending)
- Project status and risk level indicators
- Progress percentage calculation
- Portfolio-level summary statistics

**Example:**
```bash
curl http://localhost:5100/api/pdf/project-timeline/sample --output project-timeline.pdf
```

---

### Product Catalog (A4 Landscape)
Wide-format product catalog showcasing multiple categories and products - demonstrates A4 landscape orientation.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/product-catalog/sample` | Generate sample catalog |
| POST | `/api/product-catalog` | Generate custom catalog |
| GET | `/api/product-catalog/sample/json` | Get sample data as JSON |
| POST | `/api/product-catalog/validate` | Validate catalog model |

**Key Features:**
- A4 Landscape format for wider content
- Multiple product categories
- Discount pricing with strikethrough
- Color-coded availability status
- Terms and conditions on separate page

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/product-catalog/sample --output product-catalog.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/product-catalog \
  -H "Content-Type: application/json" \
  -d @catalog-data.json \
  --output custom-catalog.pdf
```

---

### Employee Report (A4 Portrait)
Professional employee directory and performance report - demonstrates A4 portrait layout with structured data.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/employee-report/sample` | Generate sample report |
| POST | `/api/employee-report` | Generate custom report |
| GET | `/api/employee-report/sample/json` | Get sample data as JSON |
| POST | `/api/employee-report/validate` | Validate report model |

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/employee-report/sample --output employee-report.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/employee-report \
  -H "Content-Type: application/json" \
  -d @employee-report-data.json \
  --output custom-report.pdf
```

---

### Employee Payslip
GCC-compliant employee payslip with QR code verification and optional password protection.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/employee-payslip/sample` | Generate sample payslip |
| GET | `/api/employee-payslip/sample/password-protected` | Generate password-protected payslip |
| POST | `/api/employee-payslip` | Generate custom payslip |
| GET | `/api/employee-payslip/sample/json` | Get sample data as JSON |
| POST | `/api/employee-payslip/validate` | Validate payslip model |

#### Key Features

**QR Code Integration:**
- QR code displayed in the **top left** of the payslip header
- Contains encoded payslip data for verification:
  - Payslip number
  - Employee ID
  - Employee name
  - Net pay amount
  - Pay date
- Can be scanned to verify authenticity

**Password Protection:**
- Optional 128-bit PDF encryption
- Configurable permissions:
  - Printing: ✅ Allowed
  - Content extraction: ❌ Disabled
  - Annotations: ❌ Disabled
- Default password: `secure123`

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/employee-payslip/sample --output payslip.pdf

# Generate password-protected
curl http://localhost:5100/api/employee-payslip/sample/password-protected --output protected-payslip.pdf

# Generate with custom data
curl -X POST http://localhost:5100/api/employee-payslip \
  -H "Content-Type: application/json" \
  -d @payslip-data.json \
  --output custom-payslip.pdf
```

---

### Generic Report
Flexible generic report template supporting custom columns, RTL text direction, and dynamic data.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/generic-report/sample` | Generate sample report |
| GET | `/api/generic-report/sample/arabic/json` | Get sample Arabic report data |
| POST | `/api/generic-report` | Generate custom report |
| GET | `/api/generic-report/sample/json` | Get sample data as JSON |
| POST | `/api/generic-report/validate` | Validate report model |

**Key Features:**
- A4 Portrait format
- Summary statistics cards
- Performance ratings with color coding
- Attendance tracking
- Signature sections

**Example:**
```bash
# Generate sample
curl http://localhost:5100/api/generic-report/sample --output generic-report.pdf

# Get Arabic sample data
curl http://localhost:5100/api/generic-report/sample/arabic/json

# Generate with custom data
curl -X POST http://localhost:5100/api/generic-report \
  -H "Content-Type: application/json" \
  -d @generic-report-data.json \
  --output custom-report.pdf
```

---

### Employee Merged Reports
Comprehensive employee reporting combining payslip functionality with detailed employee analytics.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/EmployeeReport/merged` | Generate comprehensive merged report |
| GET | `/api/EmployeeReport/listing` | Generate employee listing report |
| GET | `/api/EmployeeReport/citizenship` | Generate citizenship analysis report |
| GET | `/api/EmployeeReport/department` | Generate department analysis report |
| GET | `/api/EmployeeReport/payslip` | Generate traditional employee payslip |
| GET | `/api/EmployeeReport/report` | Generate traditional employee report |
| GET | `/api/EmployeeReport/types` | Get available report types |
| GET | `/api/EmployeeReport/summary` | Get employee summary statistics |

#### Report Types

**1. Merged Report**
Comprehensive report combining payslip data with complete employee analytics.

**Includes:**
- Individual employee payslip with QR code
- Complete employee listing
- Citizenship-wise analysis
- Department-wise analysis
- Summary statistics

**2. Employee Listing Report**
Complete listing of all employees with comprehensive details.

**Includes:**
- Employee ID, Name, Position, Department
- Citizenship information
- Join date and salary details
- Performance ratings and status
- Attendance information

**3. Citizenship Report**
Employee count and analysis by citizenship.

**Includes:**
- Citizenship-wise employee counts
- Percentage breakdowns
- Average salary by citizenship
- Department distribution
- Gender breakdowns

**4. Department Report**
Department-wise employee analysis.

**Includes:**
- Employee counts by department
- Active vs. total employees
- Salary expense analysis
- Attendance rates
- Department heads
- Citizenship and performance breakdowns

---

## Company Branding

All documents support company branding through images. To add your logos and watermarks:

### Step 1: Create Images Folder
```bash
# From the project root
mkdir Images
```

### Step 2: Add Your Image Files
Place these files in the `Images` folder:

| File | Description | Recommended Size |
|------|-------------|------------------|
| `company-logo.png` | Main header logo | 120x60px |
| `company-logo-footer.png` | Footer logo (optional) | 40x30px |
| `company-seal.png` | Official seal/stamp | 60-80px (square) |
| `watermark.png` | Background watermark | 400x400px, semi-transparent |

### Step 3: Restart the Application
If it's running, restart the application to pick up new images.

### Branding Features

| Feature | Description | Documents |
|---------|-------------|-----------|
| **Header Logo** | Top-right corner (or left for landscape) | All documents |
| **Footer Logo** | Small logo with company info | All documents |
| **Watermark** | Semi-transparent background (15% opacity) | All documents |
| **Company Seal** | Signature/approval sections | Tax Invoice, Receipt, Purchase Order, Payslip |

### Image Specifications

**Creating a Watermark:**
1. Use your company logo as base
2. Make it very light (10-20% opacity in your image editor)
3. Save as PNG with transparency
4. The system will apply additional 15% opacity

**Logo Best Practices:**
- Format: PNG with transparent background
- Resolution: 300 DPI for print quality
- Colors: Match your brand guidelines
- Aspect Ratio: Maintain logo proportions
- File Size: Keep under 500KB

**Seal/Stamp Design:**
- Circular design works best
- Include company name and registration number
- High contrast for visibility when printed
- Save with transparent background

### Testing Without Images

The system is designed to work without images:
- Missing logos show placeholder boxes
- Missing seals show text labels
- Missing watermarks are simply omitted
- All documents remain functional

This allows you to:
1. Test the application immediately
2. See placeholder positions before adding real images
3. Deploy without images and add them later

---

## Document Type Overview

| Document | Format | Orientation | Use Case |
|----------|--------|-------------|----------|
| **TAX Invoice** | A4 | Portrait | Professional invoices with VAT |
| **Receipt** | A5 | Portrait | Payment confirmations |
| **Purchase Order** | A4 | Portrait | Procurement documents |
| **Dynamic Column Report** | A4 | Portrait | Analytics & sales reports |
| **Attendance Report** | A4 | Portrait | Employee attendance tracking |
| **Assets Report** | A4 | Portrait | IT asset distribution & status |
| **Budget Analysis** | A4 | Portrait | Financial budget vs actual |
| **Project Timeline** | A4 | Portrait | Project milestone tracking |
| **Product Catalog** | A4 | **Landscape** | Product listings & catalogs |
| **Employee Report** | A4 | Portrait | HR reports & directories |
| **Employee Payslip** | A4 | Portrait | Payroll documents |
| **Income Statement** | A4 | Portrait | Financial performance reporting |
| **Financial Position** | A4 | Portrait | Balance sheet reporting |
| **Trial Balance** | A4 | Portrait | Account balance verification |
| **Comparison Report** | A4 | Portrait | Period-to-period analysis |
| **Budget Comparison** | A4 | Portrait | Budget vs actual analysis |
| **Enhanced Budget Comparison** | A4 | **Landscape** | 12-column monthly analysis |

---

## Project Structure

```
QuestPDF.WebApiSample/
├── Controllers/
│   ├── BasePdfController.cs                  # Base controller with helper methods
│   ├── TaxInvoiceController.cs               # TAX invoice API endpoints
│   ├── ReceiptController.cs                  # Receipt API endpoints
│   ├── PurchaseOrderController.cs            # Purchase order API endpoints
│   ├── EmployeePayslipController.cs          # Employee payslip API endpoints
│   ├── EmployeeReportController.cs           # Employee report API endpoints
│   ├── DynamicColumnReportController.cs      # Dynamic column report API endpoints
│   ├── ProductCatalogController.cs           # Product catalog API endpoints
│   ├── GenericReportController.cs            # Generic report API endpoints
│   ├── LedgerController.cs                   # Ledger reports API endpoints
│   └── HomeController.cs                     # Web UI controller
├── Documents/
│   ├── StandardTaxInvoiceDocument.cs         # TAX invoice template
│   ├── ReceiptDocument.cs                    # Receipt template (A5)
│   ├── PurchaseOrderDocument.cs              # Purchase order template
│   ├── DynamicColumnReportDocument.cs        # Dynamic column report (A4)
│   ├── ProductCatalogDocument.cs             # Product catalog (A4 Landscape)
│   ├── EmployeeReportDocument.cs             # Employee report (A4 Portrait)
│   ├── EmployeePayslipDocument.cs            # Employee payslip template
│   ├── GenericReportDocument.cs              # Generic report template
│   ├── EmployeeMergedDocument.cs             # Employee merged reports
│   ├── LedgerReportDocument.cs               # Base ledger report template
│   ├── IncomeStatementDocument.cs            # Income statement template
│   ├── FinancialPositionDocument.cs          # Financial position template
│   ├── TrialBalanceDocument.cs               # Trial balance template
│   ├── ComparisonReportDocument.cs           # 2-year comparison template
│   ├── BudgetComparisonDocument.cs           # Budget comparison template
│   └── EnhancedBudgetComparisonDocument.cs   # Enhanced 12-column budget template
├── Models/
│   ├── StandardTaxInvoiceModel.cs            # TAX invoice data model
│   ├── ReceiptModel.cs                       # Receipt data model
│   ├── PurchaseOrderModel.cs                 # Purchase order data model
│   ├── DynamicColumnReportModel.cs           # Dynamic report data model
│   ├── ProductCatalogModel.cs                # Product catalog data model
│   ├── EmployeeReportModel.cs                # Employee report data model
│   ├── EmployeePayslipModel.cs               # Employee payslip data model
│   ├── EmployeeDataModel.cs                  # Comprehensive employee data model
│   ├── GenericReportModel.cs                 # Generic report data model
│   └── LedgerReportModel.cs                  # Ledger report data models
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs        # Global exception handling
├── Images/
│   ├── company-logo.png                      # Main company logo
│   ├── company-logo-footer.png               # Footer logo
│   ├── company-seal.png                      # Company seal/stamp
│   └── watermark.png                         # Background watermark
├── Views/
│   ├── Home/                                 # Razor views for web UI
│   └── Shared/                               # Shared layout views
├── wwwroot/
│   ├── css/                                  # Stylesheets
│   ├── js/                                   # JavaScript files
│   └── favicon.ico                           # Website icon
├── SampleDataGenerator.cs                    # Sample data for all document types
├── ImageHelper.cs                            # Image loading helper
├── QRCodeHelper.cs                           # QR code generation utility
├── Program.cs                                # Application entry point
├── appsettings.json                          # Configuration
└── README.md                                 # This file
```

---

## Customization

### Creating New Document Templates

1. Create a new class implementing `IDocument`:
```csharp
public class MyCustomDocument : IDocument
{
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // Your custom layout here
        });
    }
    
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;
}
```

2. Add a new endpoint in a controller:
```csharp
[HttpGet("my-custom-pdf")]
public IActionResult GenerateCustomPdf()
{
    var document = new MyCustomDocument();
    var pdfBytes = document.GeneratePdf();
    return File(pdfBytes, "application/pdf", "custom.pdf");
}
```

### Modifying Existing Templates

Each document template in the `Documents/` folder can be customized:
- Layout and styling
- Colors and fonts
- Table structure and columns
- Header and footer content
- Page size and orientation

**Example - Changing to Landscape:**
```csharp
// In any Document class Compose method
page.Size(PageSizes.A4.Landscape());  // Instead of Portrait()
```

**Example - Custom Page Size:**
```csharp
page.Size(new PageSize(800, 600));  // Custom width x height in points
```

---

## API Response Formats

### Success Response (PDF)
```
HTTP 200
Content-Type: application/pdf
Content-Disposition: attachment; filename=document.pdf
```

### Success Response (JSON)
```json
{
  "success": true,
  "documentType": "TaxInvoice",
  "documentId": "TAX-2025-00789",
  "generatedAt": "2025-12-29T02:00:00Z",
  "downloadUrl": "/api/tax-invoice/TAX-2025-00789"
}
```

### Validation Response
```json
{
  "valid": true,
  "message": "Model is valid"
}
```

### Error Response
```json
{
  "error": "BadRequest",
  "message": "TaxInvoiceNumber is required",
  "timestamp": "2025-12-29T02:00:00Z",
  "path": "/api/tax-invoice"
}
```

---

## Health Check

The API includes a health check endpoint for monitoring:

```
GET /health
```

Response:
```json
{
  "status": "Healthy",
  "timestamp": "2025-12-29T02:00:00Z"
}
```

---

## Technologies Used

- **ASP.NET Core 10** - Web framework
- **QuestPDF** - PDF generation library
- **Swagger/OpenAPI** - API documentation
- **QRCoder** - QR code generation for payslips
- **HealthChecks** - API health monitoring

---

## Production Considerations

For production deployment, consider:

1. **License**: Update the QuestPDF license in `Program.cs`
   ```csharp
   QuestPDF.Settings.License = LicenseType.Professional; // or Enterprise
   ```

2. **Error Handling**: Global exception handling middleware is included for consistent error responses

3. **Performance**: Consider implementing caching for frequently generated documents using ResponseCaching middleware

4. **Security**: Add authentication and authorization using JWT or similar

5. **Rate Limiting**: Implement rate limiting to protect against abuse

6. **File Storage**: Consider streaming large PDFs or storing them in cloud storage

7. **Logging**: Enhanced logging is available through the BasePdfController helper methods

---

## Troubleshooting

### Common Issues

#### QR Code Not Showing?
- Check that QRCoder package is installed: `dotnet list package | findstr QRCoder`
- Should show: `QRCoder 1.7.0`

#### Password Protection Not Working?
- Make sure you're using the protected endpoint
- Default password is: `secure123`
- Custom password: set in JSON `"password": "yourpassword"`

#### Images Not Appearing?
1. Check file names match exactly (case-sensitive)
2. Verify `Images` folder is in the correct location
3. Ensure images are PNG format
4. Check file permissions
5. Restart the application after adding images

#### Build Errors?
```bash
dotnet restore Source/QuestPDF.WebApiSample
dotnet build Source/QuestPDF.WebApiSample
```

#### PDF Generation Fails?
- Check QuestPDF licensing
- Verify data model integrity
- Ensure all required fields are populated

#### Poor Image Quality?
1. Use higher resolution source images
2. Ensure images are at least 300 DPI
3. Avoid upscaling small images
4. Use vector formats when possible (convert to high-res PNG)

#### Watermark Too Dark/Light?
1. Adjust source image opacity in image editor
2. Modify the `.Opacity()` value in code
3. Use lighter/darker source colors

---

## GCC Region Compatibility

The reports are specifically designed for GCC region requirements:
- Bahraini Dinars (BHD) as the currency
- 3 decimal places for all amounts (e.g., 1,492.000)
- Proper date formatting (dd-MMM-yyyy)
- Arabic number formatting
- Compliance with regional accounting standards
- CPR number and work permit tracking
- Social insurance calculations

---

## Additional Resources

- [QuestPDF Documentation](https://www.questpdf.com/documentation/getting-started.html)
- [QuestPDF GitHub](https://github.com/QuestPDF/QuestPDF)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)

---

## License

This sample project follows the QuestPDF licensing terms. For production use, ensure you have an appropriate QuestPDF license.

---

**Version**: 2025.12  
**Last Updated**: December 2025  
**Compatible with**: QuestPDF WebApiSample v2025.12+
