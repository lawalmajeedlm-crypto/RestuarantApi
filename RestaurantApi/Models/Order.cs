namespace RestaurantApi.Models
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }

    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public string ReferenceNumber { get; set; } = Guid.NewGuid().ToString("N");
        public decimal CalculateTotal() => Items.Sum(i => i.Subtotal);

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
