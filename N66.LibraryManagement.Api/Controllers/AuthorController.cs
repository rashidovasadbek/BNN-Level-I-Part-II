using Microsoft.AspNetCore.Mvc;
using N66.LibraryManagement.Application.Services;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IEntityBaseService<Author> _entityBaseService;

    public AuthorController(IEntityBaseService<Author> entityBaseService)
    {
        _entityBaseService = entityBaseService;
    }

    [HttpPost("authors")]
    public async Task<IActionResult> CreateAsync([FromBody] Author author)
    {
       var createdAuthor = await _entityBaseService.CreateAsync(author,true);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpGet("authers/auhterId:guid")]
    public async Task<IActionResult> GetByIdAsync(Guid authorId)
      => Ok(await _entityBaseService.GetByIdAsync(authorId));
    
    [HttpPut("auhters")]
    public async Task<IActionResult> Update([FromBody] Author author)
    {
        Ok(await _entityBaseService.UpdateAsync(author,true));
        return NoContent();
    }

    [HttpDelete("authers/auhterId:guid")]
    public async Task<IActionResult> Delete( Guid authorId)
    {
        Ok(await _entityBaseService.DeleteByIdAsync(authorId, true));
        return NoContent();
    }
}