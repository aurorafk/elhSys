using System.Collections.Generic;
using OutXApp.Core.Models;

namespace OutXApp.Core.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
    }
}