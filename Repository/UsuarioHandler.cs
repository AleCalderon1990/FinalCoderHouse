using FinalCoderHouse;
using System.Data;
using System.Data.SqlClient;

public class UsuarioHandler : DbHandler
{
    public static List<Usuario> GetUsuario()
    {
        List<Usuario> usuarios = new List<Usuario>();

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
            {
                sqlConnection.Open();

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.idUsuario = Convert.ToInt32(dataReader["Id"]);
                            usuario.nombre = dataReader["Nombre"].ToString();
                            usuario.apellido = dataReader["Apellido"].ToString();
                            usuario.contraseña = dataReader["Contraseña"].ToString();
                            usuario.email = dataReader["Email"].ToString();
                            

                        }
                    }
                }

                sqlConnection.Close();
            }
        }
        return usuarios;
    }

    public static bool EliminarUsuario (int id)
    {
        bool resultado = false;
        
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {

            string queryDelete = "DELETE FROM Usuario Where Id=@id";

            SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);

            sqlParameter.Value = id;

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
            {
                sqlCommand.Parameters.Add(sqlParameter);

                int numeroDeFilas = sqlCommand.ExecuteNonQuery();

                if(numeroDeFilas > 0)
                {
                    resultado = true;
                }
            }

            sqlConnection.Close ();
        }

        return resultado;
    }


    public static bool CrearUsuario(Usuario usuario)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] " +
                "(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES " +
                "(@nombreParameter, @apellidoParameter, @nombreUsuarioParameter, @contraseñaParameter, @mailParameter);";

            SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = usuario.nombre };
            SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = usuario.apellido };
            SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.nombreUsuario };
            SqlParameter contraseñaParameter = new SqlParameter("contraseñaParameter", SqlDbType.VarChar) { Value = usuario.contraseña };
            SqlParameter mailParameter = new SqlParameter("mailParameter", SqlDbType.VarChar) { Value = usuario.email };

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(nombreParameter);
                sqlCommand.Parameters.Add(apellidoParameter);
                sqlCommand.Parameters.Add(nombreUsuarioParameter);
                sqlCommand.Parameters.Add(contraseñaParameter);
                sqlCommand.Parameters.Add(mailParameter);

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

    public static bool ModificarUsuario(Usuario usuario)
    {
        bool resultado = false;

        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            string queryInsert = "UPDATE [SistemaGestion].[dbo].[Usuario] " +
                "SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contraseña, Mail = @mail " +
                "WHERE Id = @id ";

            SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = usuario.idUsuario };
            SqlParameter nombreParameter = new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.nombre };
            SqlParameter apellidoParameter = new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.apellido };
            SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = usuario.nombreUsuario };
            SqlParameter contraseñaParameter = new SqlParameter("contraseña", SqlDbType.VarChar) { Value = usuario.contraseña };
            SqlParameter mailParameter = new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.email };

            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
            {
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.Parameters.Add(nombreParameter);
                sqlCommand.Parameters.Add(apellidoParameter);
                sqlCommand.Parameters.Add(nombreUsuarioParameter);
                sqlCommand.Parameters.Add(contraseñaParameter);
                sqlCommand.Parameters.Add(mailParameter);

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
