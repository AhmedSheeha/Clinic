using Clinic.DTO;

namespace Clinic.Repositories.IRepos
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        public Task<bool> CreateAttendance(AttendanceDto attendance, int DoctorrId);
    }
}
