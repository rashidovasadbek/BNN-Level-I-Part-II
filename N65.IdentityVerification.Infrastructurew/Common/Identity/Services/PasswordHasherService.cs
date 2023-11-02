using N65.IdentityVerification.Application.Common.Identities.Services;
using BC = BCrypt.Net.BCrypt;

namespace N65.IdentityVerification.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHesherService
{
    public string HeshPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}
