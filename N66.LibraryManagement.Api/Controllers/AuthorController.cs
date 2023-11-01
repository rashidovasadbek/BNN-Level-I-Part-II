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
    public async Task<IActionResult> Create([FromBody] Author author)
        => Ok(await _entityBaseService.CreateAsync(author,true));

    [HttpGet("authers/auhterId:guid")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
      => Ok(await _entityBaseService.GetByIdAsync(id));
    
    [HttpPut("auhters")]
    public async Task<IActionResult> Update([FromBody] Author author)
    {
        Ok(await _entityBaseService.UpdateAsync(author,true));
        return NoContent();
    }

    [HttpDelete("authers/auhterId:guid")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        Ok(await _entityBaseService.DeleteAsync(id, true));
        return NoContent();
    }
}
