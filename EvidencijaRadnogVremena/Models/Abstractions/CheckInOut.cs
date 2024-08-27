namespace EvidencijaRadnogVremena.Models.Abstractions
{
    public abstract class CheckInOut
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public required Person Person { get; set; }
        public required AccessPoint AccessPoint { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
