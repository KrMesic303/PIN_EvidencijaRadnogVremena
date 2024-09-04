using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using EvidencijaRadnogVremena.Models;
using EvidencijaRadnogVremena.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesByName([FromQuery] string companyName)
        {
            if(string.IsNullOrEmpty(companyName)) return BadRequest("Wrong parameter: \"name\"");

            var companies = await _unitOfWork.Companies.FindAsync(n => n.Name.Contains(companyName));
            
            if (companies.Count() == 0) return NotFound();
            return Ok(companies);
        }

        [HttpGet("ById")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyById([FromQuery] int companyId)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyId);

            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCompany(CompanyDto companyDto)
        {
            var company = new Company()
            {
                Name = companyDto.Name,
                Location = companyDto.Location,

            };

            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCompanyById), new  { id = company.Id }, company);
        }

        [HttpPatch]
        public async Task<ActionResult<Company>> UpdateCompany(Company company)
        {
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.CompleteAsync();
            return Ok(company);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCompanyById([FromQuery] int companyId)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyId);
            if(company == null) return NotFound();
            
            //Employee check
            if(await _unitOfWork.Persons.FindAsync(n => n.Company == company.Name) != null) return Conflict("Forbidden action! Firm has employees!");

            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete("Force")]
        public async Task<ActionResult> ForceDeleteCompanyById([FromQuery] int companyId)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(companyId);
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
