using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Abstractions
{
    public interface IFoodTruckRepository
    {
        void Add(FoodTruck foodTruck);
        FoodTruck? GetById(Guid id);
        IEnumerable<FoodTruck> GetAll();

    }

    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(Guid id);
        IEnumerable<Order> GetByFoodTruckId(Guid foodTruckId);
        void Update(Order order);

    }

    public interface IEventLogRepository
    {
        void Add(EventLog eventLog);
        IEnumerable<EventLog> GetByOrderId(Guid orderId);

    }
}
