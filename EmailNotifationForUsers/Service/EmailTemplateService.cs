using EmailNotifationForUsers.Model;
using EmailNotifationForUsers.Service.Interface;


namespace EmailNotifationForUsers.Service;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly List<EmailTemplate> _templates = new List<EmailTemplate>
    {
        new EmailTemplate() { Subject = "Welcome to our system!", Body = "Hi {{FullName}}, welcome to our system!" },
        new EmailTemplate() { Subject = "Account activated", Body = "Dear {{FullName}}, We are pleased to inform you that your account has been activated. You can now log in and start using our system."},
        new EmailTemplate() { Subject = "Account deleted", Body = "Dear {{FullName}}, We are sorry to inform you that your account has been deleted from our system. This action was taken because [reason for account deletion]." }
    };
    public IEnumerable<EmailTemplate> GetTemplate(IEnumerable<User> users)
    {      
        var formattedTemplates = new List<EmailTemplate>();
        
        _templates[0].Body.Replace("{{FullName}}", $"{users.Select(u => u.FirstName + " " + u.LastName)}");
        formattedTemplates.Add(_templates[0]);

        _templates[1].Body.Replace("{{FullName}}", $"{users.Select(u => u.FirstName + " " + u.LastName)}");
        formattedTemplates.Add(_templates[1]);

        _templates[0].Body.Replace("{{FullName}}", $"{users.Select(u => u.FirstName + " " + u.LastName)}");
        formattedTemplates.Add(_templates[2]);
            
        foreach (var template in formattedTemplates)
        {
            yield return template;
        }
            
    }
}
