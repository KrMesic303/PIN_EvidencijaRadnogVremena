using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var personrs = await _unitOfWork.Persons.GetAllAsync();
            return Ok(personrs);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Person>> GetPerson(int personId)
        {
            var person = await _unitOfWork.Persons.GetByIdAsync(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            await _unitOfWork.Persons.AddAsync(person);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(int personId, Person person)
        {
            if (personId != person.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Persons.Update(person);
            await _unitOfWork.CompleteAsync();
            return Ok(person);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int personId)
        {
            var person = await _unitOfWork.Persons.GetByIdAsync(personId);
            if (person == null)
            {
                return NotFound();
            }

            _unitOfWork.Persons.Delete(person);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }
}
