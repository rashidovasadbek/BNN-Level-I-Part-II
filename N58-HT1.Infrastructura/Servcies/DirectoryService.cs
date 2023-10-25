using N58_HT1.Application.FIleStorage.Brokers;
using N58_HT1.Application.FIleStorage.Models;
using N58_HT1.Application.Services;

namespace N58_HT1.Infrastructura.Servcies;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _directoryBroker;

    public DirectoryService(IDirectoryBroker directoryBroker)
    {
        _directoryBroker = directoryBroker;
    }
    public ValueTask<StorageDirectory> GetByPathAsync(string directoryPath)
    {
        if(string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath)); 
        
        return new ValueTask<StorageDirectory>(_directoryBroker.GetByPathAsync(directoryPath));
    }

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath)
    {
       if(string.IsNullOrWhiteSpace(directoryPath))
          throw new ArgumentNullException(nameof(directoryPath));

       var directories = await Task.Run(() => _directoryBroker.GetDirectories(directoryPath).ToList());
      
       return directories;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath)
        => _directoryBroker.GetFilesPath(directoryPath).ToList();

    public IEnumerable<string> GetFilesPath(string filePath)
        => _directoryBroker.GetFilesPath(filePath);
    
}
