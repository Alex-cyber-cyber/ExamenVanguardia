using FoodTrack.Application.Abstractions;
using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.UseCases
{
    public class CambiarEstadoOrdenService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventLogRepository _eventLogRepository;

        public CambiarEstadoOrdenService(
            IOrderRepository orderRepository,
            IEventLogRepository eventLogRepository)
        {
            _orderRepository = orderRepository;
            _eventLogRepository = eventLogRepository;
        }

        public void CambiarEstado(Guid orderId, EstadoOrden nuevoEstado)
        {
            var orden = _orderRepository.GetById(orderId)
                        ?? throw new InvalidOperationException("Orden no encontrada.");

            var estadoAnterior = orden.Estado;
            orden.Estado = nuevoEstado;

            _orderRepository.Update(orden);

            _eventLogRepository.Add(new EventLog
            {
                OrderId = orderId,
                EstadoAnterior = estadoAnterior,
                EstadoNuevo = nuevoEstado,
                Fecha = DateTime.UtcNow
            });
        }
    }
}
