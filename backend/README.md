# backend - ASP.NET Core Web API

Este proyecto backend tiene APIs para una Universidad que gestionan tablas de estudiantes, sesiones y asignaciones. 
Fue desarrollado con ASP.NET Core Web API utilizando C# como lenguaje de programación y con la plataforma .NET 7 Standard Term Support.
La base de datos utilizada fue Microsoft SQL Server en su versión 16.0.1000.6.

## Requisitos para la Ejecución

Para ejecutar el proyecto, siga estos pasos:

1. Tener instalado Microsoft Visual Studio Community, la versión utilizada para este proyecto fue la 2022, 17.4.3.
2. Contar con un servidor de base de datos de SQL Server, este se ha utilizado de manera local para el desarrollo.
3. Debes descargar este proyecto utilizando git.
4. Ejecuta los scripts SQL que estan en la carpeta `design\Scripts` en el orden numérico que contiene en el nombre de cada archivo en tu base de datos.
   - `../design/Scripts/01 CREATE DB.sql`
   - `../design/Scripts/02 CREATE TABLES.sql`
   - `../design/Scripts/03 INSERT Estudiantes Prueba.sql`
   - `../design/Scripts/04 PROC Asignacion Estudiante.sql`
   - `../design/Scripts/05 PROC Quitar Sesion Estudiante.sql`
   - `../design/Scripts/06 PROC Actualizar Asignacion.sql`
   
5. Abre el proyecto backend con nombre `APIAsignaciones` dentro de la carpeta `backend` utilizando Microsoft Visual Studio.
6. Configura el string de conexión en el archivo `appsettings.json` y busca la variable `SQLDB` para apuntar a tu instancia de SQL Server.
7. Valida la configuración del archivo `sesiones.json` que esta incluido en el proyecto para hacer la carga automática de las sesiones al iniciar el proyecto.
8. Compila el proyecto y ejecuta la URL definida en `launchSettings.json`, en el campo `applicationUrl`. El valor predeterminado es `http://localhost:5042`.
9. Configura el proyecto frontend para usar la misma URL de backend.

## Configuración OpenAPI

Al ejecutar el proyecto, debería poder acceder a la documentación de OpenAPI/Swagger. 
Se ha utilizado la version 3.0.1 de OpenAPI/Swagger.

