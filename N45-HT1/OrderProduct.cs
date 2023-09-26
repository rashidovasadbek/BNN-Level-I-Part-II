namespace N45_HT1;

public class OrderProduct
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }

    public OrderProduct(int id, int orderdId, int productId, int count)
    {
        Id = id;
        OrderId = orderdId;
        ProductId = productId;
        Count = count;
    }
}
