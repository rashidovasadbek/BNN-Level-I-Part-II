using EmailNotifationForUsers.Model;

namespace EmailNotifationForUsers.Service.Interface;

public interface IEmailService
{
     IEnumerable<EmailMassage> GetMessages(IEnumerable<EmailTemplate> emailTemplates);
}
