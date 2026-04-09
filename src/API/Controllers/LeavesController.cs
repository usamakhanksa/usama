using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/leaves")]
public class LeavesController : ControllerBase
{
    [HttpPost("apply")]
    public IActionResult Apply() => Ok(new { message = "Leave application submitted" });

    [HttpPost("approve")]
    public IActionResult Approve() => Ok(new { message = "Leave approved" });

    [HttpGet("my")]
    public IActionResult My() => Ok(Array.Empty<object>());
}
