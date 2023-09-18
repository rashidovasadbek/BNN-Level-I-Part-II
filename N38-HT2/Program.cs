using Bogus;

var faker = new Faker();

var employee = new Employee()
{
    Id = faker.Random.Guid(),
    FullName = faker.Person.FullName,
    PhoneNumber = faker.Phone.PhoneNumber(),
    Email = faker.Internet.Email(),
};


var order = new Order()
{
    Id = faker.Random.Guid(),
    Name = faker.Commerce.ProductName(),
    OrderDate = DateTime.Now,
    Amount = faker.Random.Int(100, 1000)
    
};

var userAddress = new UserAddress()
{
    Id = faker.Random.Guid(),
    Street = faker.Address.StreetAddress(),
    City = faker.Address.City(),
    State = faker.Address.State(),
};

var blogPost = new BlogPost()
{
    Id = faker.Random.Guid(),
    Auther = faker.Person.FullName,
    Title = faker.Lorem.Words().ToString(),
    Content= faker.Lorem.Text()

};

var weatherReport = new WeatherReport()
{
    id = faker.Random.Guid(),
    DateTime = DateTime.Now,
    City = faker.Address.City(),
    Temprature = faker.Random.Float(-50, 50),
    Condition = faker.Lorem.Word()

};

/*Console.WriteLine($"{employee.Id},{employee.FullName},{employee.PhoneNumber},{employee.Email}");
Console.WriteLine($"{order.Id},{order.Name},{order.OrderDate},{order.Amount}");
Console.WriteLine($"{userAddress.Id},{userAddress.Street},{userAddress.City},{userAddress.State}");
Console.WriteLine($"{blogPost.Id},{blogPost.Auther},{blogPost.Content},{blogPost.Title}");
Console.WriteLine($"{weatherReport.id},{weatherReport.City},{weatherReport.Condition},{weatherReport.Temprature},{weatherReport.DateTime}");*/
public class WeatherReport 
{
    public Guid id { get; set; }
    public DateTime DateTime { get; set; }
    public string City { get; set; }    
    public float Temprature { get; set; }   
    public string Condition { get; set; }
}


public class BlogPost
{
    public Guid Id { get; set; }
    public string Auther { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
}
public class UserAddress
{
   public Guid Id { get; set; }
   public string Street { get; set; }
   public string City { get; set; }
   public string State { get; set; }

};
public class Order
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime OrderDate { get; set; } 
    public decimal Amount { get; set; }
}
public class Employee 
{ 
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }   
};

