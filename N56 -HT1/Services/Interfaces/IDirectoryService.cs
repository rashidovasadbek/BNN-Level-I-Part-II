

namespace N56__HT1.Services.Interfaces;

public interface IDirectoryService
{
    IEnumerable<string> GetListCurrentDirectories(string directoryPath);
    IEnumerable<string> GetListFiles(string directoryPath);

}