using Domain.Common;

namespace Domain.Identity;

public class User : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool EmailVerified { get; set; }
}

public class Role : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Name { get; set; } = string.Empty;
}

public class Permission : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
}

public class UserRole : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}

public class RolePermission : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
}
