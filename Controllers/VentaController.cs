using Microsoft.AspNetCore.Mvc;

namespace FinalCoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "ConseguirVentas")]
        public List<Venta> GetVentas()
        {
            return UsuarioHandler.GetVenta();
        }
    }
}
