using N56__HT1.Models.Storage;

namespace N56__HT1.Services.Interfaces;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoryPath(string directoryPath);
    IEnumerable<string> GetFilePath(string filePath);
    ValueTask<IList<StorageDirectory>> GetStorageDirectoriesAsync(string directoryPath);
    ValueTask<StorageDirectory> GetByPathAsync(string directoryPath);
}