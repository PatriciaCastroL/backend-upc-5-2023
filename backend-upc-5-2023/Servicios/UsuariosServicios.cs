// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Usuarios"/>
    /// </summary>
    public static class UsuariosServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "Exec SelectUsuarios";

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
            const string sql = "Exec SelectUsuariosById @id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified usuarios.
        /// </summary>
        /// <param name="usuarios">The usuarios.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Usuarios usuarios)
        {
            const string sql = "Exec InsertUsuarios @UserName, @NombreCompleto, @Password";

            var parameters = new DynamicParameters();
            parameters.Add("UserName", usuarios.UserName, DbType.String);
            parameters.Add("NombreCompleto", usuarios.NombreCompleto, DbType.String);
            parameters.Add("Password", usuarios.Password, DbType.String);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }
    }
}
