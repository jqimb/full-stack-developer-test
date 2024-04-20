using APIAsignaciones.Model.JsonObjects;
using Newtonsoft.Json;
using System.Text.Json;

namespace APIAsignaciones.Model.Sesiones
{
    /// <summary>
    /// Objeto utilizado para convertir el Json a Objeto segun estructura dada.
    /// </summary>
    public class Sesion
    {
        [JsonProperty("sesiones")]
        public Dictionary<string, List<DetalleSesion>> Sesiones { get; set; }
    }
}
