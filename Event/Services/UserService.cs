using Event.DataAccsess;
using Event.Models.Entities;
using System.Linq.Expressions;

namespace Event.Services
{
    public class UserService
    {
        private readonly AppFileContext _dataContext;

        public UserService(AppFileContext appFileContext)
        {
            _dataContext = appFileContext;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> pridicate) 
        {
            return _dataContext.Users.Where(pridicate.Compile()).AsQueryable();
        }
    }
}
