using FinalCoderHouse;
using System.Data.SqlClient;

public class InicioSesion : DbHandler
{
    public static Usuario GetUsuarioyContraseña(string nombreUsuario, string contraseña)
    {
        Usuario resultados = new Usuario();


        using (SqlConnection sqlConnection=new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", "@contraseña");

                sqlConnection.Open();

                using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        Console.WriteLine("inicio de sesion correcta");
                    }

                    else
                    {
                        Console.WriteLine("datos incorrectos");
                    }
                }

                sqlConnection.Close();
            }
        }

        return resultados;
    }

    
}
