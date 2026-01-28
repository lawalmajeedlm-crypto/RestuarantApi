namespace RestaurantApi.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int TableNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class CreateReservationDto
    {
        public Guid CustomerId { get; set; }
        public int TableNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
