using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Application.FIleStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetDirectoriesPath(string directoryPath);

    IEnumerable<string> GetFilesPath(string directoryPath);

    IEnumerable<StorageDirectory> GetDirectories(string directoryPath);

    StorageDirectory GetByPathAsync(string directoryPath);
    
    bool ExistsAsync(string directoryPath);
}