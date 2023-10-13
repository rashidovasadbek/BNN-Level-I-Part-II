namespace N52_HT1.Model.Entity
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}
