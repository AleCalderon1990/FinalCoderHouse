using Microsoft.AspNetCore.Mvc;

namespace FinalCoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController
    {
        [HttpGet(Name = "ConseguirProductoVendido")]
        public List<ProductoVendido> GetProductoVendidos()
        {
            return UsuarioHandler.GetProductoVendido();
        }
    }
}
