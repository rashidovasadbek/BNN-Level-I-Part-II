using N65.IdentityVerification.Application.Common.Enums;
using N65.IdentityVerification.Application.Common.Identities.Services;
using N65.IdentityVerification.Application.Common.Notifications.Services;
using N65.IdentityVerification.Domin.Entities;

namespace N65.IdentityVerification.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public static readonly List<User> _users = new();
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AccountService(IVerificationTokenGeneratorService verificationTokenGeneratorService, IEmailOrchestrationService emailOrchestrationService)
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
    }

    public List<User> Users => _users;


    ValueTask<User> IAccountService.CreateUserAsync(User user)
    {
        _users.Add(user);

        var emailVerificationToken = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);
        _emailOrchestrationService.SendAsync(user.EmailAddress, emailVerificationToken);

        return new(user);
    }

    ValueTask<bool> IAccountService.VerificateAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.IsValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        var foundUser = _users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException();

        foundUser.IsEmailAddressVerified = true;

        return new(true);
    }
}
