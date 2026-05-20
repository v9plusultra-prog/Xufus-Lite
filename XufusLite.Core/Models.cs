namespace XufusLite.Core.Models;

public enum PartitionScheme { Gpt, Mbr }
public enum FileSystemType { Fat32, Ntfs, ExFat }
public enum BootMode { Uefi, LegacyBios, Dual }

public sealed record UsbDeviceInfo(
    string DeviceId,
    string DisplayName,
    long CapacityBytes,
    bool IsRemovable,
    bool IsSystemDisk,
    string? FileSystem,
    string? UsbGeneration,
    string HealthStatus);

public sealed record IsoMetadata(
    string Path,
    string OsName,
    string Architecture,
    string Version,
    BootMode BootMode,
    bool IsBootable,
    string Sha256);

public sealed record WritePlan(
    string DeviceId,
    string IsoPath,
    PartitionScheme PartitionScheme,
    FileSystemType FileSystem,
    bool QuickFormat,
    bool VerifyAfterWrite);
