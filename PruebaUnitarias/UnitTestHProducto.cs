using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using System.Data;

namespace PruebaUnitarias
{
    public class UnitTestHProducto
    {
        public UnitTestHProducto()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void HProducto_1_Get_VerificarNotNull()
        {
            var result = HProductoServicios.Get<HProducto>();//un listado
            Assert.NotNull(result);
        }

        [Fact]
        public void HProducto_2_GetById_RegresaItem()
        {
            var result = HProductoServicios.GetById(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void HProductos_3_Insertar_RetornaUno()
        {
            HProducto hproductos = new();
            hproductos.Cantidad = "Cantidad UnitTest";
            hproductos.IdProducto = "IdProducto UnitTest";
            hproductos.IdCarritoCompra = "IdCarritoCompra UnitTest";
            hproductos.Id = "Id UnitTest";

            var result = HProductoServicios.Insert(hproductos);

            Assert.Equal(1, result);
        }
    }
}
