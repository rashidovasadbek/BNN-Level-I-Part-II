using FileBaseContext.Abstractions.Models.Entity;

namespace ToDoList.Models
{
    public class User : IFileSetEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
        
    }
}
