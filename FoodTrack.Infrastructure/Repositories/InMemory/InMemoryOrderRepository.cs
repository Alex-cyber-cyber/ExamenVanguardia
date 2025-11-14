using FoodTrack.Application.Abstractions;
using FoodTrack.Domain.Entities;
using System.Xml.Linq;

namespace FoodTrack.Infrastructure.Repositories.InMemory
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public void Add(Order order) => _orders.Add(order);

        public Order? GetById(Guid id) => _orders.FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetByFoodTruck(Guid foodTruckId) =>
            _orders.Where(o => o.FoodTruckId == foodTruckId);

        public void Update(Order order)
        {
            var existing = GetById(order.Id);
            if (existing is null) return;

            _orders.Remove(existing);
            _orders.Add(order);
        }
    }
}
