using System.Data.Entity.ModelConfiguration;
using OutXApp.Core.Models;

namespace OutXApp.Persistence.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(p => p.CityId).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(255);
            Property(p => p.Phone).IsRequired().HasMaxLength(255);
            Property(p => p.Address).IsRequired().HasMaxLength(255);
            Property(p => p.BirthDate).IsRequired();
            Property(p => p.Token).IsRequired();
            HasMany(p => p.Appointments)
                .WithRequired(a => a.Course)
                .WillCascadeOnDelete(false);
        }
    }
}