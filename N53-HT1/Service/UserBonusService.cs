using N53_HT1.Event;
using N53_HT1.Model.Entities;
using N53_HT1.Service.Interface;

namespace N53_HT1.Service
{
    public class UserBonusService
    {
        private readonly BonusEventStore _bonusEventStore;
        private readonly OrderEventStore _orderEventStore;
        private readonly IEnumerable<INotificatoinService> _notificatoinServices;
        private readonly UserService _userService;
        private readonly BonusService _bonusService;
        private readonly OrderService _orderService;

        public UserBonusService(
            BonusEventStore bonusEventStore,
            OrderEventStore orderEventStore, 
            IEnumerable<INotificatoinService> notificatoinServices,
            UserService userService,
            BonusService bonusService,
            OrderService orderService)
        {
            _bonusEventStore = bonusEventStore;
            _orderEventStore = orderEventStore;
            _notificatoinServices = notificatoinServices;
            _userService = userService;
            _bonusService = bonusService;
            _orderService = orderService;
        }

        private async ValueTask HandleOrderCreatedEvent(Order order, Bonus bonus, User user)
        {
            var tempBonus = bonus.Amount + order.orderSum;
            int countTempBonus = 0;
            int countBonus = 0;
            while(tempBonus > 0)
            {
                tempBonus /= 10;
                countTempBonus++;
                
                bonus.Amount /= 10;
                countBonus++;
            }
            if(countTempBonus > countBonus)
            {
               await BonusAchievedEvent(bonus);
            }
            else
            {
                var result = _notificatoinServices.FirstOrDefault();
            }

        }

        private async ValueTask BonusAchievedEvent(Bonus bonus)
        {
            return;
        }



    }
}
