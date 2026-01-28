namespace RestaurantApi.Models
{
    public class OrderItem : BaseEntity
    {
       
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => MenuItem != null ? MenuItem.Price * Quantity : 0;
    }
}
