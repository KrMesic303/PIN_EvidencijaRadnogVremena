namespace EvidencijaRadnogVremena.Models.Dto
{
    public class VisitDto
    {
        public int PersonId { get; set; }
        public int AccessPointId { get; set; }
        public string? Description { get; set; }
        public DateTime CheckInTime { get; set; } = DateTime.Now;
    }
}
