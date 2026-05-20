param(
    [string]$Runtime = "win-x64",
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"

Write-Host "Restoring solution..."
dotnet restore XufusLite.sln

Write-Host "Building solution..."
dotnet build XufusLite.sln -c $Configuration --no-restore

Write-Host "Running tests..."
dotnet test XufusLite.Tests/XufusLite.Tests.csproj -c $Configuration --no-build

$output = Join-Path $PSScriptRoot "..\artifacts\publish\$Runtime"
New-Item -ItemType Directory -Force -Path $output | Out-Null

Write-Host "Publishing app..."
dotnet publish XufusLite.App/XufusLite.App.csproj -c $Configuration -r $Runtime --self-contained true -o $output

$zipPath = Join-Path $PSScriptRoot "..\artifacts\XufusLite-$Runtime.zip"
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }
Compress-Archive -Path (Join-Path $output "*") -DestinationPath $zipPath

Write-Host "Package created: $zipPath"
