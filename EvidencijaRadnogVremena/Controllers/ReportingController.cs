using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
