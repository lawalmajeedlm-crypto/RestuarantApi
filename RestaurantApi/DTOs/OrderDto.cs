namespace RestaurantApi.DTOs
{
    public class OrderItemDto
    {
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public string User { get; set; } 
        public byte[] Rowversion { get; set; }

        public Guid CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public string Status { get; set; } = "Pending";
        public decimal Total { get; set; }
    }

    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class UpdateOrderStatusDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
