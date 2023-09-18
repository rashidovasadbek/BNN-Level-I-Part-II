using N38_HT1;

var users = new List<User>
{
    new(Guid.NewGuid(),"Asadebek", "Rashidov","asadbek21@mail.com"),
    new(Guid.NewGuid(),"Ali", "Valiyev","ali901@mail.com"),
    new(Guid.NewGuid(),"Bobur", "Salimov","bobur455@mail.com"),
    new(Guid.NewGuid(),"Samandar", "Bektoshov","samandar@mail.com"),
};



var userContainer = new UserContainer("D:\\3_month\\N38-HT1");
/*for(int i = 0; i < userContainer.Count(); i++)
{
    Console.WriteLine(userContainer[i]);
}*/

//Console.WriteLine(userContainer["sa"]);