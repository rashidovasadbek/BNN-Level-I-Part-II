using Microsoft.AspNetCore.Mvc;
using N63.Identity.Models.Dtos;
using N63.Identity.Services;

namespace N63.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthController _authController;

    public AuthController(AuthController authController)
    {
        _authController = authController;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _authController.Register(registrationDetails);
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = _authController.Login(loginDetails);   
        return Ok(result);
    }
}