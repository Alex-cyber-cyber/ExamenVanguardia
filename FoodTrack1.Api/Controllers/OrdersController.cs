

using FoodTrack.Application.UseCases;
using FoodTrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly CrearOrdenService _crearOrdenService;
        private readonly CambiarEstadoOrdenService _cambiarEstadoOrdenService;

        public OrdersController(
            CrearOrdenService crearOrdenService,
            CambiarEstadoOrdenService cambiarEstadoOrdenService)
        {
            _crearOrdenService = crearOrdenService;
            _cambiarEstadoOrdenService = cambiarEstadoOrdenService;
        }

        [HttpPost]
        public ActionResult<Order> CrearOrden([FromBody] CrearOrdenRequest request)
        {
            var items = request.Items.Select(i => new OrderItem
            {
                Nombre = i.Nombre,
                Precio = i.Precio,
                Cantidad = i.Cantidad
            }).ToList();

            var orden = _crearOrdenService.CrearOrden(request.FoodTruckId, items);
            return Ok(orden);
        }

        [HttpPost("{id:guid}/estado")]
        public IActionResult CambiarEstado(Guid id, [FromBody] CambiarEstadoRequest request)
        {
            _cambiarEstadoOrdenService.CambiarEstado(id, request.Estado);
            return NoContent();
        }
    }


    public class CrearOrdenRequest
    {
        public Guid FoodTruckId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public class CambiarEstadoRequest
    {
        public EstadoOrden Estado { get; set; }
    }
}
