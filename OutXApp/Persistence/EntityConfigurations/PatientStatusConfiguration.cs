using System.Data.Entity.ModelConfiguration;
using OutXApp.Core.Models;

namespace OutXApp.Persistence.EntityConfigurations
{
    public class CourseStatusConfiguration : EntityTypeConfiguration<CourseStatus>
    {
        public CourseStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}