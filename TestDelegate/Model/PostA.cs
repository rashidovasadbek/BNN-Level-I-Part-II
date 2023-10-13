namespace TestDelegate.Model;

public class PostA
{
    public int Id { get; set; }
    public List<Topic> Topics { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public PostA(int id, List<Topic> topic, string title, string decription)
    {
        Id = id;
        Topics = topic;
        Title = title;
        Description = decription;
    }
}
