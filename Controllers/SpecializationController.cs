using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public SpecializationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_unitOfWork.SpecializationRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpecializationDto specialization)
        {
            if(!ModelState.IsValid) return BadRequest("Not Valid data was sent");
            var newOne = new Specialization
            {
                Name = specialization.Name,
            };
            return Ok("The Specialization Was added Successfully");
        }
    }
}
