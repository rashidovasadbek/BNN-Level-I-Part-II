using N56__HT1.Models;

namespace N56__HT1.Services.Interfaces;

public interface ICleanUpService
{
     ValueTask<List<string>> CleanUpfile(User user);
}
