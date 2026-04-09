using Domain.Common;

namespace Domain.Notifications;

public class Notification : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Channel { get; set; } = "in-app";
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}

public class UserNotification : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
    public bool IsRead { get; set; }
}

public class NotificationTemplate : BaseEntity, IAuditableEntity, ITenantScoped, ISoftDeletable
{
    public string Key { get; set; } = string.Empty;
    public string SubjectTemplate { get; set; } = string.Empty;
    public string BodyTemplate { get; set; } = string.Empty;
}
