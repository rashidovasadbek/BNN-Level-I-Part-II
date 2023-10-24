using N56__HT1.Models.Storage;

namespace N56__HT1.Services.Interfaces;

public interface IFileService
{
    string GetFileExtantions(string path);
    long GetFileSize(string filePath);
    bool DeletedFile(string filePath);
}