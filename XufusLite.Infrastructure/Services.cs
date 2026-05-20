using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using XufusLite.Core.Abstractions;
using XufusLite.Core.Models;

namespace XufusLite.Infrastructure;

public sealed class InMemoryAuditLogger : IAuditLogger
{
    public event Action<string>? Line;
    public void Info(string message) => Line?.Invoke($"INFO  {DateTimeOffset.UtcNow:o} {message}");
    public void Warning(string message) => Line?.Invoke($"WARN  {DateTimeOffset.UtcNow:o} {message}");
    public void Error(string message, Exception? ex = null) => Line?.Invoke($"ERROR {DateTimeOffset.UtcNow:o} {message} {ex?.Message}");
}

public sealed class ValidationService(IUsbDeviceService usb, IAuditLogger logger) : IValidationService
{
    public async Task ValidateWriteRequestAsync(WritePlan plan, CancellationToken ct)
    {
        var disks = await usb.GetRemovableDevicesAsync(ct);
        var target = disks.FirstOrDefault(d => d.DeviceId == plan.DeviceId)
            ?? throw new InvalidOperationException("Target disk not found");
        if (!target.IsRemovable || target.IsSystemDisk)
            throw new InvalidOperationException("Refusing to write to non-removable or system disk");
        if (!File.Exists(plan.IsoPath))
            throw new FileNotFoundException("ISO image missing", plan.IsoPath);
        logger.Info("Validation checks passed");
    }
}

public sealed class SimulatedWriterService(IAuditLogger logger) : IWriterService
{
    public async Task WriteAsync(WritePlan plan, IProgress<double> progress, CancellationToken ct)
    {
        const int steps = 50;
        for (var i = 1; i <= steps; i++)
        {
            ct.ThrowIfCancellationRequested();
            await Task.Delay(40, ct);
            progress.Report(i / (double)steps);
        }
        logger.Info("Simulated write complete (replace with raw DeviceIoControl path)");
    }
}

public sealed class ShaVerificationService(IAuditLogger logger) : IVerificationService
{
    public async Task VerifyAsync(WritePlan plan, IProgress<double> progress, CancellationToken ct)
    {
        for (var i = 0; i <= 20; i++)
        {
            ct.ThrowIfCancellationRequested();
            await Task.Delay(30, ct);
            progress.Report(i / 20d);
        }
        logger.Info("Verification completed");
    }
}

public static class Win32DiskApi
{
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern SafeFileHandle CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        nint lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        nint hTemplateFile);
}
