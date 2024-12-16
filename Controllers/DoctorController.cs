using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public DoctorController(IUnitOfWork unitOfWork) {  _unitOfWork = unitOfWork; }
        [HttpGet]
        public async Task<IEnumerable<Doctor>> AllDoctors()
        {
            var list = await _unitOfWork.DoctorRepository.GetAll();
            return list;
        }
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RegisterDoctor(DoctorDto doctor)
        {
            var user = await _userManager.FindByEmailAsync(doctor.Email);
            if (doctor == null || !ModelState.IsValid || user == null) return NotFound("No Valid Data was Sent");
            new Doctor
            {
                Name = doctor.Name,
                Address = doctor.Address,
                Phone = doctor.Phone,
                SpecializationId = doctor.SpecializationId,
                UserId = user.Id.ToString(),
                Email = doctor.Email,
            };
            if (!await _roleManager.RoleExistsAsync(Roles.Doctor)) await _roleManager.CreateAsync(new IdentityRole(Roles.Doctor));
            await _userManager.AddToRoleAsync(user, Roles.Doctor);
            return Ok(doctor);
        }

    }
}
