namespace APIAsignaciones.Model.DTO
{
    /// <summary>
    /// Objeto que traslada los campos de asignaciones entre la capa de datos y presentación.
    /// </summary>
    public class DTOAsignacion
    {
        public int Id { get; set; }
        public DateTime? FechaAsinacion { get; set; }
        public DTOEstudiante Estudiante { get; set; }
        public DTOSesiones Sesion { get; set; }

    }
}
