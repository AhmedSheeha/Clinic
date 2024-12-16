using Clinic.DTO;
using Clinic.Models;
using Clinic.Repositories.IRepos;

namespace Clinic.Repositories
{
    public class DoctorAvailabilityRepository : Repository<DoctorAvailability>, IDoctorAvilabilityRepository
    {
        public DoctorAvailabilityRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task MakeAvailableSlotsAsync(DoctorAvailabilityDto doctorAvailability)
        {
            var SlotStart = doctorAvailability.Start;
            var SlotEnd = SlotStart.AddMinutes(30);
            while (SlotEnd >= doctorAvailability.End)
            {
                var slot = new DoctorAvailability
                {
                    DoctorId = doctorAvailability.DoctorId,
                    StartTime = SlotStart,
                    EndTime = SlotEnd,
                    Available = true,
                    Day = doctorAvailability.Start.DayOfWeek,
                };
                await Add(slot);
                SlotStart = SlotEnd;
                SlotEnd = SlotEnd.AddMinutes(30);
            }
        }

        public async Task<bool> Reserve(DateTime Start, int DoctorId)
        {
            var slot = await GetFirstOrDefault(s => s.DoctorId == DoctorId && s.StartTime == Start && s.Available == true);
            if(slot == null) return false;
            slot.Available = false;
            return true;
        }
    }
}
