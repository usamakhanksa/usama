using Domain.Common;

namespace Domain.HRM;

public class Department : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public Guid? ParentDepartmentId { get; set; } }
public class Designation : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public int Level { get; set; } }
public class Branch : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public string Country { get; set; } = string.Empty; public string Address { get; set; } = string.Empty; }
public class CostCenter : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }

public class Employee : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string EmployeeNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EmploymentType { get; set; } = "full-time";
    public string Status { get; set; } = "active";
}

public class AttendanceRecord : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public DateTime Date { get; set; } public string Status { get; set; } = "present"; }
public class LeaveRequest : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid LeaveTypeId { get; set; } public DateTime StartDate { get; set; } public DateTime EndDate { get; set; } public string Status { get; set; } = "pending"; }
public class PayrollRun : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid PayrollPeriodId { get; set; } public string Status { get; set; } = "draft"; }
public class Payslip : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal NetSalary { get; set; } }
public class JobOpening : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Title { get; set; } = string.Empty; public string Status { get; set; } = "open"; }
public class Candidate : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string FirstName { get; set; } = string.Empty; public string LastName { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; }
public class PerformanceReview : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid ReviewerId { get; set; } public int Score { get; set; } }
public class EmployeeDocument : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public string DocumentType { get; set; } = string.Empty; public Guid FileId { get; set; } }
