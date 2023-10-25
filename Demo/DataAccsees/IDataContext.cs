using Demo.Models;
using FileBaseContext.Abstractions.Models.FileSet;

namespace Demo.DataAccsees;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    ValueTask SaveChangesAsync();
}
