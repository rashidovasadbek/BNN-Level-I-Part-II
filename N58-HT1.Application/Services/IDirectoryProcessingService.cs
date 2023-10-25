using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Application.Services;

public interface IDirectoryProcessingService
{
    ValueTask<List<IStorageEntry>> GetStorageEntriesAsync(string directoryPath);
}
