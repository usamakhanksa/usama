using Domain.Common;

namespace Domain.Localization;

public class Language : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Code { get; set; } = "en";
    public string Name { get; set; } = "English";
}

public class TranslationKey : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
}

public class Translation : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid LanguageId { get; set; }
    public Guid TranslationKeyId { get; set; }
    public string Value { get; set; } = string.Empty;
}
