namespace EvidencijaRadnogVremena.Models.Dto
{
    public class PersonVisitReportDto
    {
        public int VisitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int AccessPointId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Description { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
