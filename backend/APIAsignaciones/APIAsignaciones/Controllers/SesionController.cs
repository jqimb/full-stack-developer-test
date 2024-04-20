using APIAsignaciones.Model.DataAccess;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIAsignaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : Controller, IControllerManager<DTOSesiones>
    {
        DASesion dataAccess = new DASesion();

        public SesionController()
        {

        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Create([FromBody] DTOSesiones entidad)
        {
            try
            {
                dataAccess.Create(entidad);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al crear registro",
                    error = ex.Message
                };

                return BadRequest(result);
            }

            return Ok();
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(dataAccess.Delete(id));
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al eliminar registro",
                    error = ex.Message
                };

                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("Leer")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(dataAccess.GetAll());
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al obtener todos los registros",
                    error = ex.Message
                };

                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("SesionesCalendario")]
        public IActionResult GetListCalendar()
        {
            try
            {
                string json = JsonConvert.SerializeObject(dataAccess.GetSesionesCalendario(), Formatting.Indented);
                return Ok(json);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al obtener todos los registros para calendario.",
                    error = ex.Message
                };

                return BadRequest(result);
            }
        }


        [HttpPost]
        [Route("Buscar")]
        public IActionResult GetByEntity([FromBody] DTOSesiones entidad)
        {
            try
            {
                if(entidad.Id.HasValue && entidad.Id > 0)
                {
                    DTOSesiones result = dataAccess.GetById(entidad.Id ?? 0);
                    return Ok(new { id = 1, result = result });
                }
                else if(entidad.StartDateTime != null)
                {
                    List<DTOSesiones> result = dataAccess.GetByStartDate((DateTime)entidad.StartDateTime);
                    if (result != null && result.Count > 0)
                    {
                        return Ok(new { id = 1, result = result });
                    }
                    else
                    {
                        return Ok(new { id = 0, result = "No se encontraron datos." });
                    }
                }
                else
                {
                    return Ok(new { id = 0, result = "Filtros inválidos." });
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    id = 0,
                    result = "Error al leer un registro"
                };

                return BadRequest(result);
            }
        }


        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Update(DTOSesiones entidad)
        {
            try
            {
                return Ok(dataAccess.Update(entidad));
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al actualizar un registro",
                    error = ex.Message
                };

                return BadRequest(result);
            }
        }
    }
}
