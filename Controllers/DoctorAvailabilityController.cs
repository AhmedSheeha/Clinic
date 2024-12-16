using System.IdentityModel.Tokens.Jwt;
using Clinic.DTO;
using Clinic.Models;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorAvailabilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<DoctorAvailability>> GetAll()
        {
            return await _unitOfWork.AvilabilityRepository.GetAll();
        }
        [HttpPost]
        [Authorize(Roles = Roles.Doctor)]
        public async Task<IActionResult> Create(DateTime S, DateTime E)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value;
            var doctor = await _unitOfWork.DoctorRepository.GetFirstOrDefault(d => d.Email == email);
            var dto = new DoctorAvailabilityDto {
                Start = S,
                End = E,
                DoctorId = doctor.Id
            };
            await _unitOfWork.AvilabilityRepository.MakeAvailableSlotsAsync(dto);
            return Ok("The Slots are Added Successfully");
        }
        //[HttpDelete]
        //[Authorize(Roles = "Doctor")]
        
        //public async Task<IActionResult> Add();
    }
}
