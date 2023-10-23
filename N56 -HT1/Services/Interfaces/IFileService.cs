using N56__HT1.Models.Storage;

namespace N56__HT1.Services.Interfaces;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath);
    ValueTask<StorageFile> GetFileByPathAsync(string filePath);
}
