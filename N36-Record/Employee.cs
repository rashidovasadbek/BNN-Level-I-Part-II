namespace N36_Record;
public record Employee(string FirstName, string LastName, int Age, string Email,string Password, string Card) : Person(FirstName,LastName,Age);
