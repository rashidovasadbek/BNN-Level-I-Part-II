using Demo.DTO;
using Demo.DTOs;
using Demo.Models;

namespace Demo.Services;

public interface IUserService
{
    ValueTask<UserViewModel?> GetByIdAsync(Guid id);

    ValueTask<User> CreateAsync(UserForCreation user, bool saveChanges = true);
}
