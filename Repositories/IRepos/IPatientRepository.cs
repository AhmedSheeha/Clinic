using Clinic.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Repositories.IRepos
{
    public interface IPatientRepository : IRepository<Patient>
    {

        public Task<Patient> AddPatient(PatientDto patient);
    }
}
