using N53_HT1.DataAccsess;
using N53_HT1.Model.Entities;
using System.Linq.Expressions;

namespace N53_HT1.Service;

public class UserService
{
    private readonly AppFileContext _appDataContext;

    public UserService(AppFileContext appFileContext)
    {
        _appDataContext = appFileContext;
    }


    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!ValidationToNull(user))
            throw new ArgumentNullException("This user members is null");

        if (ValidationExists(user))
            throw new ArgumentException("This user is Alarady Exists");

        await _appDataContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _appDataContext.Users.SaveChangesAsync();

        return user;
    }
    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _appDataContext.Users.Where(predicate.Compile()).AsQueryable();
    }

    private bool ValidationToNull(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName)
            || string.IsNullOrWhiteSpace(user.EmailAddress))
            return false;

        return true;
    }
    private bool ValidationExists(User user)
    {
        var foundUsers = GetUndeletedUsers().FirstOrDefault(serach => serach.Equals(user));

        if (foundUsers is null)
            return false;

        return true;
    }

    private IQueryable<User> GetUndeletedUsers()
        => _appDataContext.Users.Where(user => !user.IsDeleted).AsQueryable();
}
