namespace N36_Record;

public record Manager(string FirstName, string LastName, int Age, string Email, string Password, string Card, string Address, string Salary) : Employee(FirstName, LastName, Age, Email, Password, Card);


