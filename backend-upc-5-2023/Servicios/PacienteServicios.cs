// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Paciente"/>
    /// </summary>
    public static class PacienteServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SP_OBTENER_PACIENTE";

            return DBManager.Instance.GetData<T>(sql);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static T GetById<T>(int id)
        {
            const string sql = "SP_OBTENER_PACIENTE_ID";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified paciente.
        /// </summary>
        /// <param name="paciente">The paciente.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Paciente paciente)
        {
            const string sql_consulta = "SP_AGREGAR_PACIENTE";
            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE_COMPLETO", paciente.NombreCompleto, DbType.String);
            parameters.Add("@CEDULA_IDENTIDAD", paciente.CedulaIdentidad, DbType.String);
            parameters.Add("@CELULAR", paciente.Celular, DbType.String);

            var result = DBManager.Instance.SetData(sql_consulta, parameters);
            return result;
        }

        /// <summary>
        /// Updates the specified paciente.
        /// </summary>
        /// <param name="paciente">The paciente.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Paciente paciente)
        {
            const string sql = "SP_ACTUALIZAR_PACIENTE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", paciente.Id, DbType.Int64);
            parameters.Add("@NOMBRE_COMPLETO", paciente.NombreCompleto, DbType.String);
            parameters.Add("@CEDULA_IDENTIDAD", paciente.CedulaIdentidad, DbType.String);
            parameters.Add("@CELULAR", paciente.Celular, DbType.String);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Delete(int id)
        {
            const string sql = "SP_ELIMINAR_PACIENTE";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
