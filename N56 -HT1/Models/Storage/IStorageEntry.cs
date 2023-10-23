namespace N56__HT1.Models.Storage;

public interface IStorageEntry
{
    string Name { get; set; } 
    string Path { get; set; } 
    StorageItemType ItemType { get; set; }
}
