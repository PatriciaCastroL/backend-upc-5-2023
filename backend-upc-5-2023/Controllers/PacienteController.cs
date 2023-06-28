// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Paciente"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public PacienteController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = PacienteServicios.Get<Paciente>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the categoria by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPacienteById")]
        public IActionResult GetPacienteById([FromQuery] int id)
        {
            try
            {
                var result = PacienteServicios.GetById<Paciente>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds the specified paciente.
        /// </summary>
        /// <param name="paciente">The paciente.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPaciente")]
        public IActionResult Insert(Paciente paciente)
        {
            try
            {
                var result = PacienteServicios.Insert(paciente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified paciente.
        /// </summary>
        /// <param name="paciente">The paciente.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePaciente")]
        public IActionResult Update(Paciente paciente)
        {
            try
            {
                var result = PacienteServicios.Update(paciente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeletePaciente")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = PacienteServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion Methods
    }
}
