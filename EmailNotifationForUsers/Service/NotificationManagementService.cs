using EmailNotifationForUsers.Model;
using EmailNotifationForUsers.Service.Interface;

namespace EmailNotifationForUsers.Service;

public class NotificationManagementService : INotificationManagementService
{
    private readonly IUserService _userService;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailService _emailService;
    private readonly IEmailSenderService  _emailSenderService;


    public NotificationManagementService(IUserService userService,IEmailTemplateService emailTemplateService,IEmailService emailService, IEmailSenderService emailSenderService)
    {
        _userService = userService;
        _emailTemplateService = emailTemplateService;
        _emailService = emailService;
        _emailSenderService = emailSenderService;

    }

    public async Task NotifyUsersAsync()
    {
        var users = _userService.GetUsers();
        var templates = _emailTemplateService.GetTemplate(users);
        var messages = _emailService.GetMessages(templates);
        await _emailSenderService.SendEmailsAsync(messages);     
    }
}
