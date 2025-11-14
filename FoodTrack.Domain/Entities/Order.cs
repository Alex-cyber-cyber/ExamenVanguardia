namespace FoodTrack.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid FoodTruckId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public EstadoOrden Estado { get; set; } = EstadoOrden.Creada;
        public decimal Total { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
