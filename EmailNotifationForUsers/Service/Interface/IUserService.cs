using EmailNotifationForUsers.Model;

namespace EmailNotifationForUsers.Service.Interface;

public interface IUserService
{
   IEnumerable<User> GetUsers();
}
