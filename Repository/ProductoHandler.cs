using FinalCoderHouse;
using System.Data;
using System.Data.SqlClient;

public class ProductoHandler : DbHandler
{
    public static List<Producto> GetProducto()
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

    public static bool EliminarProducto(int id)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {

            string queryDelete = "DELETE FROM Producto Where Id=@id";

            SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);

            sqlParameter.Value = id;

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
            {
                sqlCommand.Parameters.Add(sqlParameter);

                int numeroDeFilas = sqlCommand.ExecuteNonQuery();

                if (numeroDeFilas > 0)
                {
                    resultado = true;
                }
            }

            sqlConnection.Close();
        }

        return resultado;
    }

    public static bool CrearProducto(Producto producto)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] " +
                "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES " +
                "(@descripcionesParameter, @costoParameter, @precioVentaParameter, @stockParameter, @idUsuarioParameter);";

            SqlParameter descripcionesParameter = new SqlParameter("descripcionesParameter", SqlDbType.VarChar) { Value = producto.descripcion };
            SqlParameter costoParameter = new SqlParameter("costoParameter", SqlDbType.BigInt) { Value = producto.costo };
            SqlParameter precioVentaParameter = new SqlParameter("precioVentaParameter", SqlDbType.BigInt) { Value = producto.precioVenta };
            SqlParameter stockParameter = new SqlParameter("stockParameter", SqlDbType.BigInt) { Value = producto.stock };
            SqlParameter idUsuarioParameter = new SqlParameter("idUsuarioParameter", SqlDbType.VarChar) { Value = producto.idUsuario };

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(descripcionesParameter);
                sqlCommand.Parameters.Add(costoParameter);
                sqlCommand.Parameters.Add(precioVentaParameter);
                sqlCommand.Parameters.Add(stockParameter);
                sqlCommand.Parameters.Add(idUsuarioParameter);

                int numberOfRows = sqlCommand.ExecuteNonQuery();

                if (numberOfRows > 0)
                {
                    resultado = true;
                }
            }

            sqlConnection.Close();
        }

        return resultado;
    }

    public static bool ModificarProducto(Producto producto)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "UPDATE [SistemaGestion].[dbo].[Producto] " +
                "SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario " +
                "WHERE Id = @id ";

            SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = producto.idUsuario };
            SqlParameter descripcionesParameter = new SqlParameter("descripciones", SqlDbType.VarChar) { Value = producto.descripcion };
            SqlParameter costoParameter = new SqlParameter("costo", SqlDbType.BigInt) { Value = producto.costo };
            SqlParameter precioVentaParameter = new SqlParameter("precioVenta", SqlDbType.BigInt) { Value = producto.precioVenta };
            SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.BigInt) { Value = producto.stock };

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.Parameters.Add(descripcionesParameter);
                sqlCommand.Parameters.Add(costoParameter);
                sqlCommand.Parameters.Add(precioVentaParameter);
                sqlCommand.Parameters.Add(stockParameter);

                int numberOfRows = sqlCommand.ExecuteNonQuery();

                if (numberOfRows > 0)
                {
                    resultado = true;
                }
            }

            sqlConnection.Close();
        }

        return resultado;
    }
}