using FileUpload.Models.Entities;

namespace FileUpload.Services.Interfaces;

public interface IFileService
{
    ValueTask<StorageFile> UploadFileAsync(Stream file, string fileName, Guid userId);
    ValueTask<bool> DeleteFileAsync(string Path);
}
