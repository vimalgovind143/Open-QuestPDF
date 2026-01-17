# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Test Commands

All commands should be run from the `Source/` directory:

```bash
# Build the entire solution
dotnet build

# Build in release configuration
dotnet build --configuration Release

# Run unit tests
dotnet test QuestPDF.UnitTests --configuration Release

# Run specific test projects
dotnet test QuestPDF.LayoutTests --configuration Release
dotnet test QuestPDF.VisualTests --configuration Release
dotnet test QuestPDF.DocumentationExamples --configuration Release
dotnet test QuestPDF.ReportSample --configuration Release
dotnet test QuestPDF.ConformanceTests --configuration Release

# Run all tests (Linux only for conformance tests due to external tools)
dotnet test --configuration Release

# Create NuGet package (strong-name signed)
dotnet build QuestPDF/QuestPDF.csproj --configuration Release --property BUILD_PACKAGE=true

# Run the Companion TestRunner (hot-reload preview)
dotnet run --project QuestPDF.Companion.TestRunner

# Run the Web API sample
dotnet run --project QuestPDF.WebApiSample
```

## Required SDK

- .NET SDK 10.0.0 (see `global.json`)
- Target frameworks: net10.0, net8.0

## Architecture Overview

### Project Structure

```
Source/
├── QuestPDF/                      # Main library project
├── QuestPDF.UnitTests/            # NUnit unit tests
├── QuestPDF.VisualTests/          # Image-based regression tests
├── QuestPDF.LayoutTests/          # Layout algorithm tests
├── QuestPDF.ConformanceTests/     # PDF/A, PDF/UA compliance tests (Linux only)
├── QuestPDF.Companion.TestRunner/ # Live preview companion app
├── QuestPDF.WebApiSample/         # ASP.NET Core sample
├── QuestPDF.ReportSample/         # Complex report generation example
├── QuestPDF.DocumentationExamples/ # Feature-by-feature examples
└── QuestPDF.ZUGFeRD/              # ZUGFeRD invoice format support
```

### Core Architecture Layers (QuestPDF/)

The main library follows a layered architecture:

- **Infrastructure/**: Base interfaces and types (`IElement`, `IDocument`, `IContainer`, `IStateful`)
- **Fluent/**: Extension methods providing the declarative fluent API (`MinimalApi.cs` contains the main `Document.Create` entry point)
- **Elements/**: Layout elements (`Column`, `Row`, `Table`, `Text`, `Image`, etc.) and the `Element` base class
- **Drawing/**: Document generation engine (`DocumentGenerator.cs`) and canvas implementations
- **Skia/**: SkiaSharp-based PDF rendering backend
- **Qpdf/**: PDF manipulation operations (merge, split, encrypt, etc.)

### Key Entry Points

- `Document.Create(Action<IDocumentContainer>)` in `Fluent/MinimalApi.cs` - main entry point for document creation
- `DocumentGenerator.GeneratePdf()` in `Drawing/DocumentGenerator.cs` - core rendering engine
- `Settings` class in root `Settings.cs` - global configuration (license, caching, debugging)

### Rendering Pipeline

1. **Composition**: Elements define structure via fluent API
2. **Configuration**: Text styles, caching, image settings, semantic tree injection
3. **Layout Pass**: Two-pass rendering with `PageContext` - measures and calculates positions
4. **Render Pass**: SkiaSharp renders to output format (PDF, XPS, images, SVG)

Key elements in the pipeline:
- `ContainerElement` - wrapper that hosts a child element
- `IElement` - marker interface for all document elements
- `IDocumentCanvas` - abstraction for different output formats
- `Element.VisitChildren()` - tree traversal for applying transformations

### Important Interfaces

- `IDocument`: Document contract with `GetMetadata()`, `GetSettings()`, `Compose()`
- `IContainer`: Container for content, target of fluent extension methods
- `IElement`: Base element interface (marker)
- `IStateful`: Elements with state that resets between pages (e.g., page numbers)
- `ISemanticAware`: Elements that interact with PDF/UA semantic tree

## Code Style

Per `.editorconfig`:
- **Brace style**: Allman (braces on new lines)
- **Indentation**: Spaces, 4 spaces
- **Prefer**: `var` over explicit types, expression-bodied properties
- **Language version**: C# 12

## License Configuration

Before running or testing, the license must be set in `Settings.License`:

```csharp
QuestPDF.Settings.License = LicenseType.Community; // or other appropriate license type
```

If not set, the library throws an exception directing users to the license page.

## Testing Notes

- Tests use **NUnit** framework (not xUnit)
- `ConformanceTests` requires external tools (veraPDF, mustang) and only runs on Linux
- `VisualTests` compares PDFs as images for regression testing
- `Companion.TestRunner` provides hot-reload preview for interactive development

## Common Patterns

### Adding a New Element

1. Create element class in `Elements/` inheriting from `Element`
2. Add fluent extension method in `Fluent/` namespace
3. Implement `Measure()` and `Draw()` if custom layout needed

### Proxy Pattern

The codebase uses proxies extensively for:
- Caching (`SnapshotCacheRecorderProxy`)
- Debugging (`LayoutProxy`, `OverflowDebuggingProxy`)
- Layout measurement

Proxies are applied via `Element.CreateProxy()` and removed via `RemoveExistingProxiesOfType<T>()`.

### Document Settings

Configure via `DocumentSettings`:
- `ImageRasterDpi`, `ImageCompressionQuality`
- `PDFA_Conformance`, `PDFUA_Conformance`
- `ContentDirection` (for RTL support)
