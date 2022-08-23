using FinalCoderHouse;
using System.Data;
using System.Data.SqlClient;

public class VentaHandler : DbHandler
{
    public static List<Venta> GetVenta()
    {
        List<Venta> ventas = new List<Venta>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
            {
                sqlConnection.Open();

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Venta venta = new Venta();
                            venta.id = Convert.ToInt32(dataReader["Id"]);
                            venta.comentarios = dataReader["Comentarios"].ToString();
                            


                        }
                    }
                }

                sqlConnection.Close();
            }
        }
        return ventas;
    }


    public static bool CargaVenta(ProductoVendido productoVendido, Venta venta)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] " +
                "(Id, Comentarios) VALUES " +
                "(@id, @comentarios);";

            SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = venta.id };
            SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.comentarios };
           

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.Parameters.Add(comentariosParameter);
                

                int numberOfRows = sqlCommand.ExecuteNonQuery();

                if (numberOfRows > 0)
                {
                    resultado = true;
                }
            }

            sqlConnection.Close();
        }

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] " +
                "(Id, IdProducto, Stock, IdVenta) VALUES " +
                "(@id, @idProducto, @stock, @idVenta);";

            SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = productoVendido.id };
            SqlParameter idProductoParameter = new SqlParameter("idProductoParameter", SqlDbType.BigInt) { Value = productoVendido.idProducto };
            SqlParameter stockParameter = new SqlParameter("stockParameter", SqlDbType.BigInt) { Value = productoVendido.stock };
            SqlParameter idVentaParameter = new SqlParameter("idVentaParameter", SqlDbType.BigInt) { Value = productoVendido.idVenta };

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.Parameters.Add(idProductoParameter);
                sqlCommand.Parameters.Add(stockParameter);
                sqlCommand.Parameters.Add(idVentaParameter);


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