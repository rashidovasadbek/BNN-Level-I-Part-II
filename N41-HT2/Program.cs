
using N41_HT2;

var emailService = new EmailSenderService();
var emailAddresses = new List<string>
{
    "sultonbek.rakhimov@gmail.com",
    "jasurabdulxaev@gmail.com",
    "abdura52.uz@gmail.com",
    "toshmurodovj13@gmail.com",
    "kbunyod3011@gmail.com",
    "azamamonov555@gmail.com",
    "abdurahmonsadriddinov0412@gmail.com",
    ".com",
    "rashidovasadbek264@gmail.com"
};

var sendRegistrationEmailTasks = emailAddresses.Select(async emailAddress =>
{
    Console.WriteLine($"Current thread Id inside Select - {Environment.CurrentManagedThreadId}");
    var result = await emailService.SendEmailAsync(emailAddress, "Confirm you account", "Enter to this link");
    Console.WriteLine($"Current thread Id inside Select - {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"{emailAddress} ga email jo'natish resultati - {result}");
    return result;
});
