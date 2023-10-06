namespace N43_HT1;

public  class UserService
{
    private  List<User> _users;
   public List<User> Users
    {
        get { return _users; }
    }

   public  User GetUserById(int id)
    {
        return  _users.FirstOrDefault(user => user.Id ==  id);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.IsActive = user.IsActive;
        }
    }

    public void DeactivateUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.IsActive = false;
        }
    }

    public void DeleteUser(int id)
    {
        _users.RemoveAll(u => u.Id == id);
    }

}
