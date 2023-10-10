using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Services.Interface
{
    public interface IToDoService
    {
        IQueryable<ToDo> Get(Expression<Func<ToDo, bool>> predicate);

        ValueTask<ICollection<ToDo>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        ValueTask<ToDo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<ToDo> CreateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<ToDo> UpdateAsync(ToDo user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<ToDo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<ToDo> DeleteAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
