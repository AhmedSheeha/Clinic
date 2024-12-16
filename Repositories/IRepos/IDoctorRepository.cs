using Clinic.DTO;

namespace Clinic.Repositories.IRepos
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public Task<bool> AddDoctor(DoctorDto doctor);
    }
}
