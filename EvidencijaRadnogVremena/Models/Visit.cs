namespace EvidencijaRadnogVremena.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public required int AccessPointId { get; set; }
        public required DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? Description { get; set; }
    }
}
