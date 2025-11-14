using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Abstractions
{
    public interface IFoodTruckRepository
    {
        FoodTruck? GetById(Guid id);
        IEnumerable<FoodTruck> GetAll();
        void Add(FoodTruck foodTruck);
    }
}
