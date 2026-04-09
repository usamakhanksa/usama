using Domain.Billing;
using Domain.Finance;
using Domain.HRM;
using Domain.Identity;
using Domain.Localization;
using Domain.Notifications;
using Domain.Settings;
using Domain.Tenant;
using Domain.Workflow;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<TenantSettings> TenantSettings => Set<TenantSettings>();
    public DbSet<TenantDomain> TenantDomains => Set<TenantDomain>();
    public DbSet<TenantSubscription> TenantSubscriptions => Set<TenantSubscription>();

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<Language> Languages => Set<Language>();
    public DbSet<TranslationKey> TranslationKeys => Set<TranslationKey>();
    public DbSet<Translation> Translations => Set<Translation>();

    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();

    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();

    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<FeatureFlag> FeatureFlags => Set<FeatureFlag>();
    public DbSet<TenantFeature> TenantFeatures => Set<TenantFeature>();

    public DbSet<ApprovalWorkflow> ApprovalWorkflows => Set<ApprovalWorkflow>();
    public DbSet<ApprovalStep> ApprovalSteps => Set<ApprovalStep>();
    public DbSet<ApprovalAssignment> ApprovalAssignments => Set<ApprovalAssignment>();
    public DbSet<ApprovalHistory> ApprovalHistory => Set<ApprovalHistory>();

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<PayrollRun> PayrollRuns => Set<PayrollRun>();
    public DbSet<Payslip> Payslips => Set<Payslip>();
}
