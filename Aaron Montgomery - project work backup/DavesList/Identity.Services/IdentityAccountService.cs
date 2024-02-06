using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Identity.Entities;

namespace Identity.Services
{
    public class IdentityAccountService : IIdentityAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public IdentityAccountService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
        }

        public string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hb23h872be_$da11fvh8b1@^&$%_dvdjf"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public async Task<bool> IsUserExistsAsync(string userName, string password)
        {
            ApplicationUser applicationUser;
            bool isPassword;

            applicationUser = await _userManager.FindByNameAsync(userName);
            isPassword = await _userManager.CheckPasswordAsync(applicationUser, password);
            return isPassword;
        }

        //public async Task<bool> SignIn(string username, string password)
        //{
        //    bool isSuccess;
        //    bool isPassword;

        //    var applicationUser = await _userManager.FindByNameAsync(username);
        //    isPassword = await _userManager.CheckPasswordAsync(applicationUser, password);
        //    //var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(applicationUser);
        //    //bool isCanSignIn = _signInManager.IsSignedIn(claimsPrincipal);
        //    //await _signInManager.SignInAsync(applicationUser, false);
        //    //await _signInManager.SignOutAsync();
        //    //_userManager.GenerateTwoFactorTokenAsync(applicationUser, new TokenProviderDescriptor() );

        //    isSuccess = true;
        //    return isSuccess;
        //}
    }
}
