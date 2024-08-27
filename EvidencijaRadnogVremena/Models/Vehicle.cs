namespace EvidencijaRadnogVremena.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string LicensePlate { get; set; }
        public required string Model { get; set; }
        public required int PersonId { get; set; }
        public required Person Person { get; set; }
    }
}
