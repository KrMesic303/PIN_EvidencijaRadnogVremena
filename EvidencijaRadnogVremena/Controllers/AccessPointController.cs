using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
