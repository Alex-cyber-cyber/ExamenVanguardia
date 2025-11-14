namespace FoodTrack.Domain.Entities
{
    public class OrderItem
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
