using EmailNotifationForUsers.Model;

namespace EmailNotifationForUsers.Service.Interface;

public interface IEmailSenderService
{
    ValueTask<bool> SendEmailsAsync(IEnumerable<EmailMassage> emailMassage);
}
