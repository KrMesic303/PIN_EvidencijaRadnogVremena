using EvidencijaRadnogVremena.Data.Repositories;
using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccessPointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessPoint>>> GetAccessPoints()
        {
            var accessPoints = await _unitOfWork.AccessPoints.GetAllAsync();
            return Ok(accessPoints);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<AccessPoint>> GetAccessPointById([FromQuery] int id)
        {
            var accessPoint = await _unitOfWork.AccessPoints.GetByIdAsync(id);

            if (accessPoint == null) return NotFound();
            return Ok(accessPoint);
        }


        [HttpPost]
        public async Task<ActionResult<AccessPoint>> AddAccessPoint(AccessPoint accessPoint)
        {
            await _unitOfWork.AccessPoints.AddAsync(accessPoint);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetAccessPointById), new { id = accessPoint.Id }, accessPoint);
        }

        [HttpPut]
        public async Task<ActionResult<AccessPoint>> UpdateAccessPoint([FromQuery] int id, AccessPoint accessPoint)
        {
            if(id != accessPoint.Id) return BadRequest("AccessPoint ID mismatch");

            var existingAccessPoint = await _unitOfWork.AccessPoints.GetByIdAsync(id);
            if(existingAccessPoint == null) return NotFound();

            existingAccessPoint.Name = accessPoint.Name;
            existingAccessPoint.Location = accessPoint.Location;
            existingAccessPoint.Description = accessPoint.Description;

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while updating AccessPoint.\n {ex.Message}");
            }

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAccessPoint([FromQuery] int id)
        {
            var accessPoint = await _unitOfWork.AccessPoints.GetByIdAsync(id);
            if (accessPoint == null) return NotFound();

            //We do not delete access points because of reports, we just put status IsActive to false;
            await _unitOfWork.AccessPoints.SetIsActiveStatus(id, false);

            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
