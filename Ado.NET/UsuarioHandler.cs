using FinalCoderHouse;
using System.Data.SqlClient;

public class UsuarioHandler : DbHandler
{
    public List<Usuario> GetUsuario()
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
}
