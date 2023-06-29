using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestPaciente
    {
        public UnitTestPaciente()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-patricia.mssql.somee.com;packet size=4096;user id=Patricia_SQLLogin_1;pwd=cq8y76a8et;data source=upc-patricia.mssql.somee.com;persist security info=False;initial catalog=upc-patricia";
        }

        [Fact, TestPriority(0)]
        public void Paciente_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = PacienteServicios.Get<Paciente>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Paciente_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = PacienteServicios.GetById<Paciente>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Paciente_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Paciente paciente = new();
            paciente.NombreCompleto = "Categoria UnitTest";

            // Act
            var result = PacienteServicios.Insert(paciente);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Paciente_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Paciente paciente = new();
            paciente.Id = 9;
            paciente.NombreCompleto = "Update UnitTest";

            var result = PacienteServicios.Update(paciente);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Paciente_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = PacienteServicios.Delete(10);

            Assert.Equal(1, result);
        }
    }
}
