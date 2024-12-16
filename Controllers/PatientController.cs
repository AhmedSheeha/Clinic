using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IUnitOfWork _uniteOfWork;
        public PatientController(IUnitOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _uniteOfWork.PatientRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(PatientDto patient)
        {
            if(ModelState.IsValid)
            {
                return Ok(await _uniteOfWork.PatientRepository.AddPatient(patient));
            }
            return BadRequest("Invalid Data Were Sent");
        }
    }
}
