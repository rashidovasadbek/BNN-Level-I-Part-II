using N39_HT1;

var users = new List<User> 
{
    new User("Asadbek","Rashidov"),
    new User("Jhon","Doe"),
    new User("Johongir","Alimov"),
    new User("Jhon","Clear")
};

var weatherReports = new List<WeatherReport>
{
    new WeatherReport("UZB",23.2),
    new WeatherReport("USA",32.2),
    new WeatherReport("London",40.4),
    new WeatherReport("CHina",39.9),
};


if(users.FirstOrDefault(user=> user.FirstName == "Jhon") is User name)
{
    Console.WriteLine(name);
}
var list = new List<WeatherReport>();
foreach(var weather in weatherReports)
    list.Add(weatherReports.FirstOrDefault(weather => weather is { Degree: > 30 }));
