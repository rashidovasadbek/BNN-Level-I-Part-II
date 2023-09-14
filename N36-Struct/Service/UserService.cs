using N36_Struct.Model;
using N36_Struct.Service.Interface;

namespace N36_Struct.Service;

public class UserService :IUserService
{
    private List<User>  users = new List<User>();
    public void Create(User user)
    {
        users.Add(new User(user.Id, user.FirstName, user.LastName));
    }
    public User GetById(int id)
    {
        return users.FirstOrDefault(user => user.Id == user.Id);
    }
    public void Update(User user)
    {
        var index = users.FindIndex(index => index.Id == user.Id);
        users[index].FirstName = user.FirstName;
        users[index].LastName = user.LastName;
    }
    public void Delete(int id)
    {
        var user = users.Find(remove => remove.Id == id);
        if(user  != null)
        {
            users.Remove(user);
        }
    }
    public IEnumerable<User> GetAll()
    {
        return users;
    }
}
