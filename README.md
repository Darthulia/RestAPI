# Ads API

A simple RESTful ASP.NET Core Web API (controller based) for handling ads, like a buy-and-sell site.
Built with Entity Framework Core (Code First) and SQL Server (LocalDB).

## How to run

1. Open `RestAPI.slnx` in Visual Studio (or use a terminal in the `RestAPI/RestAPI` folder).
2. Create the database from the migration:
   ```
   dotnet ef database update
   ```
   (In Visual Studio: Package Manager Console → `Update-Database`)
3. Start the project. Swagger UI opens at `http://localhost:5264/swagger`.

You can also test the API with the `RestAPI.http` file.

## Endpoints

| Method | URL         | Description                     | Status codes      |
|--------|-------------|---------------------------------|-------------------|
| GET    | `/Ads`      | List all ads                    | 200               |
| GET    | `/Ads/{id}` | Get one ad                      | 200, 404          |
| POST   | `/Ads`      | Create an ad                    | 201, 400          |
| PUT    | `/Ads/{id}` | Total update of an ad           | 204, 400, 404     |
| PATCH  | `/Ads/{id}` | Partial update of an ad         | 204, 400, 404     |
| DELETE | `/Ads/{id}` | Delete an ad                    | 204, 404          |

## Validation

Incoming data is validated with Data Annotations on the DTOs (`AdDto` and `AdPatchDto`).
Because the controller uses `[ApiController]`, invalid data automatically returns **400 Bad Request**
with a list of the errors.

## PATCH

PATCH uses `AdPatchDto`, where every field is nullable. Only the fields you send in are changed:

```json
{ "price": 1200 }
```
