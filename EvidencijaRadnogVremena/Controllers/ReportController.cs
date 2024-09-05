using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("CompanyEmployees")]
        public async Task<ActionResult<IEnumerable<Person>>> GetCompanyEmployees([FromQuery] string companyName)
        {
            if(string.IsNullOrEmpty(companyName)) return BadRequest("Parameter \"name\" cannot be null or empty");

            var employees = await _unitOfWork.Persons.FindAsync(n => n.Company ==  companyName);

            return Ok(employees);
        }

        [HttpGet("OpenVisits")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetOpenVisitsForAccessPoint()
        {
            var visitsAtAccessPoint = await _unitOfWork.Visits.FindAsync(e => e.IsCheckedOut == false);

            return Ok(visitsAtAccessPoint);
        }

        [HttpGet("ByAccessPoint")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetAllVisitsForAccessPoint([FromQuery] int accessPointId)
        {
            var visitsAtAccessPoint = await _unitOfWork.Visits.FindAsync(e => e.AccessPointId == accessPointId);

            return Ok(visitsAtAccessPoint);
        }

        [HttpGet("DateTimeInterval")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsInInterval([FromQuery] DateTime from, [FromQuery] DateTime to)
        {

            var visits = await _unitOfWork.Visits.FindAsync(e => e.CheckInTime < to && e.CheckInTime > from);

            return Ok(visits);
        }

    }
}
