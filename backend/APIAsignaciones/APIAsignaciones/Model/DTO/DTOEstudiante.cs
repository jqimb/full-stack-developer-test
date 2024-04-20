namespace APIAsignaciones.Model.DTO
{
    /// <summary>
    /// Objeto que traslada los campos de estudiante entre la capa de datos y presentación.
    /// </summary>
    public class DTOEstudiante
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } 
        public string? Email { get; set; }

    }
}
