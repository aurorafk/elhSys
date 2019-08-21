using OutXApp.Core;
using OutXApp.Core.Repositories;
using OutXApp.Persistence.Repositories;

namespace OutXApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICourseRepository Courses { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAttendanceRepository Attandences { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Courses = new CourseRepository(context);
            Appointments = new AppointmentRepository(context);
            Attandences = new AttendanceRepository(context);
            Cities = new CityRepository(context);
            Doctors = new DoctorRepository(context);
            Specializations = new SpecializationRepository(context);
            Users = new ApplicationUserRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}