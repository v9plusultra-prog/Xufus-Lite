$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $PSScriptRoot
$publishDir = Join-Path $root '.artifacts/publish'
$zipPath = Join-Path $root '.artifacts/XufusLite-win-x64.zip'

Write-Host 'Cleaning old artifacts...'
if (Test-Path $publishDir) { Remove-Item $publishDir -Recurse -Force }
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }

Write-Host 'Publishing XufusLite.App (win-x64, self-contained, single-file)...'
dotnet publish (Join-Path $root 'XufusLite.App/XufusLite.App.csproj') `
  -c Release `
  -r win-x64 `
  --self-contained true `
  -p:PublishSingleFile=true `
  -o $publishDir

Write-Host 'Creating downloadable zip package...'
$zipDir = Split-Path -Parent $zipPath
if (!(Test-Path $zipDir)) { New-Item -ItemType Directory -Path $zipDir | Out-Null }
Compress-Archive -Path (Join-Path $publishDir '*') -DestinationPath $zipPath -Force

Write-Host "Done. Downloadable package created at: $zipPath"
