
using N36_Struct.Model;
using N36_Struct.Service;
using N36_Struct.Service.Interface;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

/*var person = new Person("Asadbek", 21, "Namangan");
person.Deconstruct(out string Name, out int Age, out string address);

//Console.WriteLine(person);
//Console.WriteLine(Name + " " + Age +" "+ address);


var point = new Point(6, 4);
//Console.WriteLine(point.X+":"+point.Y);   
public record Person(string Name,int Age,string address);
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int pointX, int pointY)
    {
        X = pointX;
        Y = pointY;
    }

}
*/

/*(string, string, DateOnly) book = ("Harry Poter", "Jim Clear", new DateOnly(2002, 3, 3));
Console.WriteLine(book.Item1);
Console.WriteLine(book.Item2);
Console.WriteLine(book.Item3);*/

/*public record Order(int ID,string Customer,string Items);
public record Products(int ID,string Name,double Price);
public record Address(string Street, string City,string State);
public record Invoice(int ID,string Customer,int TotalAmount);
public record Employee(string Name,string department, double Salary);
public record Company(string Name, string Address, string PhoneNumber);
public record Vehicle(string Make,string Model,string Year);
public record CustomerOrder(string Name,string Email,List<Order> OrderList);
public record AddressBookEntry(string Name,string Email,string PhoneNumber);
public record Rectangle(float Width,float Height);
public record Circle(float Radius,float CenterPoint);
public record Line(float Start,float Point);
public record Color(string Red,string Green,string Blue);
public record WeatherData( float temperature,float humidity,float WindSpeed);*/



/*var userA = new User(1,"Asadbek","Rashidov");
var userB = new User(2,"Ali","Valiev");
var userC = new User(3,"Jhon","Doe");
var userD = new User(4,"Malika","Toxirova");

var examscoreA = new ExamScore(1, 2, 95);
var examscoreB = new ExamScore(2, 1, 45);
var examscoreC = new ExamScore(3, 4, 78);
var examscoreD = new ExamScore(4, 3, 80);

IUserService userService = new UserService();
IExamScoreService examScoreService = new ExamScoreService();
ExamAnalytics examAnalytics = new ExamAnalytics(examScoreService, userService);

var allScores = examAnalytics.GetAllScores();
foreach(var score in allScores)
    Console.WriteLine($"{score.Fullname} {score.Score}");*/