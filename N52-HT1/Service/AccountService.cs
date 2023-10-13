using N52_HT1.DataAccsess;
using N52_HT1.Event;
using N52_HT1.Model.Entity;

namespace N52_HT1.Service
{
    public class AccountService
    {
        private readonly AppFileContext _appDataContext;
        private readonly AccountEventStore _accountEventStore;

        public AccountService(AppFileContext appFileContext, AccountEventStore accountEventStore)
        {
            _appDataContext = appFileContext;
            _accountEventStore = accountEventStore;
        }

        public async ValueTask<User> Create(User user)
        {
            await _appDataContext.Users.AddAsync(user);
            await _appDataContext.SaveChangesAsync();
            await _accountEventStore.CreateUserAddedEventAsync(user);

            return user;
        }
    }
}