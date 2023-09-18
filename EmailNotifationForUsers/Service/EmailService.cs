using EmailNotifationForUsers.Model;
using EmailNotifationForUsers.Service.Interface;

namespace EmailNotifationForUsers.Service;

public class EmailService : IEmailService
{
    public IEnumerable<EmailMassage> GetMessages(IEnumerable<EmailTemplate> emailTemplates)
    {
        var messages  = new List<EmailMassage>();
        foreach (var emailTemplate in emailTemplates)
        {

                var emailMassage = new EmailMassage()
                {
                    Subject = emailTemplate.Subject,
                    Body = emailTemplate.Body,
                    SenderAddress = "asadbekrashidov@gmail.com",
                    ReceiverAddress = "boxodirolimov@gmail.com"
                };
                messages.Add(emailMassage);
            }
        
        return messages;
    }
}
