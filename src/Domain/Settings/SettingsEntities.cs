using Domain.Common;

namespace Domain.Settings;

public class Setting : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class FeatureFlag : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}

public class TenantFeature : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}
