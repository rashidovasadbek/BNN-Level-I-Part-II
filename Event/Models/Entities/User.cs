namespace Event.Models.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set ; }
        public string UserName { get; set; } = string.Empty;
    }
}
