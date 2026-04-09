namespace Application.DTOs;

public record EmployeeDto(Guid Id, string EmployeeNumber, string FirstName, string LastName, string Email, string EmploymentType, string Status);
public record CreateEmployeeDto(string EmployeeNumber, string FirstName, string LastName, string Email, string EmploymentType);
public record UpdateEmployeeDto(string FirstName, string LastName, string Email, string EmploymentType, string Status);
