using FinalCoderHouse;
using System.Data.SqlClient;

public class ProductoVendidoHandler : DbHandler
{
    public List<ProductoVendido> GetProductoVendido()
    {
        List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
            {
                sqlConnection.Open();

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.id = Convert.ToInt32(dataReader["Id"]);
                            productoVendido.idProducto = Convert.ToInt32(dataReader["IdProducto"]);
                            productoVendido.stock = Convert.ToInt32(dataReader["Stock"]);
                            productoVendido.idVenta = Convert.ToInt32(dataReader["IdVenta"]);
                            

                        }
                    }
                }

                sqlConnection.Close();
            }
        }
        return productosVendidos;
    }
}