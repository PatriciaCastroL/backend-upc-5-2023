using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using System.Data;

namespace PruebaUnitarias
{
    public class UnitTestProducto
    {
        public UnitTestProducto()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Producto_1_Get_VerificarNotNull()
        {
            var result = ProductoServicios.Get();//un listado
            Assert.NotNull(result);
        }

        [Fact]
        public void Producto_2_GetById_RegresaItem()
        {
            var result = ProductoServicios.GetById(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Productos_3_Insertar_RetornaUno()
        {
            Producto productos = new();
            productos.Nombre = "Nombre UnitTest";
            productos.IdCategoria = 1;

            var result = ProductoServicios.Insert(productos);

            Assert.Equal(1, result);
        }
    }
}
