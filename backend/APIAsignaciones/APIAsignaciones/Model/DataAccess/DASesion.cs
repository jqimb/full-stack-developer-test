using APIAsignaciones.Model.Configurations;
using APIAsignaciones.Model.DTO;
using APIAsignaciones.Model.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIAsignaciones.Model.DataAccess
{
    /// <summary>
    /// Acceso a datos de sesiones.
    /// </summary>
    public class DASesion : IDataManager<DTOSesiones>
    {
        private readonly string _connectionString;
        public DASesion()
        {
            _connectionString = ConfigurationAccess.Instance.GetConnectionString("SQLDB") ?? "";
        }

        /// <summary>
        /// Revisa la existencia de sesion enviando nombre y fecha de inicio.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="fechaInicio"></param>
        /// <returns></returns>
        public bool VerificaExistenciaSinID(string nombre, DateTime fechaInicio)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT COUNT(*)
                                    FROM TBL_SESIONES s 
                                    WHERE s.nombre = @nombre
                                    AND s.start_datetime = @start_datetime
                                    ";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@start_datetime", fechaInicio);
                        int count = (int) command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva sesion.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Create(DTOSesiones entidad)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO TBL_SESIONES (nombre, start_datetime, end_datetime, cupo) VALUES (@nombre, @start_datetime, @end_datetime, @cupo)";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", entidad.Nombre);
                        command.Parameters.AddWithValue("@start_datetime", entidad.StartDateTime);
                        command.Parameters.AddWithValue("@end_datetime", entidad.EndDateTime);
                        command.Parameters.AddWithValue("@cupo", entidad.Cupo);
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
        /// Borra una sesión.
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
                    string sql = "DELETE FROM TBL_SESIONES WHERE id=@id";
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
        /// Genera lista de datos.
        /// </summary>
        /// <returns></returns>
        public List<DTOSesiones> GetAll()
        {
            try
            {
                List<DTOSesiones> items = new List<DTOSesiones>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT s.id, s.nombre,s.start_datetime,s.end_datetime,s.cupo FROM TBL_SESIONES s";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTOSesiones entidad = new DTOSesiones();
                                entidad.Id = reader.GetInt32("id");
                                entidad.Nombre = reader.GetString("nombre");
                                entidad.StartDateTime = reader.GetDateTime("start_datetime");
                                entidad.EndDateTime = reader.GetDateTime("end_datetime");
                                entidad.Cupo = reader.GetInt32("cupo");
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
        /// Genera lista de datos de sesiones para calendario.
        /// </summary>
        /// <returns></returns>
        public List<DTOSesionesCalendario> GetSesionesCalendario()
        {
            try
            {
                List<DTOSesionesCalendario> items = new List<DTOSesionesCalendario>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT CAST(start_datetime AS DATE) as [start], COUNT(1) as cantidad
                                    FROM TBL_SESIONES
                                    GROUP BY CAST(start_datetime AS DATE)
                                    ";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTOSesionesCalendario entidad = new DTOSesionesCalendario();
                                entidad.FechaInicio = DateOnly.FromDateTime(reader.GetDateTime("start"));
                                entidad.Cantidad = reader.GetInt32("cantidad");
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
        /// Hace la busqueda de la sesion por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOSesiones GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT s.id, s.nombre,s.start_datetime,s.end_datetime,s.cupo FROM TBL_SESIONES s WHERE s.id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            DTOSesiones entidad = new DTOSesiones();
                            while (reader.Read())
                            {
                                entidad.Id = reader.GetInt32("id");
                                entidad.Nombre = reader.GetString("nombre");
                                entidad.StartDateTime = reader.GetDateTime("start_datetime");
                                entidad.EndDateTime = reader.GetDateTime("end_datetime");
                                entidad.Cupo = reader.GetInt32("cupo");
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
        /// Hace la busqueda de sesiones indicando la fecha de inicio
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <returns></returns>
        public List<DTOSesiones> GetByStartDate(DateTime fechaInicio)
        {
            List<DTOSesiones> items = new List<DTOSesiones>();

            try
            {

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT s.id, s.nombre,s.start_datetime,s.end_datetime,s.cupo 
                                    FROM TBL_SESIONES s WHERE CAST(s.start_datetime AS DATE) = @fechaInicio
                                    ORDER BY s.start_datetime
                                    ";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTOSesiones entidad = new DTOSesiones();
                                entidad.Id = reader.GetInt32("id");
                                entidad.Nombre = reader.GetString("nombre");
                                entidad.StartDateTime = reader.GetDateTime("start_datetime");
                                entidad.EndDateTime = reader.GetDateTime("end_datetime");
                                entidad.Cupo = reader.GetInt32("cupo");
                                items.Add(entidad);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return items;
        }

        /// <summary>
        /// Actualiza los datos de una sesion por ID.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Update(DTOSesiones entidad)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE TBL_SESIONES SET nombre=@nombre, start_datetime=@start_datetime, end_datetime=@end_datetime, cupo=@cupo " +
                        " WHERE id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", entidad.Id);
                        command.Parameters.AddWithValue("@nombre", entidad.Nombre);
                        command.Parameters.AddWithValue("@start_datetime", entidad.StartDateTime);
                        command.Parameters.AddWithValue("@end_datetime", entidad.EndDateTime);
                        command.Parameters.AddWithValue("@cupo", entidad.Cupo);
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