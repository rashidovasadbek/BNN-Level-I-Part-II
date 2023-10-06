using Microsoft.AspNetCore.Mvc;
using N48_HT1.Models;
using N48_HT1.Services;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] int pageToken, [FromQuery] int pageSize, [FromServices] IOrderService orderService) 
        { 
            var result = orderService.Get(order => true).Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
            return result.Any() ? Ok(result) : NotFound();
        }
        [HttpGet("{orderId:guid}")]
        public async ValueTask<IActionResult> GetbyId([FromRoute] Guid orderId)
        {
            var result = await _orderService.GetByIdAsync(orderId);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateOrder([FromBody] Order order)
        {
            var result = await _orderService.CreateAsync(order);
            return CreatedAtAction(nameof(GetbyId), new {userId = result.Id }, result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var result= await _orderService.UpdateAsync(order);
            return Ok(result);
        }
        [HttpDelete("{orderId:guid}")]
        public async ValueTask<IActionResult> DeleteUser([FromRoute] Guid orderId)
        {
            var result  = await _orderService.DeleteAsync(orderId);
            return Ok(result);
        }
    }
}
