using Clinic.DTO;

namespace Clinic.Repositories.IRepos
{
    public interface IAppointmentRepository : IRepository<AppointMent>
    {
        public Task<AppointMent> CreateAsync(AppointmentDto appointment);
        public Task<bool> MakeDone(int Id);
    }
}
