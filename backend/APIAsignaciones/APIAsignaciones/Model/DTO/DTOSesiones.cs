using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APIAsignaciones.Model.DTO
{
    public class DTOSesiones
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? Cupo { get; set; }

    }
}
