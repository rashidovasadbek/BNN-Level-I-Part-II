using N56__HT1.Models.Storage;
using N56__HT1.Services.Interfaces;

namespace N56__HT1.Services;

public class DirectoryService : IDirectoryService
{
    public ValueTask<StorageDirectory> GetByPathAsync(string directoryPath)
    {
      if( string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath)); 
      return new ValueTask<StorageDirectory>(Directory.GetDirectories(directoryPath));
    }

    public IEnumerable<string> GetDirectoryPath(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));
        return GetFilePath(filePath);
    }

    public ValueTask<IList<StorageDirectory>> GetStorageDirectoriesAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }
}
