using FileBaseContext.Abstractions.Models.Entity;

namespace Event.Models.Entities
{
    public interface IEntity : IFileSetEntity<Guid>
    {
    }
}
