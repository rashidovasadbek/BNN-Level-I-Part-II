using FileUpload.Models.DTOs;

namespace FileUpload.Services.Interfaces;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);
    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}
