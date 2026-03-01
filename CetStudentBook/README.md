## Books CRUD

### What I implemented
- Added Book entity
- Added Books CRUD pages
- Added Books link to the shared layout navigation

### How to run locally
#### Prerequisites
- .NET SDK 10
- PostgreSQL running locally

#### Steps
1. Set the PostgreSQL connection string in `appsettings.json` (or `appsettings.Development.json`) under:
    - `ConnectionStrings:DefaultConnection`
2. Apply migrations:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef database update --context ApplicationDbContext
3. Run the project
