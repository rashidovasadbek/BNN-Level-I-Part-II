namespace N45_HT1;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public User(int id, string firstName)
    {
        Id = id;
        FirstName = firstName;
    }
}
