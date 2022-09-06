using FinalCoderHouse.Controllers.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace FinalCoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "ConseguirUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuario();
        }

        [HttpDelete]
        public bool EliminarUsuario([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                idUsuario = usuario.Id,
                nombre = usuario.Nombre
            });
        }

        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            try
            {
                return UsuarioHandler.CrearUsuario(new Usuario
                {
                    apellido = usuario.apellido,
                    contraseña = usuario.contraseña,
                    email = usuario.email,
                    nombre = usuario.nombre,
                    nombreUsuario = usuario.nombreUsuario
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
