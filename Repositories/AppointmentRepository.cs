using Clinic.DTO;
using Clinic.Repositories.IRepos;
using Microsoft.Identity.Client;

namespace Clinic.Repositories
{
    public class AppointmentRepository : Repository<AppointMent>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public async Task<bool> MakeDone(int Id)
        {
            var Apt = await GetFirstOrDefault(x => x.Id == Id);
            if(Apt == null) return false;
            Apt.Status = true;
            return true;
        }

        public async Task<AppointMent> CreateAsync(AppointmentDto appointment)
        {
            var apt = new AppointMent()
            {
                StartDateTime = appointment.Start,
                DoctorId = appointment.DoctorId,
                Detail = appointment.Details,
                PatientId = appointment.PatientId,
                Status = true
            };
            await Add(apt);
            return apt;
        }
    }
}
