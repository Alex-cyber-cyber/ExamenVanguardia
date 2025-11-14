using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Abstractions
{
    public interface IEventLogRepository
    {
        void Add(EventLog log);
        IEnumerable<EventLog> GetByOrder(Guid orderId);
    }
}
