
using N37_tasks;

var person = new Student("Asadbek", "Rashidov",3);
var personA = person with { FirstName = "G'ayrat" };

Console.WriteLine(person);
Console.WriteLine(personA);
/*person.Deconstruct(out string firstName, out string lastName);
personA.Deconstruct(out string firstName1, out string lastName1);*/






