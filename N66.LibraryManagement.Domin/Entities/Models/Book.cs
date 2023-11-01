namespace N66.LibraryManagement.Domin.Entities.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public virtual Auther Auther { get; set; } 

}
