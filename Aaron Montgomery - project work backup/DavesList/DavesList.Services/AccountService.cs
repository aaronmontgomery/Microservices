using System.Security.Claims;
using Identity.Services;
using DavesList.Models;
using DavesList.Models.Enums;

namespace DavesList.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityAccountService _identityAccountService;

        public AccountService(IIdentityAccountService identityAccountService)
        {
            _identityAccountService = identityAccountService;
        }
        
        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            LoginResponse loginResponse;
            Claim[] claims;
            bool isUserExists;

            claims = new Claim[]
            {
                new Claim(ClaimTypes.Role, "Administrators"),
                new Claim(ClaimTypes.Name, username)
            };
            
            isUserExists = await _identityAccountService.IsUserExistsAsync(username, password);

            if (isUserExists)
            {
                loginResponse = new LoginResponse()
                {
                    ServerAction = ServerAction.Login,
                    Token = _identityAccountService.GenerateJwtToken(claims)
                };
            }

            else
            {
                loginResponse = new LoginResponse()
                {
                    ServerAction = ServerAction.Login,
                    Token = null
                };
            }

            return loginResponse;
        }
    }
}
