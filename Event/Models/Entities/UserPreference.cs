namespace Event.Models.Entities
{
    public class UserPreference : IEntity
    {
        public Guid Id { get ; set; }
        public Guid UserId { get; set; }
        public List<string> LinkedTopics { get; set; } = new ();
    }
}
