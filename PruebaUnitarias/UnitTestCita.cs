using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestCita
    {
        public UnitTestCita()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact, TestPriority(0)]
        public void Cita_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = CitaServicios.Get();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Cita_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = CitaServicios.GetById(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Cita_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Cita cita = new();
            cita.Motivo = "Cita UnitTest";

            // Act
            var result = CitaServicios.Insert(cita);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Cita_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Cita cita = new();
            cita.Id = 9;
            cita.Motivo = "Update UnitTest";

            var result = CitaServicios.Update(cita);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Cita_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = CitaServicios.Delete(10);

            Assert.Equal(1, result);
        }
    }
}
