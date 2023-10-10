using System.Linq.Expressions;
using ToDoList.Models;
using ToDoList.Services.Interface;
using ToDoList.DataAccsess;
using Microsoft.VisualBasic;

namespace ToDoList.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext _appDataContext;

        public UserService(IDataContext dataContext)
        {
            _appDataContext = dataContext;
        }
        public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if(!ValidationToNull(user))
                throw new ArgumentNullException("This user members is null");

            if (ValidationExists(user))
                throw new ArgumentException("This user is Alarady Exists");

            await _appDataContext.Users.AddAsync(user,cancellationToken);

            if(saveChanges)
                await _appDataContext.Users.SaveChangesAsync();

            return user;
        }
        
        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return GetUndeletedUsers().Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var users = _appDataContext.Users.Where(user => ids.Contains(user.Id)); 
            return new ValueTask<ICollection<User>>(users.ToList());
        }

        public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = GetUndeletedUsers().FirstOrDefault(user => user.Id == id);
            if (user is null)
                throw new ArgumentOutOfRangeException("User not found");
           
            return new ValueTask<User?>(user);
        }

        public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if(!ValidationToNull(user))
                throw new ArgumentNullException("This a member of these user null");

            var foundUser =  await GetByIdAsync(user.Id, cancellationToken);

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.Email = user.Email;
            foundUser.Password = user.Password;

            await _appDataContext.Users.UpdateAsync(foundUser,cancellationToken);

            if(saveChanges) await _appDataContext.SaveChangesAsync();
            
            return foundUser;

        }
       
        public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundUser = GetUndeletedUsers().FirstOrDefault(user => user.Id == id);
            
            if (foundUser is null)
                throw new InvalidOperationException("user not found");

            await _appDataContext.Users.RemoveAsync(foundUser,cancellationToken);
            await _appDataContext.SaveChangesAsync();
            
            return foundUser;
        }

        public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
         => await DeleteAsync(user.Id, saveChanges, cancellationToken);

        //validation methods
        private bool ValidationToNull(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) 
                || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                return false;
           
            return true;         
        }
        private bool ValidationExists(User user)
        {
            var foundUsers = GetUndeletedUsers().FirstOrDefault(serach => serach.Equals(user));

            if(foundUsers is null)
                return false;

            return true;
        }
        private IQueryable<User> GetUndeletedUsers() 
            => _appDataContext.Users.Where(user => !user.IsDeleted).AsQueryable();
    }
}
