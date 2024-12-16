using Clinic.DTO;
using Clinic.Models;

namespace Clinic.Repositories.IRepos
{
    public interface IDoctorAvilabilityRepository : IRepository<DoctorAvailability>
    {
        public Task MakeAvailableSlotsAsync(DoctorAvailabilityDto doctorAvailabilityDto);
        public Task<bool> Reserve(DateTime Start, int DoctorId);
    }
}
