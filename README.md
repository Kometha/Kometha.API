# Kometha.API 🚶‍♂️🌐

Pequeña API de práctica para seguir el curso:
"Use C# and Build an ASP.NET Core Web API with Entity Framework Core, SQL Server, Authentication, Authorization | .NET8".  
No es un producto real — es un sandbox para aprender C#, .NET 8 y EF Core.

## Qué hace (resumen) 🔎
- API REST para gestionar `Walks`, `Regions` y `Difficulties`.
- Implementa Entity Framework Core con un `DbContext` (`KomethaDBContext.cs`) y datos seed para facilitar pruebas.
- Patrón simple de repositorios y controladores (`WalksController`, `RegionsController`) para practicar arquitectura y testing.

## Tecnologías 🧰
- .NET 8, C# 12
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server (configurable en `appsettings.json`)

## Datos seed importantes ✨
El `KomethaDBContext` ya incluye seed para `Difficulties` y `Regions`. Revisa `Kometha.API\Dataa\KomethaDBContext.cs` para ver los GUIDs y nombres usados en las pruebas.

Ejemplos de GUIDs seed (revisa el archivo para confirmar):
- Difficulty: `7674c000-85d1-469b-8460-5043b6fc5575` (Easy)
- Region: `7674c000-85d1-469b-8460-5043b6fc5575` (AuckLand)
- Otros GUIDs también están en el seed — usarlos en POST/PUT de prueba.

> Nota: algunos GUIDs pueden coincidir entre entidades en el seed (esto está en el código actual); revisa el archivo si quieres cambiarlos.

## Cómo ejecutar (rápido) ▶️
1. Ajustar la cadena de conexión en `appsettings.json` para apuntar a tu SQL Server.
2. Desde la terminal en el folder del proyecto:
   - (Si no tienes dotnet-ef) `dotnet tool install --global dotnet-ef`
   - Agregar migración: `dotnet ef migrations add Initial`
   - Actualizar BD: `dotnet ef database update`
3. Ejecutar desde Visual Studio: __Debug > Start Debugging__ o con CLI: `dotnet run`

## Endpoints básicos (ejemplos) 🔗
- GET /api/walks — listar walks  
- GET /api/regions — listar regiones  
- POST /api/walks — crear walk (body JSON):

```json
{
  "name": "string",
  "length": 0,
  "duration": 0,
  "regionId": "string",
  "difficultyId": "string",
  "imageUrl": "string",
  "description": "string"
}
```