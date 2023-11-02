using N65.IdentityVerification.Domin.Entities;

namespace N65.IdentityVerification.Application.Common.Identities.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
}
