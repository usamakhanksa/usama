using Domain.Common;

namespace Domain.Tenant;

public class Tenant : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}

public class TenantSettings : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string DefaultLanguage { get; set; } = "en";
    public string DefaultCurrency { get; set; } = "USD";
    public string TimeZone { get; set; } = "UTC";
}

public class TenantDomain : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Domain { get; set; } = string.Empty;
    public bool Verified { get; set; }
}

public class TenantSubscription : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid PlanId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public string Status { get; set; } = "active";
}
