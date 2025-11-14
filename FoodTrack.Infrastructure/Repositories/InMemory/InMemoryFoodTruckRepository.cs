using FoodTrack.Application.Abstractions;
using FoodTrack.Domain.Entities;

namespace FoodTrack.Infrastructure.Repositories.InMemory
{
    public class InMemoryFoodTruckRepository : IFoodTruckRepository
    {
        private readonly List<FoodTruck> _foodTrucks = new();

        public void Add(FoodTruck foodTruck) => _foodTrucks.Add(foodTruck);

        public IEnumerable<FoodTruck> GetAll() => _foodTrucks;

        public FoodTruck? GetById(Guid id) => _foodTrucks.FirstOrDefault(f => f.Id == id);
    }
}
