using System.Data.Entity.ModelConfiguration;
using OutXApp.Core.Models;

namespace OutXApp.Persistence.EntityConfigurations
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
        }
    }
}