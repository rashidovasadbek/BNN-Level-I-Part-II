using Microsoft.AspNetCore.Mvc;
using N65.IdentityVerification.Application.Common.Identities.Services;

namespace N65.IdentityVerificatoin.Api.Contollers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {
        var result = await _accountService.VerificateAsync(token);
        return Ok(result);
    }
}
