using N53_HT1.Model.Entities;

namespace N53_HT1.Service.Interface
{
    public interface INotificatoinService
    {
        ValueTask<bool> SendNotificationAsync(User user);
    }
}
