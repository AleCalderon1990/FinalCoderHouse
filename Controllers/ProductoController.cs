using FinalCoderHouse.Controllers.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace FinalCoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "ConseguirProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProducto();
        }
    }

    [HttpPost]
    public bool CrearProducto([FromBody] PostProducto producto)
    {
        try
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                idProducto = producto.idProducto,
                descripcion = producto.descripcion,
                costo = producto.costo,
                precioVenta = producto.precioVenta,
                stock = producto.stock,
                idUsuario = producto.idUsuario
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
       
    }

    [HttpPut]
    public bool ModificarProducto([FromBody] PutProducto producto)
    {
        return ProductoHandler.ModificarProducto(new Producto
        {
            idProducto = producto.idProducto,
            descripcion = producto.descripcion,
               
        });
    }

    [HttpDelete]
    public bool EliminarProducto([FromBody] int id)
    {
        try
        {
            return ProductoHandler.EliminarProducto(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
