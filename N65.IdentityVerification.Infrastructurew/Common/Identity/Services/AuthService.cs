using N65.IdentityVerification.Application.Common.Identities.Models;
using N65.IdentityVerification.Application.Common.Identities.Services;
using N65.IdentityVerification.Application.Common.Notifications.Services;
using N65.IdentityVerification.Domin.Entities;
using System.Security.Authentication;

namespace N65.IdentityVerification.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHesherService _passwordHesherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AuthService(
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHesherService passwordHesherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHesherService = passwordHesherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress);
        if (foundUser is null || !_passwordHesherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new ValueTask<string>(accessToken);
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == registrationDetails.EmailAddress);
        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHesherService.HeshPassword(registrationDetails.Password)
        };

        await _accountService.CreateUserAsync(user);
        var verificationEmailResult = await _emailOrchestrationService.SendAsync(registrationDetails.EmailAddress, "Sistemaga xush kelibsiz");

        return verificationEmailResult;
    }
}
