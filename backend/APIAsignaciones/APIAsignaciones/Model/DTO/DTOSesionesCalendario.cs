using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APIAsignaciones.Model.DTO
{
    /// <summary>
    /// Objeto que traslada los campos de sesiones para mostrar en calendario en capa presentacion.
    /// </summary>
    public class DTOSesionesCalendario
    {
        [JsonProperty("title")]
        public string Titulo { get {
                return string.Concat(Cantidad, " Sesiones");
            }
        }
        [JsonProperty("start")]
        public DateOnly FechaInicio { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

    }
}
