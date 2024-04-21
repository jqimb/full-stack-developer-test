using APIAsignaciones.Model.DataAccess;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAsignaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : Controller, IControllerManager<DTOAsignacion>
    {
        DAAsignacion dataAccess = new DAAsignacion();

        public AsignacionController()
        {

        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Create(DTOAsignacion entidad)
        {
            try
            {
                bool result = dataAccess.Create(entidad);
                return Ok(new { id = 1, msg = "Registrado correctamente!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var result = new
                {
                    id = 0,
                    msg = ex.Message
                };

                return BadRequest(result);
            }

        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = dataAccess.Delete(id);
                return Ok(new { id = 1, msg = "Eliminado correctamente!" });
            }
            catch (Exception ex)
            {
                var result = new
                {
                    id = 0,
                    msg = ex.Message
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
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(dataAccess.GetById(id));
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

        [HttpGet]
        [Route("Estudiante/{id}")]
        public IActionResult GetByIdEstudiante(int id)
        {
            try
            {
                return Ok(dataAccess.GetByEstudiante(id));
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
        public IActionResult Update(DTOAsignacion entidad)
        {
            try
            {
                dataAccess.Update(entidad);
                return Ok(new { id = 1, msg = "Asignación actualizada correctamente!" });
            }
            catch (Exception ex)
            {
                var result = new
                {
                    id = 0,
                    msg = ex.Message
                };

                return BadRequest(result);
            }
        }
    }
}
