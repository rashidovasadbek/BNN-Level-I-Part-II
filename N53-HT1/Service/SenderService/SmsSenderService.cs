using N53_HT1.Model.Entities;
using N53_HT1.Service.Interface;

namespace N53_HT1.Service.SenderService
{
    public class SmsSenderService : INotificatoinService
    {
        public ValueTask<bool> SendNotificationAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
