using APIAsignaciones.Model.Configurations;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace APIAsignaciones.Model.DataAccess
{
    /// <summary>
    /// Acceso a datos de estudiantes.
    /// </summary>
    public class DAEstudiante : IDataManager<DTOEstudiante>
    {
        private readonly string _connectionString;
        public DAEstudiante()
        {
            _connectionString = ConfigurationAccess.Instance.GetConnectionString("SQLDB") ?? "";
        }

        /// <summary>
        /// Ingresa nuevo registro.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Create(DTOEstudiante entidad)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO TBL_ESTUDIANTES (nombre, email) VALUES (@nombre, @email)";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", entidad.Nombre);
                        command.Parameters.AddWithValue("@email", entidad.Email);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina registro existente por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM TBL_ESTUDIANTES WHERE id=@id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene listado de registros en la tabla.
        /// </summary>
        /// <returns></returns>
        public List<DTOEstudiante> GetAll()
        {
            try
            {
                List<DTOEstudiante> items = new List<DTOEstudiante>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT e.id, e.nombre, e.email FROM TBL_ESTUDIANTES e";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTOEstudiante entidad = new DTOEstudiante();
                                entidad.Id = reader.GetInt32("id");
                                entidad.Nombre = reader.GetString("nombre");
                                entidad.Email = reader.GetString("email");
                                items.Add(entidad);
                            }
                            return items;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Busca registro por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOEstudiante GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT e.id, e.nombre, e.email FROM TBL_ESTUDIANTES e WHERE e.id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            DTOEstudiante entidad = new DTOEstudiante();
                            while (reader.Read())
                            {
                                entidad.Id = reader.GetInt32("id");
                                entidad.Nombre = reader.GetString("nombre");
                                entidad.Email = reader.GetString("email");
                                break;
                            }
                            return entidad;
                        }
                    }
                }
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Busca registro por ID.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Update(DTOEstudiante entidad)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE TBL_ESTUDIANTES SET nombre=@nombre, email=@email " +
                        " WHERE id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", entidad.Id);
                        command.Parameters.AddWithValue("@nombre", entidad.Nombre);
                        command.Parameters.AddWithValue("@email", entidad.Email);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}