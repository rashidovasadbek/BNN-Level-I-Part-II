namespace N53_HT1.Model.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Status { get; set; }
        public int orderSum { get; set; }
        public bool IsDeleted { get; set; }
    }
}
