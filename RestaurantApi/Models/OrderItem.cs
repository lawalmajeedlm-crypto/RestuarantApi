namespace RestaurantApi.Models
{
    public class OrderItem : BaseEntity
    {
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
