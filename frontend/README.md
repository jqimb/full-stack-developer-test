# Front-end - Proyecto ASP.NET Core Web App (MVC)

Este proyecto es una aplicación web creada con ASP.NET Core Web App usando el patrón Modelo-Vista-Controlador (MVC) con lenguaje de programación C#.
Está basada en .NET 7 Standard Term Support. 
Para su desarrollo se ha utilizado HTML, CSS, JavaScript y librerias adicionales como Bootstrap, FullCalendar y Moment.js.

## Requisitos para la Configuración

Para ejecutar este proyecto, sigue estos pasos:

1. Tener instalado Microsoft Visual Studio Community, la versión utilizada para este proyecto fue la 17.4.3.
2. Se requiere la configuración adecuada del proyecto `APIAsignaciones` que incluye el backend.
3. Abre el proyecto frontend `WebAppUniversidad` descargado en este repositorio git utilizando Microsoft Visual Studio.
4. Configura el archivo `appsettings.json` y buscar el parámetro `UrlAPIBackend`, coloca el URL en que se está ejecutando el proyecto backend. Por defecto, el valor es `http://localhost:5042`.
5. Asegurate de que el proyecto backend este compilado y ejecutando correctamente.
6. Compila el proyecto frontend y asegurate de que no exista ningun error durante la compilación.
7. Ejecuta el proyecto frontend y automaticamente debe abrir el URL `http://localhost:5191` de lo contrario puedes abrirlo manualmente. Este URL esta configurado en `launchSettings.json`, en el parametro `applicationUrl` si deseas cambiarlo.

## Consideraciones Importantes

- Debes validar que el backend está activo y accesible antes de iniciar el frontend.
- El URL de backend debe ser el mismo para ambos proyectos (backend y frontend).

