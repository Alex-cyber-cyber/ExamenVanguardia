namespace FoodTrack.Domain.Entities
{
    public class FoodTruck
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UbicacionActual { get; set; } = string.Empty;
    }

    public enum EstadoOrden
    {
        Creada,
        EnPreparacion,
        Lista,
        Entregada
    }

    public class OrderItem
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public Guid FoodTruckId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public EstadoOrden Estado { get; set; } = EstadoOrden.Creada;
        public decimal Total { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class EventLog
    {
        public Guid OrderId { get; set; }
        public EstadoOrden EstadoAnterior { get; set; }
        public EstadoOrden EstadoNuevo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
