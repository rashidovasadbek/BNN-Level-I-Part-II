using N48_HT1.Models;
using N48_HT1.Services.Interfaces;

namespace N48_HT1.Services
{
    public class OrdersOfUsers : IOrdersOfUsers
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public OrdersOfUsers(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public async ValueTask<Order> GetUserOrdersAsync(Guid userId)
        {   
            var orders = await _orderService.GetByIdAsync(userId);
            if (orders == null)
                throw new Exception("orders not found");
            return orders;
        }
    }
}
