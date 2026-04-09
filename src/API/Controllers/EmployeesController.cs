using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeesController(IEmployeeService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetAll(CancellationToken cancellationToken)
        => Ok(await _service.GetAllAsync(cancellationToken));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EmployeeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _service.GetByIdAsync(id, cancellationToken);
        return employee is null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeDto input, CancellationToken cancellationToken)
    {
        var created = await _service.CreateAsync(input, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1" }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<EmployeeDto>> Update(Guid id, [FromBody] UpdateEmployeeDto input, CancellationToken cancellationToken)
    {
        var updated = await _service.UpdateAsync(id, input, cancellationToken);
        return updated is null ? NotFound() : Ok(updated);
    }
}
