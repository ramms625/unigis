# UNIGIS - Punto de Ventas

Este repositorio contiene la solución para la gestión de puntos de venta y zonas geográficas, compuesta por los siguientes proyectos:

## Estructura del Repositorio

- **Unigis.PuntoVentas.BackEnd/**  
  Proyecto principal de la API RESTful desarrollada en ASP.NET Core 8.
- **Unigis.PuntoVentas.BackEnd.Data/**  
  Proyecto de acceso a datos, entidades, DTOs y migraciones para SQL Server.
- **Unigis.PuntoVentas.FrontEnd/**  
  (Opcional) Proyecto para la interfaz de usuario, por ejemplo, una aplicación React.

## Características Principales

- Gestión de zonas y puntos de venta.
- Endpoints para operaciones CRUD de zonas y puntos de venta.
- Validaciones automáticas y respuestas estructuradas.
- Migraciones automáticas y carga de datos iniciales.
- Documentación Swagger integrada para la API.
- Separación clara entre lógica de negocio y acceso a datos.

## Instalación y Ejecución

1. Clona el repositorio.
2. Configura la cadena de conexión en `Unigis.PuntoVentas.BackEnd/appsettings.json` o `appsettings.Development.json`.
3. Restaura los paquetes NuGet:
   ```sh
   dotnet restore
   ```
4. Ejecuta las migraciones y la carga de datos inicial:
   ```sh
   dotnet run --project Unigis.PuntoVentas.BackEnd/Unigis.PuntoVentas.BackEnd.csproj
   ```
5. (Opcional) Si tienes el frontend, navega a `Unigis.PuntoVentas.FrontEnd` y ejecuta:
   ```sh
   npm install
   npm start
   ```

## Uso

- Accede a la documentación Swagger en:  
  `https://localhost:7242/swagger` o `http://localhost:5105/swagger`
- Endpoints principales:
  - `GET /api/Zonas/GetAll` — Listar zonas.
  - `GET /api/Zonas/Get/{id}` — Obtener zona por ID.
  - `GET /api/PuntoVentas/GetAll` — Listar puntos de venta.
  - `GET /api/PuntoVentas/Get/{id}` — Obtener punto de venta por ID.
  - `DELETE /api/PuntoVentas/Delete/{id}` — Eliminar punto de venta.

## Tecnologías

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core 8 (SQL Server)
- AutoMapper
- Swagger (Swashbuckle)
- React para el frontend