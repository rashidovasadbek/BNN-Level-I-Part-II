using FileBaseContext.Abstractions.Models.FileSet;
using ToDoList.Models;

namespace ToDoList.DataAccsess
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }
        IFileSet<ToDo, Guid> ToDos { get; }
        ValueTask SaveChangesAsync();
    }
}
