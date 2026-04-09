using Domain.Common;

namespace Domain.Billing;

public class Plan : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Name { get; set; } = string.Empty;
    public decimal MonthlyPrice { get; set; }
    public decimal YearlyPrice { get; set; }
}

public class Subscription : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid PlanId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public string Status { get; set; } = "active";
}

public class Invoice : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid SubscriptionId { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = "USD";
    public string Status { get; set; } = "pending";
}

public class Payment : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "initiated";
}
