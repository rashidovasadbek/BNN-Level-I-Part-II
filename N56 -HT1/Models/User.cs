namespace N56__HT1.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public User(Guid id ,string name)
    {
        Id = id;    
        Name = name;
    }
}
