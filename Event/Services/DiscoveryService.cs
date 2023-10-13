using Event.Events;
using Event.Models.Entities;

namespace Event.Services
{
    public class DiscoveryService
    {
        private readonly PostEventStore _postEventStore;
        private readonly UserPreferenceService _userPreferenceService;
        private readonly UserService _userService;

        public DiscoveryService(PostEventStore postEventStore, UserPreferenceService userPreferenceService, UserService userService)
        {
            _postEventStore = postEventStore;
            _userPreferenceService = userPreferenceService;
            _userService = userService;

            _postEventStore.OnPostCreated += HandlePostCreatedEventAsync; 
        }

        
        public ValueTask HandlePostCreatedEventAsync(BlogPost blogPost)
        {
            var matchedUserQuery = from preference in _userPreferenceService.Get(x => true)
            join user in _userService.Get(y => true) on preference.UserId equals user.Id
            where preference.LinkedTopics.Any(topic => blogPost.Topic.Contains(topic)) 
            select user;

            var matchedUsers = matchedUserQuery.ToList();

            foreach (var user in matchedUsers)
                Console.WriteLine($"Notifiying user - {user.UserName} about the post - {blogPost.Title} with topic - {blogPost.Topic}");
            
            return ValueTask.CompletedTask;
        }
    }
}
