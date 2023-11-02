using N65.IdentityVerification.Application.Common.Enums;
using N65.IdentityVerification.Application.Common.Identities.Models;

namespace N65.IdentityVerification.Application.Common.Identities.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}