# MyCodex LMS

MyCodex LMS is a starter learning management system built with ASP.NET Core MVC, Entity Framework Core, and SQL Server.

## Features

- Dashboard with course, student, enrollment, and completion metrics.
- Course catalog with search and category filters.
- Course details page with enrollment progress.
- Course creation form with server-side validation.
- SQL Server persistence through Entity Framework Core.
- Database seeding for demo courses, students, and enrollments.

## Project structure

- `Program.cs` configures MVC, SQL Server, and startup seeding.
- `Data/LmsDbContext.cs` defines the EF Core SQL Server data model.
- `Controllers/` contains dashboard and course catalog flows.
- `Views/` contains Razor UI for the LMS dashboard and course management.
- `wwwroot/css/site.css` contains the UI styling.

## Run locally

1. Install the .NET 8 SDK and SQL Server LocalDB or update the connection string in `appsettings.json`.
2. Restore packages:
   ```bash
   dotnet restore
   ```
3. Apply migrations or let the app create the database from startup seeding.
4. Start the application:
   ```bash
   dotnet run
   ```

## Default SQL Server connection

The default connection string uses LocalDB:

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyCodexLmsDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
```
