using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<AppointMent>> GetAllAppts(int PatentId)
        {
            var appts = await _unitOfWork.AppointmentRepository.GetAll(app => app.PatientId == PatentId);
            return appts;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto appointment)
        {
            var slot = await _unitOfWork.AvilabilityRepository.GetFirstOrDefault(av => av.DoctorId == appointment.DoctorId && av.StartTime == appointment.Start && av.Available == true);
            if (slot == null || !ModelState.IsValid) return BadRequest("There is no Availble Appointment for the Specified Doctor At this Time");
            var Appt = new AppointMent
            {
                StartDateTime = appointment.Start,
                DoctorId = appointment.DoctorId,
                Detail = appointment.Details,
                PatientId = appointment.PatientId,
            };
            await _unitOfWork.AppointmentRepository.Add(Appt);
            slot.Available = false;
            await _unitOfWork.SaveAsync();
            return Ok("The Appointment is made Successfully");
        }
        /*public async Task<AppointmentDto> Update(AppointmentDto appointment)
        {

        }
        public async Task<IActionResult> Cancel(int ApptId)
        {

        }
        */

    }
}
