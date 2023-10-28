using FileUpload.Models.Entities;
using FileUpload.Services.Interfaces;

namespace FileUpload.Services;

public class StorageFileService : IStorageFileService
{
    private readonly List<StorageFile> _storageFiles = new();
    public async ValueTask<StorageFile> CreateFile(string Name, Guid userId)
    {
        var fileId = Guid.NewGuid();
        var filePath = Path.Combine(userId.ToString(),"Profile", fileId.ToString());

        var model = new StorageFile()
        {
            Id = fileId,
            OrginalName = Name,
            UserId = userId,
            Path = filePath,
            UploadAt = DateTime.Now

        };
        _storageFiles.Add(model);

        return model;
    }

    public ValueTask<bool> DeleteFile(string Path)
    {
        throw new NotImplementedException();
    }
}
