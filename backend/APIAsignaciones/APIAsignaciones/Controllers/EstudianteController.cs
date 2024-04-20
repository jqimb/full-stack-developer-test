using APIAsignaciones.Model.DataAccess;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAsignaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : Controller, IControllerManager<DTOEstudiante>
    {
        DAEstudiante dataAccess = new DAEstudiante();

        public EstudianteController()
        {

        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Create(DTOEstudiante entidad)
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
        [Route("Leer/{id}")]
        public IActionResult GetByEntity(DTOEstudiante entidad)
        {
            try
            {
                return Ok(dataAccess.GetById(entidad.Id));
            }
            catch (Exception ex)
            {
                var result = new
                {
                    msg = "Error al leer un registro",
                    error = ex.Message
                };

                return BadRequest(result);
            }
        }


        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Update(DTOEstudiante entidad)
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
