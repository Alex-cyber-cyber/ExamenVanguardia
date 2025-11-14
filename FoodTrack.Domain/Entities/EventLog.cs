namespace FoodTrack.Domain.Entities
{
    public class EventLog
    {
        public Guid OrderId { get; set; }
        public EstadoOrden EstadoAnterior { get; set; }
        public EstadoOrden EstadoNuevo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
