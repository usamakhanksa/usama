# SaaS HRM Platform Foundation

This repository now includes a production-ready **foundation scaffold** for a multi-tenant SaaS HRM platform using Clean Architecture.

## Included
- `SaaS-Platform-Architecture.md` — complete platform blueprint.
- `src/Domain` — domain entities (tenant, identity, billing, HRM, workflow, localization, finance, notifications, settings).
- `src/Application` — DTOs, interfaces, validators, and services.
- `src/Infrastructure` — EF Core context, repository/UoW, queue/storage abstractions.
- `src/API` — API bootstrap, middleware, versioning, health checks, and employee endpoints.
- `frontend` — Next.js modular shell with module routes.

## Backend run (when .NET SDK is installed)
```bash
cd src/API
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## Frontend run
```bash
cd frontend
npm install
npm run dev
```

## Architecture
- [SaaS Platform Architecture](./SaaS-Platform-Architecture.md)
