# Xufus Lite Architecture

## 1) Complete architecture
- **Presentation (WPF/MVVM)**: Views and ViewModels for device selection, ISO insights, operation pipeline, live logs.
- **Application orchestration**: `BootUsbOrchestrator` coordinates validation → write → verify.
- **Core domain**: immutable models (`UsbDeviceInfo`, `IsoMetadata`, `WritePlan`) and service abstractions.
- **Infrastructure**: Win32 interop wrappers (`CreateFile`/`DeviceIoControl` extension point), ISO hashing, USB discovery providers, structured logger.
- **Safety pipeline**: validation policies deny system/internal drives and enforce explicit target selection.

## 2) Professional folder structure
`/Core /Services /Models /ViewModels /Views /Utilities /Logging /Boot /ISO /USB /Disk /Validation /Infrastructure /Resources /Assets /Themes /Animations /Localization /Tests`

## 3) Settings structure
- JSON settings in `%ProgramData%/XufusLite/settings.json`
- Fields: theme, language, telemetryEnabled, portableMode, historyRetentionDays.

## 4) Core services
- `IUsbDeviceService`, `IIsoService`, `IWriterService`, `IVerificationService`, `IValidationService`, `IAuditLogger`.

## 5-13) Implementation status
- UI shell in `MainWindow.xaml` with sidebar/cards/log panel.
- ISO inspection with SHA-256.
- Simulated writer + verifier with cancellable progress.
- Validation guardrails for removable and non-system disk only.
- Win32 API bootstrapping for raw disk engine.

## 14) Build instructions
1. Install .NET 8 SDK + WindowsDesktop workload on Windows 11.
2. `dotnet restore`
3. `dotnet build XufusLite.sln -c Release`
4. `dotnet test XufusLite.Tests/XufusLite.Tests.csproj`

## 15) Deployment
- Publish self-contained x64, sign binaries, then package via MSIX/Inno Setup.

## 16) Optimization
- Use pooled buffers, async file pipelines, sector-aligned writes, overlapped I/O.

## 17) Security
- Require admin elevation manifest.
- Two-step destructive confirmation and target fingerprint display.
- Crash-safe state journal for resume/rollback logic.

## 18) Future improvements
- Full DeviceIoControl partition engine, bad-block scan, secure erase, benchmark, plugin SDK, updater.
