using Microsoft.AspNetCore.Mvc;
using N58_HT1.Application.Services;

namespace N58_HT1.Controller;

[ApiController]
[Route("api/[controller]")]
public class EntriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;

    public EntriesController(IDirectoryProcessingService directoryProcessingService)
    {
        _directoryProcessingService = directoryProcessingService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromServices] IWebHostEnvironment webHostEnvironment)
    {
        var data = await _directoryProcessingService.GetStorageEntriesAsync(webHostEnvironment.WebRootPath);
        return data.Any() ? Ok(data) : NotFound(); 
    }  
}
