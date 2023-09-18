using System.Collections;

namespace N38_HT1;

public class UserContainer : IEnumerable<FileInfo>
{
    private readonly List<FileInfo> _filesPath;
    public UserContainer(string diroctoryPath)
    {
        var directory = new DirectoryInfo(diroctoryPath);
        _filesPath = directory.GetFiles("*.cs",SearchOption.AllDirectories).ToList();
    }

    public IEnumerator<FileInfo> GetEnumerator()
    {
        return _filesPath.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    
    public FileInfo this[int index] => _filesPath[index];
    public FileInfo this[string keyword] => _filesPath.First(f => f.Name.Contains(keyword));
}
