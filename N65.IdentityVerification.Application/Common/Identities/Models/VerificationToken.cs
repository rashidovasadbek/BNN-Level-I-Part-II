using N65.IdentityVerification.Application.Common.Enums;

namespace N65.IdentityVerification.Application.Common.Identities.Models;

public class VerificationToken
{
    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset? ExpiryTime { get; set; }
}