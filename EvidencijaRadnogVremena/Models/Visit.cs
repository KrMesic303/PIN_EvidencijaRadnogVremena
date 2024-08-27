namespace EvidencijaRadnogVremena.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public required Person Person { get; set; }
        public required int AccessPointId { get; set; }
        public required AccessPoint AccessPoint { get; set; }
        public required DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? Description { get; set; }
    }
}
