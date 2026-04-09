# Production-Ready SaaS Foundation Blueprint

## 1) Objectives and Non-Goals

### Objectives
- Build a **multi-tenant HRM SaaS** using **Clean Architecture**.
- Keep business rules independent of frameworks and storage.
- Support scale from shared DB to database-per-tenant.
- Provide secure, auditable, queue-driven operations for HR, payroll, and billing.

### Non-Goals (Phase 1)
- Full microservices split (start as modular monolith).
- Multi-region active/active deployment.
- Real-time stream processing beyond queue jobs.

---

## 2) Technology Stack

### Backend
- **Language**: C#
- **Framework**: ASP.NET Core Web API
- **Architecture**: Clean Architecture
- **ORM**: Entity Framework Core (Code-first)
- **Database**: MySQL
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Background Jobs**: Queue-based (Hangfire now, adapter-friendly for RabbitMQ/SQS/Service Bus)
- **Docs**: Swagger/OpenAPI

### Frontend
- **Framework**: Next.js
- **Language**: JavaScript/TypeScript
- **State**: React Query (default) or Redux Toolkit (complex client workflow)
- **UI**: Feature-based modular structure + shared component library

---

## 3) Clean Architecture and Solution Layout

```text
src/
├── Domain/
│   ├── Common/
│   ├── Tenant/
│   ├── Identity/
│   ├── Billing/
│   ├── Localization/
│   ├── Finance/
│   ├── Notifications/
│   ├── Settings/
│   ├── Workflow/
│   └── HRM/
│       ├── Organization/
│       ├── Employee/
│       ├── Attendance/
│       ├── Leave/
│       ├── Payroll/
│       ├── Recruitment/
│       ├── Performance/
│       ├── Compensation/
│       └── Documents/
├── Application/
│   ├── Common/
│   ├── Tenant/
│   ├── Identity/
│   ├── Billing/
│   ├── Localization/
│   ├── Finance/
│   ├── Notifications/
│   ├── Settings/
│   ├── Workflow/
│   └── HRM/
│       ├── DTOs/
│       ├── Interfaces/
│       ├── Services/
│       └── Validators/
├── Infrastructure/
│   ├── Persistence/
│   ├── Identity/
│   ├── Queue/
│   ├── Storage/
│   ├── Email/
│   ├── Caching/
│   ├── Logging/
│   └── Integrations/
└── API/
    ├── Controllers/
    ├── Middleware/
    ├── Filters/
    ├── Versioning/
    └── Health/
```

### Layer Responsibilities
- **Domain**: entities, value objects, domain events, invariants.
- **Application**: use-cases, interfaces, authorization checks, orchestration.
- **Infrastructure**: data access, queue, storage, email, adapters.
- **API**: transport concerns, auth middleware, versioning, docs.

---

## 4) Base Domain Contracts

### Base Entity (required fields)
- `Id`
- `TenantId`
- `CreatedAt`
- `CreatedBy`
- `ModifiedAt`
- `ModifiedBy`
- `IsDeleted`

### Interfaces / markers
- `IAuditableEntity`
- `ISoftDeletable`
- `ITenantScoped`

### Domain rules
- All tenant-owned aggregates MUST implement `ITenantScoped`.
- Global query filters enforce `TenantId == CurrentTenantId && !IsDeleted`.
- SuperAdmin-only aggregates can be tenant-agnostic where explicitly defined.

---

## 5) Required Enterprise Patterns

- **SOLID** across modules and services.
- **Repository pattern** for aggregate persistence abstractions.
- **Unit of Work** for atomic transactions.
- **DTO pattern** at API/Application boundary.
- **Dependency Injection** with modular registration extensions.
- **Global exception middleware** with RFC7807-style responses.
- **API versioning** (`/api/v1`, `/api/v2`).
- **Health checks** for MySQL, queue, storage, and app liveness/readiness.
- **Logging abstraction** and correlation IDs.
- **Code-first migrations** with EF Core.

---

## 6) Multi-Tenancy Design

### Tenant entities
- `Tenant`
- `TenantSettings`
- `TenantDomain`
- `TenantSubscription`

### Tenant resolution order
1. JWT claim (`tenant_id`) for authenticated requests.
2. Header (`X-Tenant-Id`) for service-to-service/integration routes.
3. Tenant domain mapping (`TenantDomain`) when applicable.

### Tenant middleware responsibilities
- Resolve tenant.
- Validate tenant state (active/suspended).
- Place context in `ITenantContext`.
- Reject mismatched tenant access with 403.

### Future database-per-tenant support
- Add `ITenantConnectionResolver`.
- Keep application/domain unchanged.
- Route DbContext connection string by tenant.
- Run per-tenant migrations via scheduled background orchestration.

---

## 7) Localization (Dynamic i18n)

### Entities
- `Languages`
- `TranslationKeys`
- `Translations`

### Structures
- `TranslationKey`: `Id`, `Key`, `Module`
- `Translation`: `Id`, `LanguageId`, `TranslationKeyId`, `Value`

