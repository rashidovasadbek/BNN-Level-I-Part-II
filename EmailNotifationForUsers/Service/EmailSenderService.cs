using EmailNotifationForUsers.Model;
using EmailNotifationForUsers.Service.Interface;
using System.Net.Mail;
using System.Net;

namespace EmailNotifationForUsers.Service;

public class EmailSenderService : IEmailSenderService
{
    public async ValueTask<bool> SendEmailsAsync(IEnumerable<EmailMassage> emailMessage)
    {
      
        using (var smtp = new SmtpClient("smtp.gmail.com", 587))
        {
            smtp.Credentials = new NetworkCredential("asadbekrashidov@gmail.com", "xaubbroofvsxoxnh");
            smtp.EnableSsl = true;

            foreach (var email in emailMessage)
            {
                var mail = new MailMessage();
                mail.Subject = email.Subject;
                mail.Body = email.Body;             
            }
           // await smtp.SendMailAsync(emailMessage);
        }
       return true;
    }
}
