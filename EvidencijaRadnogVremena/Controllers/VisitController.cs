using EvidencijaRadnogVremena.Data.Repositories.Interfaces;
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
    }
}
