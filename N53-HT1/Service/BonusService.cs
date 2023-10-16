using N53_HT1.DataAccsess;
using N53_HT1.Model.Entities;
using System.Linq.Expressions;

namespace N53_HT1.Service
{
    public class BonusService
    {
        private readonly AppFileContext _appDataContext;

        public BonusService(AppFileContext appFileContext)
        {
            _appDataContext = appFileContext;
        }


        public async ValueTask<Bonus> CreateAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (!ValidationToNull(bonus))
                throw new ArgumentNullException("This user members is null");

            if (ValidationExists(bonus))
                throw new ArgumentException("This user is Alarady Exists");

            await _appDataContext.Bonuses.AddAsync(bonus, cancellationToken);

            if (saveChanges)
                await _appDataContext.Bonuses.SaveChangesAsync();

            return bonus;
        }
        public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
        {
            return _appDataContext.Bonuses.Where(predicate.Compile()).AsQueryable();
        }

        private bool ValidationToNull(Bonus bonus)
        {
            if (string.IsNullOrWhiteSpace(bonus.Notes))
                return false;

            return true;
        }
        private bool ValidationExists(Bonus bonus)
        {
            var foundUsers = GetUndeletedUsers().FirstOrDefault(serach => serach.Equals(bonus));

            if (foundUsers is null)
                return false;

            return true;
        }

        private IQueryable<Bonus> GetUndeletedUsers()
            => _appDataContext.Bonuses.Where(bonus => !bonus.IsDeleted).AsQueryable();
    }
}
