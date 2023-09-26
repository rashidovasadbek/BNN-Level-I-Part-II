namespace N45_HT1;

public class Order
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int UserId { get; set; }

    public Order(int id, int amount, int userId)
    {
        Id = id;
        Amount = amount;
        UserId = userId;
    }
}
