# Employee Payslip Feature

## Overview
The Employee Payslip feature generates professional, GCC-compliant payslip documents with QR code verification and optional password protection.

## Features

### 1. QR Code Integration
- QR code displayed in the **top left** of the payslip header
- Contains encoded payslip data for verification:
  - Payslip number
  - Employee ID
  - Employee name
  - Net pay amount
  - Pay date
- Can be scanned to verify authenticity

### 2. Password Protection
- Optional 128-bit PDF encryption
- Configurable permissions:
  - Printing: Allowed
  - Content extraction: Disabled
  - Annotations: Disabled
- User and owner passwords set to the same value

### 3. Professional Layout
- Company branding with logo support
- Employee information section
- Earnings breakdown table
- Deductions breakdown table
- Summary section with gross pay, deductions, and net pay
- Bank details for salary transfer
- Company seal and signatures
- Watermark support

## API Endpoints

### 1. Generate Sample Payslip
```
GET /api/pdf/employee-payslip/sample
```
Generates a sample payslip without password protection.

### 2. Generate Protected Sample Payslip
```
GET /api/pdf/employee-payslip/sample/protected
```
Generates a sample payslip with password protection.
- Password: `secure123`

### 3. Generate Custom Payslip
```
POST /api/pdf/employee-payslip
Content-Type: application/json
```

Request body example:
```json
{
  "payslipNumber": "PAY-2025-10-001",
  "payPeriod": "October 2025",
  "payDate": "2025-10-31T00:00:00",
  "workingDays": 22,
  "totalDays": 31,
  "company": {
    "companyName": "Gulf Technology Solutions W.L.L.",
    "address": "Building 2345, Road 2417, Block 324",
    "city": "Manama",
    "country": "Kingdom of Bahrain",
    "phone": "+973 1729 8888",
    "email": "hr@gulftech.com.bh"
  },
  "employee": {
    "employeeId": "EMP001",
    "fullName": "Ahmed Al-Khalifa",
    "position": "Senior System Administrator",
    "department": "Information Technology",
    "joinDate": "2020-03-15T00:00:00",
    "nationality": "Bahraini"
  },
  "earnings": [
    {
      "description": "Basic Salary",
      "amount": 1200.000,
      "isTaxable": true
    },
    {
      "description": "Housing Allowance",
      "amount": 400.000,
      "isTaxable": true
    }
  ],
  "deductions": [
    {
      "description": "Social Insurance (6%)",
      "amount": 108.000
    }
  ],
  "bankDetails": {
    "bankName": "National Bank of Bahrain B.S.C.",
    "accountName": "Ahmed Al-Khalifa",
    "accountNumber": "0123456789",
    "iban": "BH67 NBOB 0000 1234 5678 90"
  },
  "summary": {
    "totalEarnings": 1800.000,
    "totalDeductions": 308.000,
    "grossPay": 1800.000,
    "netPay": 1492.000
  },
  "preparedBy": "Layla Ahmed - HR Manager",
  "password": "optional-password-here"
}
```

### 4. Get Sample JSON
```
GET /api/pdf/employee-payslip/sample/json
```
Returns the sample payslip data as JSON for reference.

## Implementation Details

### QR Code Generation
- Uses QRCoder library (v1.6.0)
- QR code contains structured data: `PAYSLIP|{number}|{empId}|{name}|{netPay}|{date}`
- Displayed as 75x75 pixels in the header

### Password Protection
- Implemented using QuestPDF's DocumentOperation API
- Uses temporary files for encryption process
- Automatically cleans up temporary files after processing

### Files
- **Model**: `Models/EmployeePayslipModel.cs`
- **Document**: `Documents/EmployeePayslipDocument.cs`
- **QR Helper**: `QRCodeHelper.cs`
- **Sample Data**: `SampleDataGenerator.cs` (GetSampleEmployeePayslip methods)
- **Controller**: `Controllers/PdfController.cs` (Employee Payslip section)

## Testing

1. Start the API:
   ```bash
   dotnet run --project Source/QuestPDF.WebApiSample
   ```

2. Access Swagger UI:
   ```
   https://localhost:5001/swagger
   ```

3. Test endpoints:
   - Try the sample payslip endpoint
   - Try the protected payslip endpoint (password: secure123)
   - Create a custom payslip with your own data

## Currency Format
All amounts are formatted in Bahraini Dinars (BHD) with 3 decimal places (e.g., 1,492.000).

## Compliance
The payslip format follows GCC (Gulf Cooperation Council) standards and includes:
- Company registration details
- Employee identification
- Detailed earnings and deductions
- Social insurance contributions
- Bank transfer information
- Bilingual support capability (Arabic/English)
