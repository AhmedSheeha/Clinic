using System.IdentityModel.Tokens.Jwt;
using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Doctor)]
    public class AttendanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceDto attendance)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;
            var doctor = await _unitOfWork.DoctorRepository.GetFirstOrDefault(d => d.Email == email);
            var appt = await _unitOfWork.AppointmentRepository.GetFirstOrDefault(a => a.PatientId == attendance.PatientId && a.DoctorId == doctor.Id && a.Status == true);
            if (appt == null || !ModelState.IsValid) return BadRequest("There is no Appointment Attached to those Information");
           
            appt.Status = false;  
            await _unitOfWork.AttendanceRepository.CreateAttendance(attendance, doctor.Id);
            await _unitOfWork.SaveAsync();
            return Ok(attendance);
        }

    }
}
