

namespace FoodTrack.Domain.Entities
{
    public class FoodTruck
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UbicacionActual { get; set; } = string.Empty;
    }
}
