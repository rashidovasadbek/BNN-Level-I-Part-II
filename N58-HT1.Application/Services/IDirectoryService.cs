using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Application.Services;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoriesPath(string directoryPath);
    IEnumerable<string> GetFilesPath(string filePath);
    ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath);
    ValueTask<StorageDirectory> GetByPathAsync(string directoryPath);
}