namespace EvidencijaRadnogVremena.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }

        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
