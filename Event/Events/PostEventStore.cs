using Event.Models.Entities;

namespace Event.Events
{
    public class PostEventStore
    {
        public event Func<BlogPost, ValueTask>? OnPostCreated;

        public async ValueTask CreatedPostAddedEventAsync(BlogPost blogPost)
        {
            if (OnPostCreated != null)
                await OnPostCreated(blogPost);
        }
    }
}
