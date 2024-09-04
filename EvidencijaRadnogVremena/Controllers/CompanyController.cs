using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
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
    }
}
