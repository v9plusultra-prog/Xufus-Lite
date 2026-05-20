# Xufus-Lite

Production-oriented Windows bootable USB utility (original implementation) built with .NET 8 + WPF.

## Download
- Latest release: `https://github.com/<your-org-or-user>/Xufus-Lite/releases/latest`
- Detailed instructions: [docs/DOWNLOAD.md](docs/DOWNLOAD.md)

## Build (Windows)
1. Install .NET 8 SDK.
2. Run:
   - `dotnet restore XufusLite.sln`
   - `dotnet build XufusLite.sln -c Release`
   - `dotnet test XufusLite.Tests/XufusLite.Tests.csproj`

## Release packaging
- Local: `pwsh ./tools/publish-release.ps1`
- CI/CD: `.github/workflows/build-release.yml` (creates zip artifact and tagged release assets)
