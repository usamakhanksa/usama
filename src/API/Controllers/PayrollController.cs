using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/payroll")]
public class PayrollController : ControllerBase
{
    [HttpPost("run")]
    public IActionResult Run() => Ok(new { message = "Payroll run queued" });

    [HttpGet("payslip/{employeeId:guid}")]
    public IActionResult Payslip(Guid employeeId) => Ok(new { employeeId, netSalary = 0 });
}
