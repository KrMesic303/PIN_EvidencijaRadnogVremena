namespace EvidencijaRadnogVremena.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required double OIB { get; set; }
        public bool IsWorker { get; set; } = false;
        public string? Position { get; set; }
        public string? Company { get; set; }

    }
}
