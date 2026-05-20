using System.Security.Cryptography;
using XufusLite.Core.Abstractions;
using XufusLite.Core.Models;

namespace XufusLite.Infrastructure;

public sealed class MockUsbDeviceService : IUsbDeviceService
{
    public Task<IReadOnlyList<UsbDeviceInfo>> GetRemovableDevicesAsync(CancellationToken ct)
        => Task.FromResult<IReadOnlyList<UsbDeviceInfo>>(
        [
            new("USB\\VID_0001&PID_0001", "SanDisk Ultra", 64L * 1024 * 1024 * 1024, true, false, "exFAT", "USB 3.2", "Healthy")
        ]);
}

public sealed class IsoInspectionService : IIsoService
{
    public async Task<IsoMetadata> InspectAsync(string isoPath, CancellationToken ct)
    {
        await using var stream = File.OpenRead(isoPath);
        var hash = await SHA256.HashDataAsync(stream, ct);
        var sha = Convert.ToHexString(hash);
        return new IsoMetadata(isoPath, "Unknown OS", "x64", "N/A", BootMode.Dual, true, sha);
    }
}
