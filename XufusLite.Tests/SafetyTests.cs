using XufusLite.Core.Models;
using XufusLite.Infrastructure;

namespace XufusLite.Tests;

public class SafetyTests
{
    [Fact]
    public async Task Validation_Passes_For_Removable_NonSystem_Disk()
    {
        var logger = new InMemoryAuditLogger();
        var validator = new ValidationService(new MockUsbDeviceService(), logger);
        var tmp = Path.GetTempFileName();
        await File.WriteAllTextAsync(tmp, "iso");

        var plan = new WritePlan("USB\\VID_0001&PID_0001", tmp, PartitionScheme.Gpt, FileSystemType.Ntfs, true, true);
        await validator.ValidateWriteRequestAsync(plan, CancellationToken.None);
    }
}
