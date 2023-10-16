using N53_HT1.DataAccsess;
using N53_HT1.Model.Entities;
using System.Linq.Expressions;

namespace N53_HT1.Service;

public class OrderService
{
    private readonly AppFileContext _appDataContext;

    public OrderService(AppFileContext appFileContext)
    {
        _appDataContext = appFileContext;
    }


    public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!ValidationToNull(order))
            throw new ArgumentNullException("This user members is null");

        if (ValidationExists(order))
            throw new ArgumentException("This user is Alarady Exists");

        await _appDataContext.Orders.AddAsync(order, cancellationToken);

        if (saveChanges)
            await _appDataContext.Orders.SaveChangesAsync();

        return order;
    }
    public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
    {
        return _appDataContext.Orders.Where(predicate.Compile()).AsQueryable();
    }

    private bool ValidationToNull(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.Status))
            return false;

        return true;
    }
    private bool ValidationExists(Order order)
    {
        var foundUsers = GetUndeletedUsers().FirstOrDefault(serach => serach.Equals(order));

        if (foundUsers is null)
            return false;

        return true;
    }

    private IQueryable<Order> GetUndeletedUsers()
        => _appDataContext.Orders.Where(order =>!order.IsDeleted).AsQueryable();
}
