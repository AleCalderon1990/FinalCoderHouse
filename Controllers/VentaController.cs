using FinalCoderHouse.Controllers.DTOS;
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
            return VentaHandler.GetVenta();
        }

        [HttpDelete]
        public bool EliminarVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost]
        public bool CargarVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CargarVenta(new Venta
                {
                    id = venta.id,
                    comentarios = venta.comentarios,
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
