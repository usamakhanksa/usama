using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.HRM;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employees;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public EmployeeService(IRepository<Employee> employees, IUnitOfWork unitOfWork, ITenantContext tenantContext)
    {
        _employees = employees;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public Task<IReadOnlyList<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = _employees.Query()
            .Where(x => x.TenantId == _tenantContext.TenantId && !x.IsDeleted)
            .Select(x => new EmployeeDto(x.Id, x.EmployeeNumber, x.FirstName, x.LastName, x.Email, x.EmploymentType, x.Status))
            .ToList();

        return Task.FromResult((IReadOnlyList<EmployeeDto>)list);
    }

    public async Task<EmployeeDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employees.GetByIdAsync(id, cancellationToken);
        if (employee is null || employee.TenantId != _tenantContext.TenantId || employee.IsDeleted) return null;
        return new EmployeeDto(employee.Id, employee.EmployeeNumber, employee.FirstName, employee.LastName, employee.Email, employee.EmploymentType, employee.Status);
    }

    public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input, CancellationToken cancellationToken = default)
    {
        var employee = new Employee
        {
            TenantId = _tenantContext.TenantId,
            EmployeeNumber = input.EmployeeNumber,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            EmploymentType = input.EmploymentType,
            Status = "active"
        };

        await _employees.AddAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new EmployeeDto(employee.Id, employee.EmployeeNumber, employee.FirstName, employee.LastName, employee.Email, employee.EmploymentType, employee.Status);
    }

    public async Task<EmployeeDto?> UpdateAsync(Guid id, UpdateEmployeeDto input, CancellationToken cancellationToken = default)
    {
        var employee = await _employees.GetByIdAsync(id, cancellationToken);
        if (employee is null || employee.TenantId != _tenantContext.TenantId || employee.IsDeleted) return null;

        employee.FirstName = input.FirstName;
        employee.LastName = input.LastName;
        employee.Email = input.Email;
        employee.EmploymentType = input.EmploymentType;
        employee.Status = input.Status;
        employee.ModifiedAt = DateTime.UtcNow;

        _employees.Update(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new EmployeeDto(employee.Id, employee.EmployeeNumber, employee.FirstName, employee.LastName, employee.Email, employee.EmploymentType, employee.Status);
    }
}
