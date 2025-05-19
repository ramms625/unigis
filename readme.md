# UNIGIS - Punto de Ventas BackEnd

Este proyecto es una API RESTful desarrollada en ASP.NET Core 8 para la gestión de puntos de venta y zonas geográficas. Utiliza Entity Framework Core para el acceso a datos y SQL Server como base de datos.

## Estructura del Proyecto

- **Unigis.PuntoVentas.BackEnd/**  
  Proyecto principal de la API.
- **Unigis.PuntoVentas.BackEnd.Data/**  
  Proyecto de acceso a datos, entidades, DTOs y migraciones.

## Características

- Gestión de zonas y puntos de venta.
- Endpoints para CRUD de zonas y puntos de venta.
- Validaciones automáticas y respuestas estructuradas.
- Migraciones automáticas y carga de datos iniciales.
- Documentación Swagger integrada.

## Instalación

1. Clona el repositorio.
2. Configura la cadena de conexión en `Unigis.PuntoVentas.BackEnd/appsettings.json` o `appsettings.Development.json`.
