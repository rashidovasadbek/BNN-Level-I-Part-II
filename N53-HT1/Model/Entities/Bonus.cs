namespace N53_HT1.Model.Entities
{
    public class Bonus : IEntity
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public DateTime DateGranted { get; set; }
        public DateTime DatePaid { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
