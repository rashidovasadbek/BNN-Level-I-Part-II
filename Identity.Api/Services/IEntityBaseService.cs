using N66.LibraryManagement.Domin.Entities.Models;
using System.Linq.Expressions;

namespace N66.LibraryManagement.Application.Services;

public interface IEntityBaseService<T> where T : class
{
    ValueTask<T> CreateAsync(T value, bool saveChanges, CancellationToken cancellationToken = default);
    
    IQueryable<T> Get(Expression<Func<T, bool>>? pridicate = null);

    ValueTask<ICollection<T>> GetAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken = default);

    ValueTask<T> GetByIdAsync(Guid valueId, CancellationToken cancellationToken = default);

    ValueTask<T> UpdateAsync(T value, bool saveChanges, CancellationToken cancellationToken = default);

    ValueTask<T> DeleteByIdAsync(Guid  valueId, bool saveChanges, CancellationToken cancellationToken = default);
}
