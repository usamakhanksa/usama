using Application.Common;

namespace API.Middleware;

public class TenantResolutionMiddleware
{
    private readonly RequestDelegate _next;

    public TenantResolutionMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context, ScopedTenantContext tenantContext)
    {
        var tenantFromHeader = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();

        if (!string.IsNullOrWhiteSpace(tenantFromHeader) && Guid.TryParse(tenantFromHeader, out var tenantId))
        {
            tenantContext.SetTenant(tenantId, context.Request.Headers["X-Tenant-Code"].FirstOrDefault());
        }

        await _next(context);
    }
}

public class ScopedTenantContext : ITenantContext
{
    public Guid TenantId { get; private set; }
    public string? TenantCode { get; private set; }

    public void SetTenant(Guid tenantId, string? code)
    {
        TenantId = tenantId;
        TenantCode = code;
    }
}
