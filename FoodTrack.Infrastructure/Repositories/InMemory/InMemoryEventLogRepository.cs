using FoodTrack.Application.Abstractions;
using FoodTrack.Domain.Entities;

namespace FoodTrack.Infrastructure.Repositories.InMemory
{
    public class InMemoryEventLogRepository : IEventLogRepository
    {
        private readonly List<EventLog> _logs = new();

        public void Add(EventLog log) => _logs.Add(log);

        public IEnumerable<EventLog> GetByOrder(Guid orderId) =>
            _logs.Where(l => l.OrderId == orderId);
    }
}
