using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Application.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath);
}
