using Event.DataAccsess;
using Event.Events;
using Event.Models.Entities;

namespace Event.Services
{
    public class PostService
    {
        private readonly AppFileContext _dataContext;
        private readonly PostEventStore _postEventStore;

        public PostService(AppFileContext appFileContext, PostEventStore postEventStore)
        {
            _dataContext = appFileContext;
            _postEventStore = postEventStore;
        }

        public async ValueTask<BlogPost> Create(BlogPost blogPost)
        {
            await _dataContext.BlogPosts.AddAsync(blogPost);
            await _dataContext.SaveChangesAsync();
            await _postEventStore.CreatedPostAddedEventAsync(blogPost);

            return blogPost;
        }
        
    }
}
