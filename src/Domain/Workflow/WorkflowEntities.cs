using Domain.Common;

namespace Domain.Workflow;

public class ApprovalWorkflow : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Name { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
}

public class ApprovalStep : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid WorkflowId { get; set; }
    public int Order { get; set; }
    public string ApproverType { get; set; } = "role";
}

public class ApprovalAssignment : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid StepId { get; set; }
    public Guid ApproverUserId { get; set; }
}

public class ApprovalHistory : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid AssignmentId { get; set; }
    public string Decision { get; set; } = "pending";
    public string? Comment { get; set; }
}
