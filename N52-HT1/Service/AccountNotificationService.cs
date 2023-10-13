using N52_HT1.Event;
using N52_HT1.Model.Entity;

namespace N52_HT1.Service
{
    public class AccountNotificationService
    {
        private readonly AccountEventStore _usersEventStore;
        private readonly UserService _userService;
        private readonly EmailSenderService _emailSenderService;

        public AccountNotificationService(AccountEventStore accountEventStore, UserService userService, EmailSenderService emailSenderService)
        {
            _usersEventStore = accountEventStore;
            _userService = userService;
            _emailSenderService = emailSenderService;

            _usersEventStore.OnUserCreated += HendleUserCreatedEventAsync;

        }


        public async ValueTask HendleUserCreatedEventAsync(User user)
        {
           var result =  await _emailSenderService.SendEmailAsync(user.EmailAddress, "hi ", $"Welcome to {user.EmailAddress}");
            Console.WriteLine($"Welcome to {user.EmailAddress}");
            Console.WriteLine(result);
        }
    }
}
