# GitHub Deployment Guide (Complete)

## 1) Push repository to GitHub
```bash
git remote add origin https://github.com/<your-username>/<your-repo>.git
git push -u origin main
```

## 2) CI pipeline
- Workflow file: `.github/workflows/ci.yml`
- Runs on pushes/PRs and validates:
  - ASP.NET Core API restore + build
  - Next.js frontend install + build

## 3) Container image publishing (GHCR)
- Workflow file: `.github/workflows/deploy-ghcr.yml`
- On push to `main` (or manual trigger), publishes:
  - `ghcr.io/<owner>/saas-hrm-api`
  - `ghcr.io/<owner>/saas-hrm-frontend`

No extra secret is required for GHCR publishing using `GITHUB_TOKEN` in the same repository.

## 4) Run with docker compose locally
```bash
docker compose up --build
```

## 5) Deploy to any container host
Use the GHCR images and run with your host's runtime:
- Azure Container Apps
- AWS ECS/Fargate
- Render/Fly.io
- DigitalOcean App Platform

## 6) Required production environment variables
### API
- `ConnectionStrings__DefaultConnection`
- `Jwt__Issuer`
- `Jwt__Audience`
- `Jwt__Key`

### Frontend
- `NEXT_PUBLIC_API_BASE_URL`
- `NEXT_PUBLIC_TENANT_ID`

## 7) Database migrations in production
Run migration job from API image startup pipeline (recommended as a release step):
```bash
dotnet ef database update
```
