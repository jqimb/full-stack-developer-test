using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APIAsignaciones.Model.DTO
{
    /// <summary>
    /// Objeto que traslada los campos de sesiones entre la capa de datos y presentación.
    /// </summary>
    public class DTOSesiones
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? Cupo { get; set; }

    }
}
