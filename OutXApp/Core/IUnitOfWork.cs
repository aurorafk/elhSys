using OutXApp.Core.Repositories;

namespace OutXApp.Core
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
        IAppointmentRepository Appointments { get; }
        IAttendanceRepository Attandences { get; }
        ICityRepository Cities { get; }
        IDoctorRepository Doctors { get; }
        ISpecializationRepository Specializations { get; }
        IApplicationUserRepository Users { get; }

        void Complete();
    }
}