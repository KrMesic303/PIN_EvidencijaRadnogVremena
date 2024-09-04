using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesByName([FromQuery] string name)
        {
            if(string.IsNullOrEmpty(name)) return BadRequest("Wrong parameter: \"name\"");

            var companies = await _unitOfWork.Companies.FindAsync(n => n.Name.Contains(name));
            
            if (companies.Count() < 1) return NotFound();
            return Ok(companies);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyById([FromQuery] int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCompany(Company company)
        {
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCompanyById), new  { id = company.Id }, company);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCompanyById([FromQuery] int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if(company == null) return NotFound();
            
            //Employee check
            if(await _unitOfWork.Persons.FindAsync(n => n.Company == company.Name) != null) return Conflict("Forbidden action! Firm has employees!");

            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete("Force")]
        public async Task<ActionResult> ForceDeleteCompanyById([FromQuery] int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null) return NotFound();

            var employees = await _unitOfWork.Persons.FindAsync(n => n.Company == company.Name);
            if(employees.Count() > 0)
            {
                foreach(var employee in employees)
                {
                    employee.Company = null;

                    _unitOfWork.Persons.Update(employee);
                }
            }

            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.CompleteAsync();

            if(employees.Count() > 0) return Ok($"Updated {employees.Count()} person entities, and deleted company.");

            return Ok($"Deleted company. \nID: {company.Id} - {company.Name} ");
            
        }
    }
}
