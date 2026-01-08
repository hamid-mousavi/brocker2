# Customs Broker Finder Platform

A starter ASP.NET Core 8 MVC project (Razor views) to list and manage customs brokers.

## Features
- ASP.NET Core 8 MVC with Razor Views
- PostgreSQL via EF Core
- Identity (role-based)
- Broker entities, credentials, ports, phones, addresses
- OpenStreetMap embed for location
- Docker + docker-compose

## Development

Prerequisites: Docker or dotnet 8 SDK

To run with Docker Compose:

  docker-compose up --build

The web app will be available on http://localhost:5000

To run locally using `dotnet`:

  cd src/BrokerFinder
  dotnet run --urls "http://localhost:5000"

(You will need a running PostgreSQL instance and set the `CONN_STR` environment variable or update `appsettings.json`.)

The default admin account is created from environment variables (see `docker-compose.yml`): `ADMIN_EMAIL` and `ADMIN_PWD`. A sample account is `admin@example.com` / `Admin123!` by default.

## Project structure
- src/BrokerFinder: MVC app
- Dockerfile, docker-compose.yml

## Next steps (suggested)
- Add file upload handling for credentials and profile images
- Add broker registration flow & subscription plans
- Add unit and integration tests

## Database migrations (local development)
If you want to run migrations locally (without Docker):

1. Install dotnet-ef: `dotnet tool install --global dotnet-ef`
2. From repo root run:
   `cd src/BrokerFinder`
   `dotnet ef migrations add InitialCreate`
   `dotnet ef database update`

> Note: The app also calls `Database.Migrate()` on startup and will apply pending migrations inside the container.

Security & production notes:
- Use strong secrets management for DB and admin passwords (don't store in compose files)
- Add SSL and HSTS and configure reverse proxy
- Configure background tasks and event logging
- Protect file uploads against virus/malware

## Monetization (ideas)
- Free listing for basic profiles, paid verified badges and featured listings
- Subscription tiers (Basic, Pro, Enterprise) with limits on contacts, analytics and featured slots
- Add payments integration (Stripe/PayPal) and subscription management

## Security & performance tips
- Use role-based authorization for admin and broker actions
- Rate-limit public contact forms and add CAPTCHA
- Add health checks and logging, use connection pooling and query profiling
