using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register() => Ok(new { message = "Registration endpoint scaffolded" });

    [HttpPost("login")]
    public IActionResult Login() => Ok(new { accessToken = "stub", refreshToken = "stub" });

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken() => Ok(new { accessToken = "stub", refreshToken = "stub" });

    [HttpPost("password-reset/request")]
    public IActionResult PasswordResetRequest() => Ok(new { message = "Password reset request queued" });

    [HttpPost("password-reset/confirm")]
    public IActionResult PasswordResetConfirm() => Ok(new { message = "Password reset confirmed" });

    [HttpPost("verify-email")]
    public IActionResult VerifyEmail() => Ok(new { message = "Email verified" });
}
