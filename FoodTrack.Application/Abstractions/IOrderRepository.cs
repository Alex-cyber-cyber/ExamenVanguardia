using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Abstractions
{
    public interface IOrderRepository
    {
        Order? GetById(Guid id);
        IEnumerable<Order> GetByFoodTruck(Guid foodTruckId);
        void Add(Order order);
        void Update(Order order);
    }
}
