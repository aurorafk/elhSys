using System.Collections.Generic;
using OutXApp.Core.Models;
using OutXApp.Core.ViewModel;

namespace OutXApp.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}