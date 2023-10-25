using N56__HT1.Services.Interfaces;

namespace N56__HT1.Services;

public class FileService : IFileService
{
    public string GetFileExtantions(string filePath)
         => Path.GetExtension(filePath);

    public long GetFileSize(string filePath)
        => new FileInfo(filePath).Length;
    
    public bool DeletedFile(string filePath)
    {
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        return false;
    }
}