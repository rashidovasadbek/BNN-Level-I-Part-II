using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N65.IdentityVerification.Application.Common.Enums;
using N65.IdentityVerification.Application.Common.Identities.Models;
using N65.IdentityVerification.Application.Common.Identities.Services;
using N65.IdentityVerification.Application.Common.Settings;
using Newtonsoft.Json;

namespace N65.IdentityVerification.Infrastructure.Common.Identity.Services;

public class VerificationTokenGenratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _dataProtector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGenratorService(
        IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtector dataProtectorProvider)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector = dataProtectorProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };
        return _dataProtector.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public (VerificationToken Token, bool IsValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var unprotectedToken = _dataProtector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) ??
                                throw new ArgumentException("Invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}