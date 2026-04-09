using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login() => Ok(new { accessToken = "stub", refreshToken = "stub" });

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken() => Ok(new { accessToken = "stub", refreshToken = "stub" });
}
