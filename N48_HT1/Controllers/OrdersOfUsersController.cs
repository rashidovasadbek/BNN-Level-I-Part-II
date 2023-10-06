using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersOfUsersController : Controller
    {
        private readonly IOrdersOfUsers _ordersOfUsers;
        public OrdersOfUsersController(IOrdersOfUsers ordersOfUsers)
        {
            _ordersOfUsers = ordersOfUsers;
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<IActionResult> GetByIdAsync([FromRoute] Guid userId)
        {
            var result = await _ordersOfUsers.GetUserOrdersAsync(userId);
            return Ok(result);
        }
    }
}