### Language resolution order
1. Request header (e.g. `Accept-Language` or explicit app header)
2. User profile preference
3. Tenant default language
4. System fallback (`en`)

### Capabilities
- Runtime language switching.
- UI translations and entity text translations.
- Cache translations per tenant/language with invalidation on update.

---

## 8) Multi-Currency Design

### Entities
- `Currencies`
- `ExchangeRates`
- `Money` (value object)

### Structures
- `Currency`: `Code`, `Symbol`, `DecimalPlaces`
- `ExchangeRate`: `BaseCurrencyId`, `TargetCurrencyId`, `Rate`, `Date`

### Service contract
- `ICurrencyConverter`
- `Convert(amount, fromCurrency, toCurrency)`

### Rules
- Monetary fields stored with decimal precision config in Fluent API.
- Payroll and billing persist source currency and converted snapshot values.
- Exchange rate source and timestamp must be auditable.

---

## 9) Authentication and Authorization

### Authentication
- JWT access tokens + rotating refresh tokens.
- Features:
  - registration
  - login
  - refresh tokens
  - password reset
  - email verification

### Authorization
- RBAC + permission-based policy checks.
- Entities:
  - `Users`
  - `Roles`
  - `Permissions`
  - `UserRoles`
  - `RolePermissions`

### Baseline roles
- `SuperAdmin`
- `TenantAdmin`
- `HRManager`
- `Manager`
- `Employee`

---

## 10) Subscription and Billing

### Entities
- `Plans`
- `Subscriptions`
- `Invoices`
- `InvoiceItems`
- `Payments`
- `PaymentMethods`

### Features
- Monthly/yearly billing cycles.
- Trial periods.
- Upgrade/downgrade flow.
- Invoice generation.

### Queue workloads
- Renewal reminders.
- Invoice generation.
- Payment retry / dunning process.

---

## 11) Queue-Based Background Processing

### Queue abstractions
- `IQueueService`
- `IBackgroundJob`
- `IEmailQueue`

### Async jobs
- Email sending
- Payroll processing
- Report generation
- Invoice generation
- Notifications dispatch
- Audit log shipping
- Webhook processing

### Adapter strategy
- Default: Hangfire for operational simplicity.
- Optional adapters: RabbitMQ, AWS SQS, Azure Service Bus.

---

## 12) Notification System

### Entities
- `Notifications`
- `UserNotifications`
- `NotificationTemplates`

### Channels
- Email
- In-app
- SMS-ready extension point

### Design notes
- Template rendering in background jobs.
- User delivery preferences per channel.
- Retry + dead-letter handling for failed outbound deliveries.

---

## 13) File Storage Abstraction

### Interface
- `IFileStorageService`
  - `UploadAsync`
  - `DeleteAsync`
  - `GetUrl`

### Storage providers
- Local storage for dev.
- S3-compatible storage for production.

### Entity
- `Files`

### Rules
- Store metadata (tenant, hash, mime type, size, owner).
- Generate signed URLs for secure private file access.

---

## 14) Feature Flags and Settings

### Entities
- `Settings`
- `FeatureFlags`
- `TenantFeatures`

### Examples
- `enable_hrm`
- `enable_payroll`
- `enable_api_access`

### Behavior
- Tenant-specific overrides with global defaults.
- Cached read-through strategy with admin-triggered invalidation.

---

## 15) HRM Modules (Per Tenant)

### 15.1 Organization Structure
Entities:
- `Departments`
- `Designations`
- `Branches`
- `CostCenters`

Examples:
- Department: `Name`, `ParentDepartmentId`, `ManagerId`
- Designation: `Name`, `Level`
- Branch: `Name`, `Country`, `Address`

### 15.2 Employee Management
Entities:
- `Employees`
- `EmployeeContacts`
- `EmployeeDependents`
- `EmployeeEmergencyContacts`
- `EmployeeBankAccounts`
- `EmployeeDocuments`

Employee fields:
- `EmployeeNumber`, `FirstName`, `LastName`, `Email`, `Phone`
- `Gender`, `DateOfBirth`, `HireDate`
- `EmploymentType`, `Status`
- `DepartmentId`, `DesignationId`, `ManagerId`, `BranchId`

Employment types:
- full-time, part-time, contract, intern

Statuses:
- active, probation, resigned, terminated

### 15.3 Attendance Management
Entities:
- `AttendanceRecords`
- `AttendancePolicies`
- `Shifts`
- `ShiftAssignments`
- `Timesheets`

AttendanceRecord fields:
- `EmployeeId`, `Date`, `CheckInTime`, `CheckOutTime`, `TotalHours`, `Status`

Statuses:
- present, absent, late, holiday, weekend

Queue usage:
- attendance calculation
- late notifications

### 15.4 Leave Management
Entities:
- `LeaveTypes`
- `LeaveBalances`
- `LeaveRequests`
- `LeaveApprovals`
- `HolidayCalendars`
- `Holidays`

Leave types:
- annual, sick, unpaid, maternity, emergency

