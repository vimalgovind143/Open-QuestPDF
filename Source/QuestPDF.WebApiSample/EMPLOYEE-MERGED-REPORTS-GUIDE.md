# Employee Merged Reports Guide

## Overview

The Employee Merged Reports system provides comprehensive employee reporting capabilities that combine payslip functionality with detailed employee analytics. This unified system supports multiple report types including employee listings, citizenship analysis, and department-wise reporting.

## Features

### 🚀 Key Features

- **Unified Data Model**: Single comprehensive data structure for all employee-related information
- **Multiple Report Types**: Merged, Listing, Citizenship, and Department reports
- **GCC-Compliant**: Designed for Bahrain/GCC region with citizenship and work permit tracking
- **Comprehensive Analytics**: Department-wise and citizenship-wise breakdowns
- **Payslip Integration**: Individual payslip generation within merged reports
- **QR Code Support**: Authenticity verification for payslips
- **Professional Design**: Clean, corporate-ready PDF layouts

## Report Types

### 1. Merged Report (`/api/EmployeeMerged/merged`)

**Description**: Comprehensive report combining payslip data with complete employee analytics

**Includes**:
- Individual employee payslip with QR code
- Complete employee listing
- Citizenship-wise analysis
- Department-wise analysis
- Summary statistics

**Use Case**: Executive reporting and comprehensive HR dashboards

### 2. Employee Listing Report (`/api/EmployeeMerged/listing`)

**Description**: Complete listing of all employees with comprehensive details

**Includes**:
- Employee ID, Name, Position, Department
- Citizenship information
- Join date and salary details
- Performance ratings and status
- Attendance information

**Use Case**: HR master records and employee directories

### 3. Citizenship Report (`/api/EmployeeMerged/citizenship`)

**Description**: Employee count and analysis by citizenship

**Includes**:
- Citizenship-wise employee counts
- Percentage breakdowns
- Average salary by citizenship
- Department distribution
- Gender breakdowns

**Use Case**: Labor market analysis and diversity reporting

### 4. Department Report (`/api/EmployeeMerged/department`)

**Description**: Department-wise employee analysis

**Includes**:
- Employee counts by department
- Active vs. total employees
- Salary expense analysis
- Attendance rates
- Department heads
- Citizenship and performance breakdowns

**Use Case**: Departmental budgeting and resource planning

## API Endpoints

### Base URL: `/api/EmployeeReport`

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/merged` | GET | Generate comprehensive merged report |
| `/listing` | GET | Generate employee listing report |
| `/citizenship` | GET | Generate citizenship analysis report |
| `/department` | GET | Generate department analysis report |
| `/payslip` | GET | Generate traditional employee payslip |
| `/report` | GET | Generate traditional employee report |
| `/{reportType}` | GET | Generate report by type (merged, listing, citizenship, department, payslip, report) |
| `/types` | GET | Get available report types |
| `/summary` | GET | Get employee summary statistics |
| `/custom` | POST | Generate custom report (future enhancement) |

### JSON Data Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/merged/json` | GET | Get merged report data as JSON |
| `/listing/json` | GET | Get listing report data as JSON |
| `/citizenship/json` | GET | Get citizenship report data as JSON |
| `/department/json` | GET | Get department report data as JSON |
| `/payslip/json` | GET | Get payslip data as JSON |
| `/report/json` | GET | Get traditional report data as JSON |

## Data Model

### ComprehensiveEmployee

```json
{
  "employeeId": "EMP001",
  "fullName": "Ahmed Al-Khalifa",
  "position": "Senior System Administrator",
  "department": "Information Technology",
  "joinDate": "2020-03-15",
  "email": "ahmed.k@gulftech.bh",
  "phone": "+973 3312 4567",
  "citizenship": "Bahraini",
  "nationality": "Bahraini",
  "workPermitNumber": "",
  "cprNumber": "900101123",
  "dateOfBirth": "1990-01-01",
  "gender": "Male",
  "maritalStatus": "Married",
  "employmentType": "Full-time",
  "contractType": "Permanent",
  "monthlySalary": 1800.00,
  "basicSalary": 1200.00,
  "housingAllowance": 400.00,
  "transportAllowance": 200.00,
  "performanceRating": "Excellent",
  "status": "Active",
  "workingDays": 22,
  "leaveDays": 0,
  "absentDays": 0,
  "lateDays": 0,
  "attendancePercentage": 100.0,
  "socialInsurance": 108.00,
  "incomeTax": 0.00,
  "loanDeduction": 150.00,
  "advanceDeduction": 50.00,
  "bankName": "National Bank of Bahrain",
  "accountNumber": "0123456789",
  "iban": "BH67 NBOB 0000 1234 5678 90",
  "annualLeaveBalance": 15.0,
  "sickLeaveBalance": 10.0,
  "indemnityBalance": 122.0
}
```

### CitizenshipAnalysis

```json
{
  "citizenship": "Bahraini",
  "employeeCount": 12,
  "percentageOfTotal": 80.0,
  "totalSalaryExpense": 21600.00,
  "averageSalary": 1800.00,
  "departmentBreakdown": [
    {
      "department": "Information Technology",
      "count": 10,
      "percentage": 83.3
    }
  ],
  "genderBreakdown": [
    {
      "gender": "Male",
      "count": 8,
      "percentage": 66.7
    },
    {
      "gender": "Female",
      "count": 4,
      "percentage": 33.3
    }
  ],
  "averageYearsOfService": 3.5
}
```

### DepartmentAnalysis

