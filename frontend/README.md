# Front-end - Proyecto ASP.NET Core Web App (MVC)

Este proyecto es una aplicación web creada con ASP.NET Core Web App usando el patrón Modelo-Vista-Controlador (MVC). Está basada en .NET 7 Standard Term Support. El proyecto frontend requiere la configuración adecuada para conectarse con el backend.

## Requisitos para la Configuración

Para ejecutar este proyecto, sigue estos pasos:

1. **Descargar el Proyecto**: Descarga la carpeta `frontend\WebAppUniversidad` desde el repositorio git.
2. **Configurar el URL del Backend**: Debes abrir el archivo `appsettings.json` y buscar el parámetro `UrlAPIBackend`. Debes configurarlo para que coincida con el URL del proyecto backend. Por defecto, el valor es `http://localhost:5042`.
3. **Backend en Ejecución**: Debes tener ejecutando el proyecto backend previamente a la compilacion y ejecuciónd de este proyecto.
4. **Compilar el Proyecto**: No debe existir algun error durante la compilación.
5. **Ejecutar el Proyecto**: Al ejecutar el proyecto, automaticamente debe abrir el URL `http://localhost:5191` de lo contrario puedes abrirlo manualmente. Este URL esta configurado en `launchSettings.json`, en el parametro `applicationUrl`.

## Consideraciones Importantes

- Debes validar que el backend está activo y accesible antes de iniciar el frontend.
- El URL de backend debe ser el mismo para ambos proyectos (backend y frontend).

