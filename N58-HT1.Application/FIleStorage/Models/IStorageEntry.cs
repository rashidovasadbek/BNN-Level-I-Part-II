namespace N58_HT1.Application.FIleStorage.Models;

public interface IStorageEntry
{
    public string Name { get; set; }
    public string Path { get; set; }
    public StorageEntryType Type { get; set; }
}