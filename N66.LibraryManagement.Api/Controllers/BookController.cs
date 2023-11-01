using Microsoft.AspNetCore.Mvc;
using N66.LibraryManagement.Application.Services;
using N66.LibraryManagement.Domin.Entities.Models;

namespace N66.LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IEntityBaseService<Book> _entityBaseService;

    public BookController(IEntityBaseService<Book> entityBaseService)
    {
        _entityBaseService = entityBaseService;
    }

    [HttpPost("books")]
    public async Task<IActionResult> Create([FromBody] Book book)
        => Ok(await _entityBaseService.CreateAsync(book, true));

    [HttpGet("books/bookId:guid")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
      => Ok(await _entityBaseService.GetByIdAsync(id));

    [HttpPut("books")]
    public async Task<IActionResult> Update([FromBody] Book book)
    {
        Ok(await _entityBaseService.UpdateAsync(book, true));
        return NoContent();
    }

    [HttpDelete("books/bookId:guid")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Ok(await _entityBaseService.DeleteByIdAsync(id, true));
        return NoContent();
    }
}
