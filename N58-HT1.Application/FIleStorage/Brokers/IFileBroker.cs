using N58_HT1.Application.FIleStorage.Models;

namespace N58_HT1.Application.FIleStorage.Brokers;

public interface IFileBroker
{
    StorageFile GetByPath(string directoryPath);
}
