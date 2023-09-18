using EmailNotifationForUsers.Model;
using EmailNotifationForUsers.Service.Interface;

namespace EmailNotifationForUsers.Service;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>
    {
        new User { FirstName = "John", LastName = "Doe", Status = Status.Registered },
        new User { FirstName = "Jane", LastName = "Doe", Status = Status.Active },
        new User { FirstName = "Peter", LastName = "Parker", Status = Status.Deleted }
    };

    public IEnumerable<User> GetUsers()
    {
        foreach(var user in _users)
        {
            yield return user;
        }

    }
}
