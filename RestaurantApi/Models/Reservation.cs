namespace RestaurantApi.Models
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Reservation : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public int TableNumber { get; set; }
        public DateTime DateTime { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public void Confirm()
        {
            Status = ReservationStatus.Confirmed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            Status = ReservationStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
