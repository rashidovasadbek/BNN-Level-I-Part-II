using N56__HT1.Models.Storage;
using N56__HT1.Services.Interfaces;

namespace N56__HT1.Services;

public class DirectoryService : IDirectoryService
{
    public IEnumerable<string> GetListCurrentDirectories(string directoryPath)
        => Directory.EnumerateDirectories(directoryPath);

    public IEnumerable<string> GetListFiles(string filePath)
        => Directory.EnumerateFiles(filePath);
}