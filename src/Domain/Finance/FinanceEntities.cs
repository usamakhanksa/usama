using Domain.Common;

namespace Domain.Finance;

public class Currency : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Code { get; set; } = "USD";
    public string Symbol { get; set; } = "$";
    public int DecimalPlaces { get; set; } = 2;
}

public class ExchangeRate : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid BaseCurrencyId { get; set; }
    public Guid TargetCurrencyId { get; set; }
    public decimal Rate { get; set; }
    public DateTime Date { get; set; }
}

public record Money(decimal Amount, string CurrencyCode);
