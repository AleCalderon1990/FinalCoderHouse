using FinalCoderHouse;
using System.Data.SqlClient;

public class VentaHandler : DbHandler
{
    public List<Venta> GetVenta()
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
}