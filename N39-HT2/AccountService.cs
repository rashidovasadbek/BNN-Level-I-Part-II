using N39_HT2.model;

namespace N39_HT2;

public class AccountService
{
    private readonly EmailSenderService _emailSenderService;
    private readonly List<Account> _account = new List<Account>();
    public AccountService(EmailSenderService emailSenderService)
    {
         _emailSenderService = emailSenderService;     
    }
    public List<Account> Register(Account account)
    {
        var sendemail = new EmailSenderService();

        if (string.IsNullOrEmpty(account.EmailAddress) && string.IsNullOrEmpty(account.Password))
            throw new ArgumentNullException("invalid null emailAddress");
        
        if (!_emailSenderService.SendEmail(account.EmailAddress))
            throw new InvalidOperationException("Filed send Email");
        
        if (_account.Any(x => x.EmailAddress == account.EmailAddress))
            throw new ArgumentNullException("User already exists");
        else
            _account.Add(account);
        
        return _account;
    }


}
