using N48_HT1.Models;

namespace N48_HT1.Services.Interfaces
{
    public interface IOrdersOfUsers
    {
      ValueTask<Order> GetUserOrdersAsync(Guid userId);
    }
}
