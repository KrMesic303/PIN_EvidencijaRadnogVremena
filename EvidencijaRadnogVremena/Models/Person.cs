using EvidencijaRadnogVremena.Models.Abstractions;

namespace EvidencijaRadnogVremena.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required bool IsWorker { get; set; }
        public string? Position { get; set; } //If IsWorker is True
        public string? Company { get; set; } //If IsWorker is True

        public ICollection<Visit>? Visits { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; } //If existing
    }
}
