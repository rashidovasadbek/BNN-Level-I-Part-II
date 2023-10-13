using System.Net.Mail;
using System.Net;

namespace N52_HT1.Service
{
    public class EmailSenderService
    {
        public SmtpClient SmtpClientInstance { get; set; }

        public async ValueTask<bool> SendEmailAsync(string receiverAddress, string subject, string body)
        {
            var result = false;
            try
            {

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                    smtp.EnableSsl = true;

                    var mail = new MailMessage("sultonbek.rakhimov.recovery@gmail.com", receiverAddress);
                    mail.Subject = subject;
                    mail.Body = body;

                    await smtp.SendMailAsync(mail);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
