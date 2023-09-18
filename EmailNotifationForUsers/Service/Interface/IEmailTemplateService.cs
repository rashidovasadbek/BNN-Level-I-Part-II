using EmailNotifationForUsers.Model;
using System.Collections.Generic;

namespace EmailNotifationForUsers.Service.Interface;

public interface IEmailTemplateService
{
    IEnumerable<EmailTemplate> GetTemplate(IEnumerable<User> users);
}
