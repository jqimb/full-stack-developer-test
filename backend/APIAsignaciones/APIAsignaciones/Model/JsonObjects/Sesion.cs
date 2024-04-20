using APIAsignaciones.Model.JsonObjects;
using Newtonsoft.Json;
using System.Text.Json;

namespace APIAsignaciones.Model.Sesiones
{
    public class Sesion
    {
        [JsonProperty("sesiones")]
        public Dictionary<string, List<DetalleSesion>> Sesiones { get; set; }
    }
}
