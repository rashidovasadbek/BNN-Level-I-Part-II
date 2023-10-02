using FileBaseContext.Abstractions.Models.Entity;

namespace N48_HT1.Models
{
    public class User : IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }   
        public string password { get; set; }

    }
}
