using N65.IdentityVerification.Application.Common.Identities.Models;

namespace N65.IdentityVerification.Application.Common.Identities.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);

}
