using System.Text;

namespace N43_HT1;

public class PerformanceService
{
    private readonly UserService _userService;

    public PerformanceService(UserService userService)
    {
        _userService = userService; 
    }
    public async Task ReportPerformanceAsync(int id)
    {
        // Get the user's full name.
        var user =_userService.Users.FirstOrDefault(u => u.Id == id);
        var fullName = user.FirstName + " " + user.LastName;

        // Create the file path.
        var filePath = Path.Combine(Path.GetTempPath(), fullName + ".txt");

        // Open the file for writing.
        using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            // Write "All good :)" to the file.
            var bytes = Encoding.UTF8.GetBytes("All good :)");
            await fileStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
