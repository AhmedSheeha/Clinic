namespace Clinic.Repositories.IRepos
{
    public interface IUnitOfWork
    {
        public IApplicationUserRepository UserRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }
        public IAttendanceRepository AttendanceRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IPatientRepository PatientRepository { get; }
        public ISpecializationRepository SpecializationRepository { get; }
        public IDoctorAvilabilityRepository AvilabilityRepository { get; }
        public Task SaveAsync();
    }
}
