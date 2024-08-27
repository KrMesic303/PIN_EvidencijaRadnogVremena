namespace EvidencijaRadnogVremena.Models
{
    public class AccessPoint
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Location { get; set; }

    }
}
