using N58_HT1.Application.FIleStorage.Brokers;
using N58_HT1.Application.FIleStorage.Models;
using N58_HT1.Application.Services;

namespace N58_HT1.Infrastructura.Servcies;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;

    public FileService(IFileBroker fileBroker)
    {
        _fileBroker = fileBroker;
    }
    public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        var files = await Task.Run(() => { return filesPath.Select(filePath => _fileBroker.GetByPath(filePath)).ToList(); });
        
        return files;
    }
}
