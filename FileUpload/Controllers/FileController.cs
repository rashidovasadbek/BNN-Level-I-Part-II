using FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.FileController;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] Stream stream, Guid userId)
    { 
        return Ok(await _fileService.UploadFileAsync(stream, "file", userId));
    }
}
