using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IRepository<Person> personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var personrs = await _personRepository.GetAllAsync();
            return Ok(personrs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            await _personRepository.AddAsync(person);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _personRepository.Update(person);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _personRepository.Delete(person);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
