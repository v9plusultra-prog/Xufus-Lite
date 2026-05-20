using XufusLite.Core.Models;

namespace XufusLite.Core.Abstractions;

public interface IUsbDeviceService
{
    Task<IReadOnlyList<UsbDeviceInfo>> GetRemovableDevicesAsync(CancellationToken ct);
}

public interface IIsoService
{
    Task<IsoMetadata> InspectAsync(string isoPath, CancellationToken ct);
}

public interface IValidationService
{
    Task ValidateWriteRequestAsync(WritePlan plan, CancellationToken ct);
}

public interface IWriterService
{
    Task WriteAsync(WritePlan plan, IProgress<double> progress, CancellationToken ct);
}

public interface IVerificationService
{
    Task VerifyAsync(WritePlan plan, IProgress<double> progress, CancellationToken ct);
}

public interface IAuditLogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message, Exception? ex = null);
}
