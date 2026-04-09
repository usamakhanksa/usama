using Domain.Common;

namespace Domain.HRM;

// Organization
public class Department : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public Guid? ParentDepartmentId { get; set; } public Guid? ManagerId { get; set; } }
public class Designation : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public int Level { get; set; } }
public class Branch : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public string Country { get; set; } = string.Empty; public string Address { get; set; } = string.Empty; }
public class CostCenter : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }

// Employee Management
public class Employee : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string EmployeeNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
    public string EmploymentType { get; set; } = "full-time";
    public string Status { get; set; } = "active";
    public Guid? DepartmentId { get; set; }
    public Guid? DesignationId { get; set; }
    public Guid? ManagerId { get; set; }
    public Guid? BranchId { get; set; }
}
public class EmployeeContact : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public string Type { get; set; } = string.Empty; public string Value { get; set; } = string.Empty; }
public class EmployeeDependent : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public string Name { get; set; } = string.Empty; public string Relationship { get; set; } = string.Empty; }
public class EmployeeEmergencyContact : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public string Name { get; set; } = string.Empty; public string Phone { get; set; } = string.Empty; }
public class EmployeeBankAccount : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public string BankName { get; set; } = string.Empty; public string AccountNumber { get; set; } = string.Empty; }
public class EmployeeDocument : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid DocumentTypeId { get; set; } public Guid FileId { get; set; } }
public class DocumentType : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }

// Attendance
public class AttendanceRecord : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public DateTime Date { get; set; } public DateTime? CheckInTime { get; set; } public DateTime? CheckOutTime { get; set; } public decimal TotalHours { get; set; } public string Status { get; set; } = "present"; }
public class AttendancePolicy : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }
public class Shift : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public TimeSpan StartTime { get; set; } public TimeSpan EndTime { get; set; } }
public class ShiftAssignment : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid ShiftId { get; set; } public DateTime EffectiveFrom { get; set; } }
public class Timesheet : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public DateTime WeekStartDate { get; set; } }

// Leave
public class LeaveType : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public int AnnualAllocation { get; set; } }
public class LeaveBalance : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid LeaveTypeId { get; set; } public decimal Balance { get; set; } }
public class LeaveRequest : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid LeaveTypeId { get; set; } public DateTime StartDate { get; set; } public DateTime EndDate { get; set; } public string Reason { get; set; } = string.Empty; public string Status { get; set; } = "pending"; }
public class LeaveApproval : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid LeaveRequestId { get; set; } public Guid ApproverId { get; set; } public string Status { get; set; } = "pending"; }
public class HolidayCalendar : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }
public class Holiday : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid HolidayCalendarId { get; set; } public DateTime Date { get; set; } public string Name { get; set; } = string.Empty; }

// Payroll
public class PayrollPeriod : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public DateTime StartDate { get; set; } public DateTime EndDate { get; set; } }
public class SalaryStructure : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }
public class SalaryComponent : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public string Type { get; set; } = "earning"; }
public class EmployeeSalary : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid CurrencyId { get; set; } public decimal BasicSalary { get; set; } public DateTime EffectiveFrom { get; set; } }
public class PayrollRun : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid PayrollPeriodId { get; set; } public string Status { get; set; } = "draft"; }
public class Payslip : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid PayrollPeriodId { get; set; } public decimal GrossSalary { get; set; } public decimal TotalDeductions { get; set; } public decimal NetSalary { get; set; } }
public class PayrollAdjustment : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } public string Reason { get; set; } = string.Empty; }
public class Bonus : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } }
public class Deduction : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } }

// Compensation & Benefits
public class Benefit : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; }
public class EmployeeBenefit : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid BenefitId { get; set; } }
public class Allowance : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } }
public class Reimbursement : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } }
public class Claim : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public decimal Amount { get; set; } public string Status { get; set; } = "pending"; }

// Recruitment
public class JobOpening : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Title { get; set; } = string.Empty; public Guid DepartmentId { get; set; } public string EmploymentType { get; set; } = string.Empty; public string Description { get; set; } = string.Empty; public string Status { get; set; } = "open"; }
public class Candidate : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string FirstName { get; set; } = string.Empty; public string LastName { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; public string Phone { get; set; } = string.Empty; public Guid? ResumeFileId { get; set; } }
public class Application : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid CandidateId { get; set; } public Guid JobOpeningId { get; set; } public string Status { get; set; } = "applied"; }
public class Interview : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid ApplicationId { get; set; } public DateTime ScheduledAt { get; set; } }
public class OfferLetter : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid ApplicationId { get; set; } public decimal OfferedSalary { get; set; } }

// Performance
public class Goal : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Title { get; set; } = string.Empty; }
public class EmployeeGoal : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid GoalId { get; set; } }
public class PerformanceReview : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid ReviewerId { get; set; } public int Score { get; set; } public string Comments { get; set; } = string.Empty; public string ReviewPeriod { get; set; } = string.Empty; }
public class ReviewCycle : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public string Name { get; set; } = string.Empty; public DateTime StartDate { get; set; } public DateTime EndDate { get; set; } }
public class Rating : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid PerformanceReviewId { get; set; } public int Value { get; set; } }
public class Feedback : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable { public Guid EmployeeId { get; set; } public Guid FromUserId { get; set; } public string Comment { get; set; } = string.Empty; }
