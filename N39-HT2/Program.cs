using N39_HT2;
using N39_HT2.model;

var emailSenderServoce = new EmailSenderService();
var accountService = new AccountService(emailSenderServoce);
try
{
 var accounts = accountService.Register(new Account("test@example.com","password"));
 //var accountsA = accountService.Register(new Account("test@example.com","password"));

    //foreach (var account in accounts)
    //    Console.WriteLine(account);
}catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}catch(InvalidOperationException ex)
{
    Console.WriteLine($"{ex.Message}");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
