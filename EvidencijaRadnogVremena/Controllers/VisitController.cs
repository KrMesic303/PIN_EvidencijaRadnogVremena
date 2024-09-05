using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using EvidencijaRadnogVremena.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetAllVisits()
        {
            var visits = await _unitOfWork.Visits.GetAllAsync();
            return Ok(visits);
        }

        [HttpGet("ForVisitor")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsForVisitor([FromQuery] int visitorId)
        {
            var user = await _unitOfWork.Persons.GetByIdAsync(visitorId);
            if(user == null) return NotFound("User not found");

            var visits = await _unitOfWork.Visits.FindAsync(e => e.PersonId == visitorId);

            return Ok(visits);
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> AddVisit(VisitDto visitDto)
        {

            var visitor = await _unitOfWork.Persons.GetByIdAsync(visitDto.PersonId);
            if(visitor == null) return NotFound("Visitor not found, add visitor");

            var openVisit = await _unitOfWork.Visits
                .FindAsync(v => v.PersonId == visitDto.PersonId && v.IsCheckedOut == false);

            if (openVisit != null) return BadRequest("Person is already checked in and has not checked out!");

            var visit = new Visit() 
            {
                AccessPointId = visitDto.AccessPointId,
                PersonId = visitDto.PersonId,
                CheckInTime = visitDto.CheckInTime,
                Description = visitDto.Description,
                IsCheckedOut = false,
                CheckOutTime = null,
            };

            await _unitOfWork.Visits.AddAsync(visit);
            await _unitOfWork.CompleteAsync();

            return Ok($"Added visit \n" + visitDto);
        }

        [HttpPut]
        public async Task<ActionResult<Visit>> UpdateVisit(Visit newVisit)
        {
            var visit = await _unitOfWork.Visits.GetByIdAsync(newVisit.Id);
            if(visit == null) return NotFound();

            visit.Description = newVisit.Description;
            visit.CheckInTime = newVisit.CheckInTime;
            visit.CheckOutTime = newVisit.CheckOutTime;
            
            _unitOfWork.Visits.Update(visit);
            await _unitOfWork.CompleteAsync();

            return Ok(visit);
        }

        [HttpPut("CheckOut")]
        public async Task<ActionResult<Visit>> CheckOutVisit([FromQuery] int visitId)
        {
            var visit = await _unitOfWork.Visits.GetByIdAsync(visitId);
            if(visit == null) return NotFound();

            visit.CheckOutTime = DateTime.Now;
            visit.IsCheckedOut = true;

            return await UpdateVisit(visit);
        }


    }
}
