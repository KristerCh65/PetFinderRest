# PetFinder API

REST API for reporting lost pets. It stores pets, the people who report them, and the reports that link the two.

Built with ASP.NET Core (.NET 10), Entity Framework Core and SQL Server.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local install or Docker)
- EF Core CLI, to apply migrations:
  ```bash
  dotnet tool install --global dotnet-ef --version 10.0.12
  ```

## Setup

### 1. Database

The connection string is `ConnectionStrings:PetFinderDB` in [`PetFinderApi/appsettings.json`](PetFinderApi/appsettings.json). The default uses Windows authentication against a local server; change `Server=` to match your machine.

To run SQL Server in Docker instead:

```bash
docker run -d --name petfinder-sql -e ACCEPT_EULA=Y \
  -e 'MSSQL_SA_PASSWORD=<your-password>' \
  -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest
```

Then point the app at it without editing `appsettings.json`, using an environment variable:

```bash
export ConnectionStrings__PetFinderDB='Server=localhost,1433;Database=PetFinderDB;User Id=sa;Password=<your-password>;TrustServerCertificate=true;'
```

Don't commit passwords. Use the environment variable, `dotnet user-secrets`, or an `appsettings.*.Local.json` file (ignored by git).

### 2. Create the tables

```bash
cd PetFinderApi
dotnet ef database update
```

### 3. Run

```bash
cd PetFinderApi
dotnet run --launch-profile PetFinderApi
```

The API listens on `https://localhost:5001` and `http://localhost:5000`. If the browser rejects the HTTPS certificate, run `dotnet dev-certs https --trust` once.

There is no page at `/`. Try `https://localhost:5001/api/pet`.

## Endpoints

All bodies are JSON. Property names are camelCase.

### Pets — `/api/pet`

| Method | Route | Description |
|---|---|---|
| GET | `/api/pet` | List pets |
| GET | `/api/pet/{id}` | Get one pet |
| POST | `/api/pet` | Create a pet |
| PUT | `/api/pet/{id}` | Update a pet (`idPet` in the body must match `{id}`) |
| DELETE | `/api/pet/{id}` | Delete a pet and its reports |

```json
{ "namePet": "Firulais", "specie": "Dog", "race": "Mixed", "age": 3, "size": "M", "photo": null }
```

Required: `namePet`, `specie`.

### People — `/api/entity`

| Method | Route | Description |
|---|---|---|
| GET | `/api/entity` | List people |
| GET | `/api/entity/{id}` | Get one person |
| POST | `/api/entity` | Register a person |
| PUT | `/api/entity/{id}` | Update a person (`idEntity` in the body must match `{id}`) |
| DELETE | `/api/entity/{id}` | Delete a person and their reports |

```json
{
  "identification": "0801-1990-00001",
  "userName": "ana",
  "name": "Ana",
  "lastName": "Diaz",
  "phoneNumber": "8095551234",
  "whatsapp": true,
  "email": "ana@example.com",
  "facebook": null,
  "address": null,
  "photo": null
}
```

Required: `identification`, `userName`, `name`, `lastName`, `phoneNumber`.

`email`, `userName` and `identification` must be unique. POST and PUT return `400` with `Email Exists!`, `UserName Exists!` or `ID Duplicated!` when one is already taken.

### Reports — `/api/report`

| Method | Route | Description |
|---|---|---|
| GET | `/api/report` | List reports, including the pet and the reporter |
| GET | `/api/report/{id}` | Get one report, including the pet and the reporter |
| POST | `/api/report` | Create a report |
| PUT | `/api/report/{id}` | Update a report (`case` in the body must match `{id}`) |
| DELETE | `/api/report/{id}` | Delete a report |

```json
{ "rescueDate": "2026-10-13T00:00:00", "petLost": 1, "reportedBy": 1 }
```

`petLost` is a pet's `idPet` and `reportedBy` is a person's `idEntity`.

## Known issues

- Creating a report with a `petLost` or `reportedBy` that doesn't exist returns `500` instead of `400`.

## Project structure

```
PetFinderApi/
  Controllers/   API endpoints (Pet, Entity, Report)
  Data/          FinderContext (EF Core) and EntityAppService (duplicate checks)
  Models/        Pet, Entity, Report
  Migrations/    EF Core migrations
```
