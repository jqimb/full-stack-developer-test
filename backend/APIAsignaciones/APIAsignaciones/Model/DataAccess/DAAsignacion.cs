using APIAsignaciones.Model.Configurations;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace APIAsignaciones.Model.DataAccess
{
    /// <summary>
    /// Acceso a datos de asignaciones.
    /// </summary>

    public class DAAsignacion : IDataManager<DTOAsignacion>
    {
        private readonly string _connectionString;
        public DAAsignacion()
        {
            _connectionString = ConfigurationAccess.Instance.GetConnectionString("SQLDB") ?? "";
        }

        /// <summary>
        ///  Ingresa nuevo registro.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Create(DTOAsignacion entidad)
        {
            bool result = false;
            string msg = "";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "sp_asignacion_sesion_estudiante";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_estudiante", entidad.Estudiante.Id);
                        command.Parameters.AddWithValue("@id_sesion", entidad.Sesion.Id);
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // El procedimiento retorna 0 cuando hay error y 1 cuando fue la operacion fue exitosa.
                                result = reader.GetInt32("result") > 0;
                                if(!result)
                                {
                                    msg = reader.GetString("msg");
                                    throw new Exception(msg);
                                }
                            }
                        }
                    }
                }
                return result;
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
                    string sql = "DELETE FROM TBL_ASIGNACIONES WHERE id=@id";
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
        public List<DTOAsignacion> GetAll()
        {
            try
            {
                List<DTOAsignacion> items = new List<DTOAsignacion>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT a.id, a.fecha_asignacion, a.id_estudiante, a.id_sesion FROM TBL_ASIGNACIONES a";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTOAsignacion entidad = new DTOAsignacion();
                                entidad.Id = reader.GetInt32("id");
                                entidad.FechaAsinacion = reader.GetDateTime("fecha_asignacion");
                                entidad.Estudiante = new DTOEstudiante() { Id= reader.GetInt32("id_estudiante") };
                                entidad.Sesion = new DTOSesiones() { Id = reader.GetInt32("id_sesion") };
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
        public DTOAsignacion GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT a.id, a.fecha_asignacion, a.id_estudiante, a.id_sesion FROM TBL_ASIGNACIONES a WHERE a.id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            DTOAsignacion entidad = new DTOAsignacion();
                            while (reader.Read())
                            {
                                entidad.Id = reader.GetInt32("id");
                                entidad.Id = reader.GetInt32("id");
                                entidad.FechaAsinacion = reader.GetDateTime("fecha_asignacion");
                                entidad.Estudiante = new DTOEstudiante() { Id = reader.GetInt32("id_estudiante") };
                                entidad.Sesion = new DTOSesiones() { Id = reader.GetInt32("id_sesion") };
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
        /// Actualiza registro por ID
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Update(DTOAsignacion entidad)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE TBL_ASIGNACIONES SET id_estudiante=@id_estudiante, id_sesion=@id_sesion " +
                        " WHERE id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", entidad.Id);
                        command.Parameters.AddWithValue("@id_estudiante", entidad.Estudiante.Id);
                        command.Parameters.AddWithValue("@id_sesion", entidad.Sesion.Id);
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