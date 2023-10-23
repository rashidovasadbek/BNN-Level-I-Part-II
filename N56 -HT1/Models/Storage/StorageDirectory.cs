namespace N56__HT1.Models.Storage;

public class StorageDirectory : IStorageEntry
{
    public string Name { get; set; } = string.Empty;
    public string Path { get ; set; } = string.Empty;
    public StorageItemType ItemType { get ; set ; } = StorageItemType.Directory;
}