LeaveRequest fields:
- `EmployeeId`, `LeaveTypeId`, `StartDate`, `EndDate`, `Reason`, `Status`

Statuses:
- pending, approved, rejected, cancelled

Queue usage:
- leave balance calculation
- approval notifications

### 15.5 Payroll Module (Multi-Currency)
Entities:
- `PayrollPeriods`
- `SalaryStructures`
- `SalaryComponents`
- `EmployeeSalaries`
- `PayrollRuns`
- `Payslips`
- `PayrollAdjustments`
- `Bonuses`
- `Deductions`

Salary component examples:
- basic, housing, transport, bonus, tax, insurance, deduction

EmployeeSalary fields:
- `EmployeeId`, `CurrencyId`, `BasicSalary`, `EffectiveFrom`

Payslip fields:
- `EmployeeId`, `PayrollPeriodId`, `GrossSalary`, `TotalDeductions`, `NetSalary`

Queue usage:
- payroll processing
- payslip generation
- email payslip

### 15.6 Compensation & Benefits
Entities:
- `Benefits`
- `EmployeeBenefits`
- `Allowances`
- `Reimbursements`
- `Claims`

Examples:
- health insurance
- mobile allowance
- travel allowance

### 15.7 Recruitment Module
Entities:
- `JobOpenings`
- `Candidates`
- `Applications`
- `Interviews`
- `OfferLetters`

JobOpening fields:
- `Title`, `DepartmentId`, `EmploymentType`, `Description`, `Status`

Candidate fields:
- `FirstName`, `LastName`, `Email`, `Phone`, `ResumeFileId`

### 15.8 Performance Management
Entities:
- `Goals`
- `EmployeeGoals`
- `PerformanceReviews`
- `ReviewCycles`
- `Ratings`
- `Feedback`

PerformanceReview fields:
- `EmployeeId`, `ReviewerId`, `Score`, `Comments`, `ReviewPeriod`

### 15.9 Employee Document Management
Entities:
- `EmployeeDocuments`
- `DocumentTypes`

Examples:
- passport
- contract
- certificate
- national id

Storage:
- Document binary lives in `IFileStorageService`, metadata in DB.

### 15.10 Employee Self Service (ESS)
Employees can:
- update profile
- apply leave
- view payslips
- upload documents
- view attendance
- submit claims
- update bank info

---

## 16) Workflow and Approval Engine

### Entities
- `ApprovalWorkflows`
- `ApprovalSteps`
- `ApprovalAssignments`
- `ApprovalHistory`

### Used for
- leave approval
- expense approval
- recruitment approval
- payroll approval

### Engine behavior
- sequential and parallel step support
- dynamic assignee resolution (manager chain / role)
- SLA timers and escalation rules

---

## 17) HR Reporting

### Reports
- headcount report
- payroll summary
- attendance report
- leave balance report
- employee turnover
- department distribution

### Processing model
- report requests are queued
- API returns job ID
- completed report available via secure download URL

---

## 18) API Design Examples

### Employees
- `GET /api/v1/employees`
- `POST /api/v1/employees`
- `PUT /api/v1/employees/{id}`
- `GET /api/v1/employees/{id}`

### Leave
- `POST /api/v1/leaves/apply`
- `POST /api/v1/leaves/approve`
- `GET /api/v1/leaves/my`

### Payroll
- `POST /api/v1/payroll/run`
- `GET /api/v1/payroll/payslip/{employeeId}`

### Auth
- `POST /api/v1/auth/login`
- `POST /api/v1/auth/refresh-token`

---

## 19) EF Core Migrations and Persistence Standards

### Code-first migration commands
```bash
dotnet ef migrations add InitialCreate
dotnet ef migrations add AddHRMModule
dotnet ef database update
```

### Persistence standards
- Configure all entities using `IEntityTypeConfiguration<>`.
- Apply indexes for `TenantId`, foreign keys, and frequent filters.
- Use unique constraints for natural keys where needed.
- Configure precise decimal scales for money columns.
- Use optimistic concurrency token (`RowVersion`) on high-contention entities.

---

## 20) Cross-Cutting Operational Standards

- **Observability**: structured logs, metrics, traces, correlation IDs.
- **Security**: secret management, token signing key rotation, encryption at rest/in transit.
- **Reliability**: retries, idempotency keys for external callbacks, dead-letter queue strategy.
- **Performance**: pagination, projection queries, caching for hot reads.
- **Compliance**: audit trails, tenant-level data export/delete workflows.

---

## 21) Recommended Delivery Roadmap

1. Foundation (tenant middleware, auth, base entities, persistence baseline).
2. Identity + tenant administration + feature flags/settings.
3. Core HRM (organization, employees, attendance, leave).
4. Payroll + multi-currency + document storage.
5. Billing/subscription + notifications + approval engine.
6. Reporting + ESS hardening + operational readiness.

This blueprint is intentionally implementation-ready and can be converted into module-by-module epics, domain models, and API contracts.
