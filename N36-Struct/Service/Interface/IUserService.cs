using N36_Struct.Model;

namespace N36_Struct.Service.Interface;

public interface IUserService
{
    void Create(User user);
    User GetById(int id);
    void Update(User examScore);
    void Delete(int id);
    IEnumerable<User> GetAll();
}
