namespace N58_HT1.Application.FIleStorage.Models;

public class StorageDirectory : IStorageEntry
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public long ItemsCount { get; set; }
    public StorageEntryType Type { get; set; }
}