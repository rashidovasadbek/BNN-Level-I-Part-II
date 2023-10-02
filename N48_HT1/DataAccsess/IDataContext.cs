using FileBaseContext.Abstractions.Models.FileSet;
using N48_HT1.Models;

namespace N48_HT1.DataAccsess
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }
        IFileSet<Order, Guid> Orders { get; }
        ValueTask SaveChangesAsync();
    }
}
