namespace RestaurantApi.Models
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
