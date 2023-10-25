using N58_HT1.Application.FIleStorage.Models;
using N58_HT1.Application.Services;

namespace N58_HT1.Infrastructura.Servcies;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryService)
    {
        _fileService = fileService;
        _directoryService = directoryService;
    }
    public async ValueTask<List<IStorageEntry>> GetStorageEntriesAsync(string directoryPath)
    {
        var storageItems = new List<IStorageEntry>();

        storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath));
        storageItems.AddRange(await _fileService.GetFilesByPathAsync(_directoryService.GetFilesPath(directoryPath)));

        return storageItems;
    }
}