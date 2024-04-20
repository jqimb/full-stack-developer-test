using Microsoft.AspNetCore.Mvc;

namespace APIAsignaciones.Model.Interfaces
{
    /// <summary>
    /// Estructura de metodos para definir una clase controller que tiene los metodos del API.
    /// </summary>
    /// <typeparam name="Entidad"></typeparam>
    public interface IControllerManager<Entidad>
    {
        IActionResult Create(Entidad entidad);
        IActionResult Update(Entidad entidad);
        IActionResult Delete(int id);
        IActionResult GetAll();
        IActionResult GetById(int id);
    }
}
