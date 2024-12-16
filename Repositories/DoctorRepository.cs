using Clinic.DTO;
using Clinic.Repositories.IRepos;

namespace Clinic.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<bool> AddDoctor(DoctorDto doctor)
        {
            var Doctor = new Doctor
            {
                Name = doctor.Name,
                Phone = doctor.Phone,
                Address = doctor.Address,
                SpecializationId = doctor.SpecializationId,
                Email = doctor.Email,
            };
            await Add(Doctor);
            return true;
        }
        
    }
}
