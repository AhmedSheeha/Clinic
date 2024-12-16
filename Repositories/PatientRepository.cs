using Clinic.DTO;
using Clinic.Repositories.IRepos;

namespace Clinic.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
            public async Task<Patient> AddPatient(PatientDto p)
        {
            var Patient = new Patient
            {
                Name = p.Name,
                Gender = p.Gender,
                BirthDate = p.BirthDate,
                Phone = p.Phone,
                Height = p.Height,
                Weight = p.Weight,
            };
            await Add(Patient);
            return Patient;
        }
    }
}
