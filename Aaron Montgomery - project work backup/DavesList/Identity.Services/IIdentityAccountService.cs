using System.Security.Claims;

namespace Identity.Services
{
    public interface IIdentityAccountService
    {
        //Task<bool> CreateSecurityTokenAsync();

        string GenerateJwtToken(IEnumerable<Claim> claims);
        
        Task<bool> IsUserExistsAsync(string userName, string password);
        
        //Task<bool> SignIn(string username, string password);
    }
}
