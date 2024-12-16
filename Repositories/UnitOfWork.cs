using Clinic.Repositories.IRepos;

namespace Clinic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IApplicationUserRepository UserRepository { get; set; }
        public IAppointmentRepository AppointmentRepository { get; private set; }

        public IAttendanceRepository AttendanceRepository { get; private set; }

        public IDoctorRepository DoctorRepository { get; private set; }

        public IPatientRepository PatientRepository { get; private set; }
        public IDoctorAvilabilityRepository AvilabilityRepository { get; private set; }
        public ISpecializationRepository SpecializationRepository { get; private set; }

        private readonly ApplicationDbContext Context;
        public UnitOfWork(ApplicationDbContext db)
        {
            Context = db;
            UserRepository = new ApplicationUserRepository(Context);
            AppointmentRepository = new AppointmentRepository(Context);
            AttendanceRepository = new AttendanceRepository(Context);
            DoctorRepository = new DoctorRepository(Context);
            PatientRepository = new PatientRepository(Context);
            AvilabilityRepository = new DoctorAvailabilityRepository(Context);
            SpecializationRepository = new SpecializationRepository(Context);

        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
