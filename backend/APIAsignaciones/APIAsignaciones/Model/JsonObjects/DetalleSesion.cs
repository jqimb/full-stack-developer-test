using Newtonsoft.Json;
using System.Text.Json;

namespace APIAsignaciones.Model.JsonObjects
{
    /// <summary>
    /// Contiene el detalle de la sesion segun estructura dada.
    /// </summary>
    public class DetalleSesion
    {
        [JsonProperty("fecha_inicio")]
        public DateTime FechaInicio { get; set; }
        
        [JsonProperty("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [JsonProperty("cupo")]
        public int Cupo { get; set; }
    }
}
