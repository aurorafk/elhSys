using System.Collections.Generic;
using OutXApp.Core.Models;

namespace OutXApp.Core.Repositories
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetSpecializations();
    }
}
