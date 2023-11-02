using N65.IdentityVerification.Domin.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace N65.IdentityVerification.Application.Common.Identities.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);
}
