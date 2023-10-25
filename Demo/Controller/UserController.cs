using Demo.DTO;
using Demo.DTOs;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controller;

[ApiController]
[Route("api/controller")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService; 
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser([FromBody] UserForCreation userForCreation)
    {
        var result = await _userService.CreateAsync(userForCreation);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromBody]  UserViewModel userViewModel)
    {
        var result = await _userService.GetByIdAsync(userViewModel.Id);
        return Ok(result);
    }
}
