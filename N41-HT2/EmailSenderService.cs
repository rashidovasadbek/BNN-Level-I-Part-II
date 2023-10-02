using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;

namespace N41_HT2;

public class EmailSenderService
{
    public SmtpClient SmtpClientInstance { get; init; }
    private readonly object _lock = new();
    public EmailSenderService()
    {
        lock (_lock)
        {
            SmtpClientInstance = new SmtpClient("smtp.gmail.com", 587);
            SmtpClientInstance.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            SmtpClientInstance.EnableSsl = true;
        }
    }

    public Task<bool> SendEmailAsync(string receiverEmailAddress, string subject, string body)
    {
    return Task.Run(async () =>
    {
        var result = true;
        try
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            smtp.EnableSsl = true;

            var mail = new MailMessage("rashidovasadbek264@gmail.com", receiverEmailAddress);
            mail.Subject = subject;
            mail.Body = body;

            await smtp.SendMailAsync(mail);
            
        }
        catch (Exception e)
        {
            result = false;
        }

        return result;
    });
    }
}
