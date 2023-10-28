using FileUpload.Models.Entities;

namespace FileUpload.Services.Interfaces;

public interface IStorageFileService
{
    ValueTask<StorageFile> CreateFile(string Name, Guid UserId);
    ValueTask<bool> DeleteFile(string Path);
}
