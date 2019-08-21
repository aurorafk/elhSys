using OutXApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace OutXApp.Persistence.EntityConfigurations
{
    public class AppointmentConfiguration : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfiguration()
        {
            Property(a => a.CourseId).IsRequired();
            Property(a => a.DoctorId).IsRequired();
            Property(a => a.StartDateTime).IsRequired();
            Property(a => a.Detail).IsRequired();
            Property(a => a.Status).IsRequired();
        }
    }
}