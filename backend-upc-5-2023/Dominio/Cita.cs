// Ignore Spelling: Cita

namespace backend_upc_5_2023.Dominio
{
    /// <summary>
    /// Dominio de la tabla Cita
    /// </summary>
    public class Cita
    {
        public int Id { get; set; }

        public string Motivo { get; set; }
        
        public DateTime FechaHora { get; set; }

        public int IdPaciente { get; set; }

       
        public Paciente? Paciente { get; set; }
    }
}
