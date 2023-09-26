using N45_HT1;

var users = new List<User>()
{
    new User(1,"Jhon"),
    new User(2,"Bob"),
    new User(3,"Jemes"),

};
var orders = new List<Order>()
{
    new Order(1, 10, 1),
    new Order(2, 20, 1),
    new Order(3, 30, 1),
    new Order(4, 45, 1)
};
var orderProducts = new List<OrderProduct>()
{
    new OrderProduct(1, 1, 1, 23),
    new OrderProduct(2, 2, 2, 45),
    new OrderProduct(3, 3, 3, 10),
    new OrderProduct(3, 4, 4, 12),
};

var products = new List<Product>()
{
    new Product(1, "Product 1", 100),
    new Product(2, "Product 2", 200),
    new Product(3, "Product 3", 300),
    new Product(4, "Product 3", 500)
};

var productNames = from order in orders
            join orderProduct in orderProducts on order.Id equals orderProduct.OrderId
            join product in products on orderProduct.ProductId equals product.Id
            where order.UserId == 1
            select product.Name;    

foreach (var productName in productNames.Distinct())
{
    Console.WriteLine(productName);
}
