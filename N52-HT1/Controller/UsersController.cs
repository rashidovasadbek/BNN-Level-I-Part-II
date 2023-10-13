using Microsoft.AspNetCore.Mvc;
using N52_HT1.Model.Entity;
using N52_HT1.Service;

namespace N52_HT1.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AccountService _accountService;

    public UsersController(AccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await _accountService.Create(user);
        return Ok(result);
    }
}
