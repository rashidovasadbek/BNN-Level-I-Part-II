using FileBaseContext.Abstractions.Models.Entity;
using System.Data;

namespace ToDoList.Models
{
    public class ToDo : IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
