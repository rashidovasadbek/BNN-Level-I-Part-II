namespace N59_HT1.Application.FileStorage.Models;

public class StorageDrive : IStorageEnty
{
    public string Name { get; set; } = string.Empty;
    
    public string Path { get; set; } = string.Empty;
    
    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public long TotalSpace { get; set; }

    public long FreeSpace { get; set; }

    public long UnavailableSpace { get; set; }

    public long UsedSpace { get; set; }

    public StorageEntryType EntryType { get; set; } = StorageEntryType.Drive;
}