# Xufus-Lite

Xufus-Lite is an original, safety-first Windows bootable USB utility foundation built with **.NET 8 + WPF**.

## Download / Build Package

This repository does not include hosted binaries yet, but you can generate a downloadable build artifact on Windows in one command:

```powershell
powershell -ExecutionPolicy Bypass -File .\scripts\create-release.ps1
```

After completion, you'll get a zip package at:

```text
.artifacts\XufusLite-win-x64.zip
```

## Manual Build

```powershell
dotnet restore
 dotnet publish .\XufusLite.App\XufusLite.App.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o .\artifacts\publish
```

## Next Step for Public Download Link

To provide a public download URL, publish `.artifacts\XufusLite-win-x64.zip` to one of:
- GitHub Releases
- Azure Blob Storage
- S3 + CloudFront

Then share the generated HTTPS link.
