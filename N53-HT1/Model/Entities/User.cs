namespace N53_HT1.Model.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsDeleted { get; set; }

    }
}
