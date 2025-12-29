using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure QuestPDF license with a safe default to avoid runtime failures
var configuredLicense = builder.Configuration["QuestPDF:License"] ?? "Community";
var licenseType = Enum.TryParse<LicenseType>(configuredLicense, true, out var parsedLicense)
    ? parsedLicense
    : LicenseType.Community;

QuestPDF.Settings.License = licenseType;

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add global exception handling middleware
app.UseQuestPDFExceptionHandling();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// Map health check endpoint
app.MapHealthChecks("/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
