namespace N56__HT1.Models.Storage;

public class StorageFile : IStorageEntry
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public long Size { get; set; }
    public string Extension { get; set; } = string.Empty;
    public StorageItemType ItemType { get ; set ; } = StorageItemType.File;
}