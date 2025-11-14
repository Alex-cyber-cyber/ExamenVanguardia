using FoodTrack.Application.Abstractions;
using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.UseCases
{
    public class CrearOrdenService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFoodTruckRepository _foodTruckRepository;

        public CrearOrdenService(
            IOrderRepository orderRepository,
            IFoodTruckRepository foodTruckRepository)
        {
            _orderRepository = orderRepository;
            _foodTruckRepository = foodTruckRepository;
        }

        public Order CrearOrden(Guid foodTruckId, List<OrderItem> items)
        {
            var foodTruck = _foodTruckRepository.GetById(foodTruckId);
            if (foodTruck is null)
                throw new InvalidOperationException("FoodTruck no encontrado.");

            var orden = new Order
            {
                Id = Guid.NewGuid(),
                FoodTruckId = foodTruckId,
                Items = items,
                Estado = EstadoOrden.Creada,
                Timestamp = DateTime.UtcNow,
                Total = items.Sum(i => i.Precio * i.Cantidad)
            };

            _orderRepository.Add(orden);
            return orden;
        }
    }
}
