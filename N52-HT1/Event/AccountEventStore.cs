using N52_HT1.DataAccsess;
using N52_HT1.Model.Entity;

namespace N52_HT1.Event
{
    public class AccountEventStore
    {
        public event Func<User, ValueTask>? OnUserCreated;

        public async ValueTask CreateUserAddedEventAsync(User user)
        {
            if(OnUserCreated != null)
                await OnUserCreated(user);
        }

    }
}
