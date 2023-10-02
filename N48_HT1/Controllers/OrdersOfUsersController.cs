using Microsoft.AspNetCore.Mvc;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersOfUsersController
    {
        private readonly IOrdersOfUsers _ordersOfUsers;
        public OrdersOfUsersController(IOrdersOfUsers ordersOfUsers)
        {
            _ordersOfUsers = ordersOfUsers;
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
        {
          /*  var result = await _ordersOfUsers.GetByIdAsync(userId);
            return result is not null ? Ok(result) : NotFound();*/
        }
    }
}
