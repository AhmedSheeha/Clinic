using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Http;
using Clinic.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Net.WebSockets;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public ApplicationUserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return users;
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(ApplicationUserDto user)
        {
            ApplicationUser appUser = await _userManager.FindByEmailAsync(user.Email);
            if (user == null || !ModelState.IsValid || appUser != null) return BadRequest("The Data Was sent is Invalid");

            var newUser = new ApplicationUser()
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
            };
            await _userManager.CreateAsync(newUser, user.Password);
            if (!await _roleManager.RoleExistsAsync(Roles.User.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }
            await _userManager.AddToRoleAsync(newUser, Roles.User);
            var roles = new List<string> { Roles.User };
            var token = Auth.GenerateJwtToken(newUser, roles, _configuration);
            return Ok(token);
        }
        [HttpPost("Login")]
        public async Task<IActionResult?> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null || ModelState.IsValid == false) return BadRequest("Incorrect Credintials");
            bool result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (result == true)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(await Auth.GenerateJwtToken(user, roles, _configuration));
            }
            return BadRequest("Incorrect Credintials");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null) return BadRequest("There is no User Under This Email");
            await _userManager.DeleteAsync(user);
            return Ok(user);
        }
    };
}
