# Ledger Reports Guide

This guide explains how to use the new ledger report functionality in the QuestPDF Web API Sample.

## Available Reports

1. **Income Statement** - Shows revenue, expenses, and net income for a period
2. **Financial Position** - Shows assets, liabilities, and equity at a point in time (Balance Sheet)
3. **Trial Balance** - Lists all ledger accounts with their debit and credit balances
4. **2-Year Comparison Report** - Compares financial performance across two periods
5. **Budget Comparison Report** - Compares actual results against budgeted amounts
6. **Enhanced 12-Column Budget Comparison Report** ⭐ **NEW** - Comprehensive monthly budget analysis with account grouping in landscape mode

## Features Implemented

All ledger reports include the following features:

- **Header with Logo**: Company logo at the top of each page
- **Date Range Selection**: Clear indication of the reporting period
- **Footer with Paging**: Page numbers and total page count
- **Printing Time**: Timestamp of when the report was generated
- **Watermark Support**: Optional watermark on each page
- **GCC Region Compatibility**: Proper formatting for Gulf Cooperation Council countries (Bahrain, UAE, etc.)
- **Multi-page Support**: Automatic handling of content that spans multiple pages
- **Full Chart Information**: Detailed account information with proper categorization

## API Endpoints

### Income Statement
- `GET /api/ledger/income-statement/sample` - Generate PDF report
- `GET /api/ledger/income-statement/sample/json` - Get report data as JSON

### Financial Position (Balance Sheet)
- `GET /api/ledger/financial-position/sample` - Generate PDF report
- `GET /api/ledger/financial-position/sample/json` - Get report data as JSON

### Trial Balance
- `GET /api/ledger/trial-balance/sample` - Generate PDF report
- `GET /api/ledger/trial-balance/sample/json` - Get report data as JSON

### 2-Year Comparison Report
- `GET /api/ledger/comparison/sample` - Generate PDF report
- `GET /api/ledger/comparison/sample/json` - Get report data as JSON

### Budget Comparison Report
- `GET /api/ledger/budget-comparison/sample` - Generate PDF report
- `GET /api/ledger/budget-comparison/sample/json` - Get report data as JSON

### Enhanced 12-Column Budget Comparison Report ⭐ **NEW**
- `GET /api/ledger/enhanced-budget-comparison/sample` - Generate PDF report
- `GET /api/ledger/enhanced-budget-comparison/sample/json` - Get report data as JSON

### All Reports
- `GET /api/ledger/all-reports/sample` - Generate all reports (simplified implementation)

## Sample Data

All reports come with comprehensive sample data that demonstrates:
- Proper GCC region formatting (Bahraini Dinars - BHD)
- Multi-level account hierarchies
- Variance analysis
- Percentage calculations
- Professional formatting and styling
- **Enhanced Features**: 12-column monthly breakdown, account chart grouping, variance color coding, landscape orientation

## Customization

To customize the reports for your specific needs:

1. **Modify Sample Data**: Update the `SampleDataGenerator.cs` file to include your actual data
2. **Adjust Styling**: Modify the document templates in the `Documents` folder
3. **Add Watermarks**: Replace the watermark.png file in the Images folder
4. **Update Logo**: Replace the company-logo.png file in the Images folder

## GCC Region Compatibility

The reports are specifically designed for GCC region requirements:
- Bahraini Dinars (BHD) as the currency
- Proper date formatting (dd-MMM-yyyy)
- Arabic number formatting
- Compliance with regional accounting standards

## Watermark Support

To add a watermark to your reports:
1. Create a semi-transparent PNG image
2. Save it as `watermark.png` in the `Images` folder
3. The watermark will automatically appear on all generated reports

## Testing

To test the reports:
1. Run the Web API application
2. Navigate to `https://localhost:{port}/swagger` to view the API documentation
3. Use the Ledger endpoints to generate reports
4. Check the `QuestPDF.WebApiSample` folder for generated PDF files

## Report Structure

Each report follows a consistent structure:
1. **Header**: Company logo, report title, date range
2. **Content**: Main report data in tabular format
3. **Summary**: Key metrics and totals
4. **Footer**: Page numbers, printing time, notes

## Error Handling

The reports include proper error handling for:
- Missing images (logo, watermark)
- Data validation
- PDF generation issues

## Enhanced 12-Column Budget Comparison Report ⭐ **NEW**

The enhanced budget comparison report provides comprehensive monthly analysis with advanced features:

### Key Features
- **12 Monthly Columns**: Full year breakdown with monthly budget vs actual data
- **Account Chart Grouping**: Hierarchical organization by account categories (Operating Expenses, COGS, Revenue, Capital Expenditures)
- **Landscape Orientation**: Optimized layout for wide table display
- **Variance Color Coding**: Visual indicators for performance
  - 🟢 Green: Within 5% variance (On Target)
  - 🟡 Yellow: 5-10% variance (Slightly Off Target)
  - 🔴 Red: >10% variance (Significant Variance)
- **Year-to-Date Calculations**: Cumulative totals and variances
- **Account Summaries**: Detailed variance analysis per account with trend indicators
- **Group Summaries**: Subtotal calculations for each account group
- **Executive Summary**: High-level performance overview with key metrics
- **Variance Alerts**: Automatic highlighting of accounts with >10% variance

### Account Groups Included
- **Operating Expenses (5000)**: Salaries, Rent & Utilities, Marketing, Office Supplies, Professional Services
- **Cost of Goods Sold (4000)**: Raw Materials, Direct Labor, Manufacturing Overhead
- **Revenue (3000)**: Product Sales, Service Revenue, Licensing Revenue
- **Capital Expenditures (6000)**: Equipment Purchases, Software Development, Facility Improvements

### Usage Example
```bash
# Generate Enhanced Budget Comparison PDF
curl -X GET "https://localhost:5001/api/ledger/enhanced-budget-comparison/sample" -o "enhanced-budget-comparison.pdf"

# Get Enhanced Budget Comparison JSON data
curl -X GET "https://localhost:5001/api/ledger/enhanced-budget-comparison/sample/json"
```

### Data Structure
The enhanced report includes additional properties:
- `MonthlyColumns`: List of 12 month names
- `AccountGroups`: Hierarchical account group structure with accounts and monthly data
- `TotalBudgetAmount`: Overall budget total
- `TotalActualAmount`: Overall actual total
- `TotalVarianceAmount`: Overall variance amount
- `TotalVariancePercentage`: Overall variance percentage
- `ShowVarianceColors`: Enable color coding (true/false)
- `ShowAccountCodes`: Display account codes (true/false)
- `ShowPercentages`: Show percentage calculations (true/false)

## Recent Updates

### Version 2.0 - Enhanced Budget Comparison Report
- ✅ Added comprehensive 12-column budget comparison report
- ✅ Implemented landscape orientation for better readability
- ✅ Added account chart grouping functionality
- ✅ Enhanced variance analysis with color coding
- ✅ Improved styling and formatting for professional appearance
- ✅ Added comprehensive test coverage and validation
- ✅ Updated documentation and examples