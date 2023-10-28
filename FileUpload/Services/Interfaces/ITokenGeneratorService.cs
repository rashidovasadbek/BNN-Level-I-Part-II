using N63.Identity.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FileUpload.Services.Interfaces;

public interface ITokenGeneratorService
{
    string GetToken(User user);
    JwtSecurityToken GetJwtToken(User user);
    List<Claim> GetClaims(User user);
}