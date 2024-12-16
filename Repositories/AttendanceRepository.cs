using Clinic.DTO;
using Clinic.Repositories.IRepos;

namespace Clinic.Repositories
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> CreateAttendance(AttendanceDto attendance, int DoctorId)
        {
            var Att = new Attendance()
            {
                ClinicRemarks = attendance.ClinincRemarks,
                Diagnosis = attendance.Diagnosis,
                SecondDiagnosis = attendance.SecondDiagnosis,
                ThirdDiagnosis = attendance.ThirdDianosis,
                Therapy = attendance.Therepy,
                PatientId = attendance.PatientId,
                DoctorId = DoctorId,
            };
            await Add(Att);
            return true;
        }
    }
}
