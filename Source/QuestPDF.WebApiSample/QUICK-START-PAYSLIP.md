# Quick Start Guide - Employee Payslip

## 🚀 Quick Test (3 Steps)

### Step 1: Build & Run
```bash
cd Source/QuestPDF.WebApiSample
dotnet run
```

### Step 2: Open Browser
Navigate to: `https://localhost:5001/swagger`

### Step 3: Test Endpoints

#### Option A: Simple Payslip (No Password)
1. Find "Employee Payslip" section in Swagger
2. Click on `GET /api/pdf/employee-payslip/sample`
3. Click "Try it out" → "Execute"
4. Click "Download file" to get the PDF
5. **Verify**: Open PDF and check QR code in top left corner

#### Option B: Protected Payslip (With Password)
1. Click on `GET /api/pdf/employee-payslip/sample/protected`
2. Click "Try it out" → "Execute"
3. Download the PDF
4. **Verify**: Open PDF, enter password: `secure123`
5. **Verify**: Try to copy text (should be disabled)
6. **Verify**: Try to print (should work)

## 📋 Key Features Checklist

- ✅ QR Code in top left corner
- ✅ Password protection (128-bit encryption)
- ✅ Professional GCC-compliant layout
- ✅ Earnings and deductions breakdown
- ✅ Bank details section
- ✅ Company branding support
- ✅ Watermark support

## 🔍 What to Look For

### QR Code (Top Left)
- Should be visible in the header
- Size: 75x75 pixels
- Text below: "Scan to Verify"
- Scan it to see: `PAYSLIP|PAY-2025-10-001|EMP001|Ahmed Al-Khalifa|1492.000|2025-10-31`

### Password Protection
- Password: `secure123`
- Printing: ✅ Allowed
- Copy text: ❌ Disabled
- Annotations: ❌ Disabled

### Document Sections
1. Header with QR code and company logo
2. Payslip details (number, period, dates)
3. Employee information
4. Earnings table
5. Deductions table
6. Summary (highlighted net pay)
7. Bank details
8. Signatures and seal
9. Footer with confidentiality notice

## 🛠️ Custom Payslip

Use the POST endpoint with this minimal JSON:

```json
{
  "payslipNumber": "PAY-2025-11-001",
  "payPeriod": "November 2025",
  "payDate": "2025-11-30",
  "workingDays": 22,
  "totalDays": 30,
  "company": {
    "companyName": "Your Company Name",
    "city": "Manama",
    "country": "Kingdom of Bahrain"
  },
  "employee": {
    "employeeId": "EMP999",
    "fullName": "John Doe",
    "position": "Developer",
    "department": "IT"
  },
  "earnings": [
    {"description": "Basic Salary", "amount": 1000}
  ],
  "deductions": [
    {"description": "Social Insurance", "amount": 60}
  ],
  "bankDetails": {
    "bankName": "Test Bank",
    "accountName": "John Doe",
    "accountNumber": "123456",
    "iban": "BH00 0000 0000 0000 0000 00"
  },
  "summary": {
    "totalEarnings": 1000,
    "totalDeductions": 60,
    "grossPay": 1000,
    "netPay": 940
  },
  "preparedBy": "HR Manager",
  "password": "mypassword123"
}
```

## 📞 Troubleshooting

### QR Code Not Showing?
- Check that QRCoder package is installed: `dotnet list package | findstr QRCoder`
- Should show: `QRCoder 1.6.0`

### Password Not Working?
- Make sure you're using the protected endpoint
- Default password is: `secure123`
- Custom password: set in JSON `"password": "yourpassword"`

### Build Errors?
```bash
dotnet restore Source/QuestPDF.WebApiSample
dotnet build Source/QuestPDF.WebApiSample
```

## 📚 More Information

- Full documentation: `PAYSLIP-FEATURE.md`
- Implementation details: `IMPLEMENTATION-SUMMARY.md`
- API reference: Swagger UI at `/swagger`

## ✨ Success Indicators

You've successfully implemented the feature if:
1. ✅ PDF generates without errors
2. ✅ QR code appears in top left of header
3. ✅ QR code can be scanned and contains payslip data
4. ✅ Protected PDF requires password to open
5. ✅ Text copying is disabled in protected PDF
6. ✅ Printing works in protected PDF
7. ✅ All sections render correctly (earnings, deductions, summary, etc.)

---

**Need Help?** Check the implementation files:
- `Documents/EmployeePayslipDocument.cs` - Main document layout
- `QRCodeHelper.cs` - QR code generation
- `Controllers/PdfController.cs` - API endpoints
