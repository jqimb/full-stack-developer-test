# Preguntas - Full-stack-developer-test

## 1. ¿Cuánto tiempo dedicó a la prueba de codificación de backend?
Aproximadamente 7 horas construyendo toda la arquitectura dentro de la solucion con MVC y el acceso a los datos de manera personalizada, ya que no utilice ORM para el manejo de los datos, sino que he utilizado librerias nativas de .NET para ello.

## 2. ¿Qué agregarías a tu solución si tuvieras más tiempo?
Utilizaria mas bootstrap para mejorar el diseño del front end.

## 3. ¿Cuales fueron los motivos de tu elección de arquitectura para este tipo de aplicación ?
He utilizado una solucion con arquitectura MVC de .NET debido a que me encuentro bastante familiarizado con la plataforma para la construccion de APIs de manera rapida, segmentando de manera modular las capas de acceso a datos de la capa de presentacion que son los controladores, permitiendo asi mayor escalabilidad del software, ya que podria integrarse cualquier motor de base de datos relacional unicamente cambiando la cadena de conexion configurada y adaptando el software segun los cambios tecnologicos de manera agil.

## 4. ¿Cómo se pueden gestionar los casos posteriores a la medianoche para que se muestren el mismo día y no el siguiente?
No se si comprendí bien la pregunta. Pero para considerar registros de casos que ingresan despues de las 12 am, debe configurarse la hora maxima permitida por ejemplo 5am. Esto si se muestra en un reporte, debe de agregarse entre los filtros el rango que todo lo que es mayor a las 5am y menor de las 5am del dia siguiente, debe considerarse parte del dia evaluado.

## 5. ¿Cuánto tiempo dedicó a la prueba de codificación frontend? ¿Cuáles fueron tus mayoresdificultades?
Aproximadamente 8 horas, he utilizado igual forma una solucion .NET con archivos Razor pero utilizando JavaScript nativo para el desarrollo de la funcionalidad.
De esta manera se puede evaluar el uso de HTML, CSS y Javascript que son basicos para el desarrollo web independientemente de otra plataforma o libreria que tenga componentes ya construidos.

Entre las dificultades que se podrian mencionar podria ser que se requirio investigar sobre la libreria Full Calendar de JavaScript, ya que requiere un json especifico de entrada para mostrar eventos en el calendario, luego en el backend para la asignacion fue necesario utilizar un procedimiento almacenado que se encargara de realizar las validaciones requeridas, ya que esa operacion debe considerarse transaccionalmente y no con sentencias sql con autocommit.

## 6. ¿Cómo localizaría un problema de rendimiento en producción? ¿Alguna vez has tenido que hacer esto?
He tenido experiecia con ello en ambientes productivos y lo ideal es realizar un monitoreo a nivel de servidores y tambien modificando el codigo fuente de las aplicaciones para habilitar logs que permitan tener un analisis basado en datos sobre los errores de rendimiento y saber si existen consultas que optimizar por ejemplo, o si es un problema de infraestructura por memoria u otra razon de hardware.

## 7. ¿Cuál fue la característica más útil que se agregó a la última versión del lenguaje elegido? Incluya un fragmento de código que muestre cómo lo ha utilizado.
ASP.NET Core, ahora permite utilizar paginas Razor que nos permite a su vez incluir codigo C# dentro de una pagina que incluye html que son los archivos cshtml.
Esto se ha incorporado hace un tiempo a las nuevas versiones de .NET.

### Código en el archivo Controller

```
public IActionResult Index()
{
    // Se busca la configuración del URL base de las APIs
    string apiURL = _configuration["UrlAPIBackend"] ?? "";
    ViewData["apiURL"] = apiURL;
    return View();
}
```

### Código en el archivo cshtml
```
@{
    // Obtiene configuración de archivo JSON con el URL base para conectarse a las APIs
    var apiBaseUrl = ViewData["apiURL"];
}
```

## 8. ¿Que elementos de seguridad hubiera incluido en su API?
El uso de JSON Web Token (jwt) para manejar el acceso por medio de token al API, se puede incluir como un nivel de seguridad.
