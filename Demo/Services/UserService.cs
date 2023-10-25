using Demo.DataAccsees;
using Demo.DTO;
using Demo.DTOs;
using Demo.Models;
using Mapster;

namespace Demo.Services;

public class UserService : IUserService
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async ValueTask<User> CreateAsync(UserForCreation userForCreation, bool saveChanges = true)
    {
        var existUser = _dataContext.Users.FirstOrDefault(u => u.Email.Equals(userForCreation.Email));
      
        var newUser = userForCreation.Adapt<User>();

        newUser.CreatedAt = DateTime.UtcNow;
        newUser.UpdatedAt = DateTime.UtcNow;

        await _dataContext.Users.AddAsync(newUser);

        if (saveChanges) 
            await _dataContext.SaveChangesAsync();

        return newUser;
    }

  /*  public async ValueTask<UserViewModel?> GetByIdAsync(Guid id)
    {
        var result = _dataContext.Users.Adapt<List<UserViewModel>>();
         
    }*/
}