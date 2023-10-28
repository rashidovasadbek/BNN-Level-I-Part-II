using FileUpload.Models.Entities;
using FileUpload.Services.Interfaces;

namespace FileUpload.Services
{
    public class FileService : IFileService
    {
        private readonly IStorageFileService _storageFileService;
        private readonly string _basePath;

        public FileService(IStorageFileService storageFileService, IWebHostEnvironment webHost )
        {
            _storageFileService = storageFileService;
            _basePath = webHost.WebRootPath;
        }
        public async ValueTask<StorageFile> UploadFileAsync(Stream file, string fileName, Guid userId)
        {
            var folderPath = Path.Combine(_basePath, "Users", userId.ToString(),"Profile");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var storageFile = await _storageFileService.CreateFile(fileName, userId);

            var data = File.Create(folderPath + storageFile.Id.ToString());
            await file.CopyToAsync(data);
            data.Close();

            return storageFile;
        }

        public ValueTask<bool> DeleteFileAsync(string Path)
        {
            throw new NotImplementedException();
        }

       
    }
}
