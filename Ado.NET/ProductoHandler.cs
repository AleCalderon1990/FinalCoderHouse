using FinalCoderHouse;
using System.Data.SqlClient;

public class ProductoHandler : DbHandler
{
    public List<Producto> GetProducto()
    {
        List<Producto> productos = new List<Producto>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
            {
                sqlConnection.Open();

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Producto producto = new Producto();
                            producto.idProducto = Convert.ToInt32(dataReader["Id"]);
                            producto.stock = Convert.ToInt32(dataReader["Stock"]);
                            producto.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                            producto.costo = Convert.ToInt32(dataReader["Costo"]);
                            producto.precioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                            producto.descripcion = dataReader["Descripciones"].ToString();

                        }
                    }
                }

                sqlConnection.Close();
            }
        }
        return productos;
    }

}