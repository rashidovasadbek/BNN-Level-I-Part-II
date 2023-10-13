using Event.DataAccsess;
using Event.Models.Entities;
using System.Linq.Expressions;

namespace Event.Services
{
    public class UserPreferenceService
    {
        private readonly AppFileContext _dataContext;

        public UserPreferenceService(AppFileContext appFileContext)
        {
            _dataContext = appFileContext;  
        }

        public IQueryable<UserPreference> Get(Expression<Func<UserPreference, bool>> predicate)
        {
            return _dataContext.UserPreferences.Where(predicate.Compile()).AsQueryable();
        }
    }
}
