namespace Event.Models.Entities
{
    public class BlogPost : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public List<string> Topic { get; set; } = new();

        public Guid AutherId { get; set; }
    }
}
