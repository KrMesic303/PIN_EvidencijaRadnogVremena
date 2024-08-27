using EvidencijaRadnogVremena.Models.Abstractions;

namespace EvidencijaRadnogVremena.Models
{
    public class Visit : CheckInOut
    {
        public string? Description { get; set; }
    }
}
