using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
