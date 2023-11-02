namespace N65.IdentityVerification.Application.Common.Identities.Services;

public interface IPasswordHesherService
{
    string HeshPassword(string password);

    bool ValidatePassword(string password, string hashedPassword);
}