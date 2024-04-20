using APIAsignaciones.Model.DataAccess;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.JsonObjects.Settings;
using APIAsignaciones.Model.Sesiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace APIAsignaciones.Model.Configurations
{
    /// <summary>
    /// Lee las sesiones en archivo json y carga a base de datos al iniciar la aplicacion.
    /// </summary>
    public class CargaInicialSesiones 
    {
        //Configuracion de App.
        IConfiguration _configuration;

        
        public CargaInicialSesiones(IConfiguration configuration)
        {
            _configuration = configuration;
            leerSesiones();
        }
         
        public void leerSesiones()
        {
            string nombreArchivo = _configuration.GetConnectionString("ArchivoSesiones");
            string rutaArchivo = nombreArchivo;
            string jsonData = File.ReadAllText(rutaArchivo);
            DASesion dataAccess = new DASesion();

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomDateTimeConverter());

            var objetoSesiones = JsonConvert.DeserializeObject<Sesion>(jsonData, settings);
            foreach(var sesion in objetoSesiones.Sesiones)
            {
                Console.WriteLine(sesion.Key);

                foreach (var detalle in sesion.Value)
                {
                    //Console.WriteLine($"Cupo: {detalle.Cupo}");
                    if(!dataAccess.VerificaExistenciaSinID(sesion.Key, detalle.FechaInicio))
                    {
                        dataAccess.Create(new DTOSesiones()
                        {
                            Nombre = sesion.Key,
                            StartDateTime = detalle.FechaInicio,
                            EndDateTime = detalle.FechaFin,
                            Cupo = detalle.Cupo
                        });
                    }
                }

            }
        }

    }
    
   

}
