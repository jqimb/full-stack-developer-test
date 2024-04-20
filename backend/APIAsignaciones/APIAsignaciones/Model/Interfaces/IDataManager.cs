namespace APIAsignaciones.Model.Interfaces
{
    /// <summary>
    /// Interfaz que contiene metodos a implementar para acceder a datos
    /// </summary>
    /// <typeparam name="Entidad"></typeparam>
    public interface IDataManager<Entidad>
    {
        bool Create(Entidad entidad);
        bool Update(Entidad entidad);
        bool Delete(int id);
        List<Entidad> GetAll();
        Entidad GetById(int id);
    }
}
