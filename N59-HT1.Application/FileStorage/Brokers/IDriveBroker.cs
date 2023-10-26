using N59_HT1.Application.FileStorage.Models;

namespace N59_HT1.Application.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}
