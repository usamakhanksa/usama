using Domain.Common;

namespace Domain.Billing;

public class Plan : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Name { get; set; } = string.Empty;
    public decimal MonthlyPrice { get; set; }
    public decimal YearlyPrice { get; set; }
    public int TrialDays { get; set; } = 14;
}

public class Subscription : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid PlanId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public string Status { get; set; } = "active";
    public string BillingCycle { get; set; } = "monthly";
}

public class Invoice : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid SubscriptionId { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = "USD";
    public string Status { get; set; } = "pending";
    public DateTime DueDate { get; set; }
}

public class InvoiceItem : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid InvoiceId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

public class Payment : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid InvoiceId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "initiated";
}

public class PaymentMethod : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid UserId { get; set; }
    public string Type { get; set; } = "card";
    public string Last4 { get; set; } = string.Empty;
}
    public decimal Amount { get; set; }
    public string Status { get; set; } = "initiated";
}
