using System.Linq.Expressions;
using ToDoList.DataAccsess;
using ToDoList.Models;

namespace ToDoList.Services.Interface
{
    public interface IUserService
    {
     
        IQueryable<User> Get(Expression<Func<User, bool>> predicate);
        ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
