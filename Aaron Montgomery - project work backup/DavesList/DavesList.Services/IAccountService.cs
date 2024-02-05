using DavesList.Models;

namespace DavesList.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(string username, string password);
    }
}
