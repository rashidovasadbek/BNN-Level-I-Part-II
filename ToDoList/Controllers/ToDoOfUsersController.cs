using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[COntroller]")]
    public class ToDoOfUsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IToDoService _toDoService;

        public ToDoOfUsersController(IUserService userService, IToDoService toDoService)
        {
            _userService = userService;
            _toDoService = toDoService;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.Get(user =>  true).ToList();
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("users/userId:guid")]
        public async Task<IActionResult> GetByUserId(Guid id)
            => Ok(await _userService.GetByIdAsync(id));
        
        [HttpPost("user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
            => Ok(await _userService.CreateAsync(user));

        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
            => Ok(await _userService.UpdateAsync(user));

        [HttpDelete("user/{userId:guid}")]

        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            Ok(await _userService.DeleteAsync(userId));
            return NoContent();
        }


        [HttpGet("ToDos")]
        public IActionResult GetAllToDos()
        {
            var users = _toDoService.Get(user => true).ToList();
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("ToDos/toDos:guid")]
        public async Task<IActionResult> GetByToDoId(Guid id)
            => Ok(await _toDoService.GetByIdAsync(id));

        [HttpPost("ToDo")]
        public async Task<IActionResult> AddToDo([FromBody] ToDo toDo)
            => Ok(await _toDoService.CreateAsync(toDo));

        [HttpPut("ToDo")]
        public async Task<IActionResult> UpdateToDo([FromBody] ToDo toDo)
            => Ok(await _toDoService.UpdateAsync(toDo));
        
        [HttpDelete("ToDo/{toDoId:guid}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] Guid toDoId)
        {
            Ok(await _toDoService.DeleteAsync(toDoId));
            return NoContent();
        }
    }
}
