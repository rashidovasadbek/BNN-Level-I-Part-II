using Microsoft.AspNetCore.Mvc;
using N59_HT1.Application.FileStorage.Brokers;

namespace N59_HT1.Controller;

[ApiController]
[Route("api/[controller]")]
public class DriveController : ControllerBase
{
    [HttpGet]
    public ValueTask<IActionResult> GetAsync([FromServices] IDriveBroker driveBroker)
    {
        var result = driveBroker.Get();
        return new ValueTask<IActionResult>(Ok(result));
    }
}
