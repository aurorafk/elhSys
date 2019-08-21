using System.Collections.Generic;
using System.Linq;
using OutXApp.Core.Dto;
using OutXApp.Core.Models;
using OutXApp.Core.Repositories;

namespace OutXApp.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }
    }
}