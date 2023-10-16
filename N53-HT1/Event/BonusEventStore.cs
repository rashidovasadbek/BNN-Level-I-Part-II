using N53_HT1.Model.Entities;

namespace N53_HT1.Event
{
    public class BonusEventStore
    {
        public event Func<Bonus, ValueTask> OnBonusCreated;

        public async ValueTask BonusAchievedEventAsync(Bonus bonus)
        {
            if(OnBonusCreated != null)
                await OnBonusCreated(bonus);
        }
    }
}
