using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Cita"/>
    /// </summary>
    public static class CitaServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<Cita> Get()
        {
            const string sql = "SP_OBTENER_CITA";

            var enummerableCitas = DBManager.Instance.GetData<Cita>(sql);

            foreach (var item in enummerableCitas)
            {
                item.Paciente = PacienteServicios.GetById<Paciente>(item.IdPaciente);
            }

            return enummerableCitas;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Cita GetById(int id)
        {
            const string sql = "SP_OBTENER_CITA_ID";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<Cita>(sql, parameters);

            Cita cita = result.FirstOrDefault();

            if (cita != null)
            {
                cita.Paciente = PacienteServicios.GetById<Paciente>(cita.IdPaciente);
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified cita.
        /// </summary>
        /// <param name="cita">The cita.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Cita cita)
        {
            const string sql = "SP_AGREGAR_CITA";
            var parameters = new DynamicParameters();
            parameters.Add("@MOTIVO", cita.Motivo, DbType.String);
            parameters.Add("@FECHA_HORA", cita.FechaHora, DbType.DateTime);
            parameters.Add("@ID_PACIENTE", cita.IdPaciente, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified cita.
        /// </summary>
        /// <param name="cita">The cita.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Cita cita)
        {
            const string sql = "SP_ACTUALIZAR_CITA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", cita.Id, DbType.Int64);
            parameters.Add("@MOTIVO", cita.Motivo, DbType.String);
            parameters.Add("@FECHA_HORA", cita.FechaHora, DbType.DateTime);
            parameters.Add("@ID_PACIENTE", cita.IdPaciente, DbType.Int64);

            /// <param name="id">The identifier.</param>
            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Delete(int id)
        {
            const string sql = "SP_ELIMINAR_CITA ";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
