namespace RestaurantApi.DTOs
{
    public class CategoryDto
    {
        public string User { get; set; }
        public string Name { get; set; } 
        public bool Isdeleted { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
