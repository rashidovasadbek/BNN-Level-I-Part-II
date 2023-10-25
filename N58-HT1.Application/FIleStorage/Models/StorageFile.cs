namespace N58_HT1.Application.FIleStorage.Models;

public class StorageFile : IStorageEntry
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string DirectoryPath {  get; set; } = string.Empty;
    public long Size { get; set; }
    public string Extension { get; set; } = string.Empty;
    public StorageEntryType Type { get; set; }
}