```json
{
  "departmentName": "Information Technology",
  "employeeCount": 10,
  "activeEmployees": 10,
  "totalSalaryExpense": 18000.00,
  "averageSalary": 1800.00,
  "averageYearsOfService": 3.2,
  "citizenshipBreakdown": [
    {
      "citizenship": "Bahraini",
      "count": 8,
      "percentage": 80.0
    }
  ],
  "performanceBreakdown": [
    {
      "rating": "Excellent",
      "count": 6,
      "percentage": 60.0
    }
  ],
  "attendanceRate": 96.5,
  "departmentHead": "Ali Salman"
}
```

## Usage Examples

### Generate Merged Report

```bash
curl -X GET "https://localhost:7123/api/EmployeeMerged/merged" \
  -H "accept: application/pdf" \
  --output employee-merged-report.pdf
```

### Get Citizenship Report Data as JSON

```bash
curl -X GET "https://localhost:7123/api/EmployeeMerged/citizenship/json" \
  -H "accept: application/json"
```

### Generate Department Report

```bash
curl -X GET "https://localhost:7123/api/EmployeeMerged/department" \
  -H "accept: application/pdf" \
  --output employee-department-report.pdf
```

### Get Employee Summary

```bash
curl -X GET "https://localhost:7123/api/EmployeeMerged/summary" \
  -H "accept: application/json"
```

### Get Available Report Types

```bash
curl -X GET "https://localhost:7123/api/EmployeeMerged/types" \
  -H "accept: application/json"
```

## Sample Data

The system includes comprehensive sample data with:

- **15 Employees**: Mix of Bahraini and expatriate staff
- **4 Departments**: IT, Operations, HR, Finance
- **Multiple Citizenship Types**: Bahraini, American, Indian, British
- **Complete Salary Structures**: Basic salary, allowances, deductions
- **Performance Data**: Ratings from Good to Excellent
- **Attendance Records**: Working days, leaves, absences
- **Bank Details**: Multiple banks with IBAN formats
- **Leave Balances**: Annual, sick, and indemnity balances

## Report Features

### Visual Design

- **Professional Header**: Company logo, title, QR code (for payslips)
- **Color Coding**: Performance ratings, status indicators
- **Summary Cards**: Key metrics at a glance
- **Responsive Tables**: Optimized for A4 portrait layout
- **Professional Footer**: Company branding and confidentiality notices

### Data Analytics

- **Summary Statistics**: Employee counts, salary expenses, attendance rates
- **Trend Analysis**: Years of service, performance distributions
- **Comparative Analysis**: Citizenship and department breakdowns
- **Financial Metrics**: Total salary expenses, average salaries
- **Attendance Tracking**: Working days, leave patterns

### Security Features

- **QR Code Authentication**: For payslip verification
- **Confidentiality Notices**: Security reminders on all reports
- **Watermark Support**: Optional document protection
- **Professional Signatures**: Prepared and reviewed by sections

## Integration Guide

### Adding Custom Reports

1. **Extend EmployeeReportType enum** in `EmployeeDataModel.cs`
2. **Add report logic** in `EmployeeMergedDocument.cs`
3. **Update controller** with new endpoint
4. **Add sample data** in `SampleDataGenerator.cs`

### Customizing Data Model

1. **Modify ComprehensiveEmployee** class for additional fields
2. **Update analysis classes** for new breakdown types
3. **Extend SampleDataGenerator** with new data patterns
4. **Adjust document layout** for new fields

### Branding Customization

1. **Update company information** in sample data
2. **Replace logos** in `Images/` directory
3. **Modify colors** in document styles
4. **Adjust footer** with company-specific information

## Technical Specifications

### Dependencies

- QuestPDF.Core
- QuestPDF.Fluent
- QuestPDF.Infrastructure
- Microsoft.AspNetCore.Mvc
- System.Text.Json

### Performance

- **PDF Generation**: ~2-5 seconds per report
- **Memory Usage**: ~50-100MB per generation
- **File Size**: ~500KB-2MB per PDF
- **Supported Formats**: PDF only

### Browser Support

- Chrome 80+
- Firefox 75+
- Safari 13+
- Edge 80+

## Troubleshooting

### Common Issues

1. **PDF Generation Fails**
   - Check QuestPDF licensing
   - Verify data model integrity
   - Ensure all required fields are populated

2. **Missing Images**
   - Verify logo files exist in `Images/` directory
   - Check image file formats (PNG/SVG supported)
   - Ensure proper file permissions

3. **QR Code Issues**
   - Verify QR code helper implementation
   - Check data format for QR generation
   - Ensure proper error handling

4. **Performance Issues**
   - Limit employee count for large reports
   - Consider pagination for very large datasets
   - Optimize data queries for production use

### Debug Mode

Enable debug logging in `Program.cs`:

```csharp
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});
```

## Future Enhancements

### Planned Features

- **Chart Integration**: Visual charts for analytics
- **Custom Filters**: Dynamic report filtering
- **Export Options**: Excel, CSV exports
- **Scheduled Reports**: Automated report generation
- **Multi-language Support**: Arabic language support
- **Advanced Analytics**: Trend analysis and predictions

### Extension Points

- **Custom Report Builder**: UI for creating custom reports
- **Data Source Integration**: Database connectivity
- **Template System**: Customizable report templates
- **API Authentication**: Secure report access
- **Audit Trail**: Report generation tracking

## Support

For technical support and questions:

1. **Documentation**: Check this guide and code comments
2. **Sample Data**: Review `SampleDataGenerator.cs` for data structure examples
3. **API Testing**: Use `/types` endpoint to verify functionality
4. **Error Logs**: Check application logs for detailed error information

---

**Version**: 1.0.0  
**Last Updated**: October 2025  
**Compatible with**: QuestPDF WebApiSample v2025.10+