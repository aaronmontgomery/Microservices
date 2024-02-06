using Microsoft.AspNetCore.Identity;
using Identity.Entities;
using DavesList.Models;

namespace DavesList.Services
{
    public interface IAccountService
    {
        Task<bool> AddTestAccountAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager);

        Task<LoginResponse> LoginAsync(string username, string password);
    }
}
