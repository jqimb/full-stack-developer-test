# backend - ASP.NET Core Web API

Este proyecto backend tiene APIs para una Universidad que gestionan tablas de estudiantes, sesiones y asignaciones. Fue desarrollado con ASP.NET Core Web API utilizando .NET 7 y Microsoft Visual Studio Community 2022 versión 17.4.3. La base de datos se aloja en SQL Server.

## Requisitos para la Ejecución

Para ejecutar el proyecto, siga estos pasos:

1. Descarga la carpeta del directorio git que contiene el proyecto.
2. Ejecuta los scripts SQL en el orden especificado para configurar la base de datos:
   - `\design\Scripts\01 CREATE DB.sql`
   - `\design\Scripts\02 CREATE TABLES.sql`
   - `\design\Scripts\03 INSERT Estudiantes Prueba.sql`
   - `\design\Scripts\04 PROC Asignacion Estudiante.sql`
   - `\design\Scripts\05 PROC Quitar Sesion Estudiante.sql`
   - `\design\Scripts\06 PROC Actualizar Asignacion.sql`

3. Configura el string de conexión en el archivo `appsettings.json`. Busca la variable `SQLDB` y ajuste el valor para que apunte a su instancia de SQL Server.
4. Debes tener configurado el archivo `sesiones.json` que esta incluido en el proyecto. Al ejecutar el proyecto, este archivo cargará automáticamente las sesiones que no existan en la base de datos.
5. Compila el proyecto y ejecútelo en la URL definida en `launchSettings.json`, en el campo `profiles:http:applicationUrl`. El valor predeterminado es `http://localhost:5042`.
6. Configura el proyecto frontend para usar la misma URL de backend.

## Configuración OpenAPI

Al ejecutar el proyecto, debería poder acceder a la documentación de OpenAPI/Swagger. En este proyecto, se utiliza la version de OpenApi: 3.0.1.

