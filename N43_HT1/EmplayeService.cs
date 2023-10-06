using System.Text;

namespace N43_HT1;

public class EmplayeService
{
    public class EmployeeService
    {
        private readonly UserService _userService;

        public EmployeeService(UserService userService)
        {
            _userService = userService;
        }

        public async Task CreatePerformanceRecordAsync(int id)
        {
            // Get the user's full name.
            var user = _userService.Users.FirstOrDefault(u => u.Id == id);
            var fullName = user.FirstName + " " + user.LastName;

            // Create the file path.
            var filePath = Path.Combine(Path.GetTempPath(), fullName + ".txt");

            // Create the file.
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Write the user's full name to the file.
                var bytes = Encoding.UTF8.GetBytes(fullName);
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }

}
