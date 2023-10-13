using Event.Models.Entities;
using Event.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpPost]

        public async ValueTask<IActionResult> Create([FromBody] BlogPost blogPost)
        {
            var result = await _postService.Create(blogPost);

            return Ok(result);
        }

    }
}
