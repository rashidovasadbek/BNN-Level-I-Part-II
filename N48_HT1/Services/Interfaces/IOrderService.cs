﻿using N48_HT1.Models;
using System.Linq.Expressions;

namespace N48_HT1.Services.Interfaces
{
    public interface IOrderService
    {
        IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

        ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<Order> CreateAsync(Order Order, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> UpdateAsync(Order Order, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> DeleteAsync(Order Order, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
