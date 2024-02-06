using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Identity.Entities;
using Identity.Services;
using DavesList.Services;
using DavesList.Models;
using DavesList.Models.Enums;

namespace DavesList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityAccountService _identityAccountService;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityAccountService identityAccountService,
            IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _identityAccountService = identityAccountService;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("/addtestuser")]
        public async Task<IActionResult> AddTestUserAsync()
        {
            IActionResult actionResult;

            try
            {
                actionResult = Ok(await _accountService.AddTestAccountAsync(_userManager, _roleManager));
            }

            catch
            {
                actionResult = BadRequest();
            }
            
            return actionResult;
        }
        
        [Authorize]
        [HttpGet]
        [Route("/isloggedin")]
        public IActionResult IsLoggedIn()
        {
            IActionResult actionResult;

            try
            {
                actionResult = Ok(new IsLoggedInResponse()
                {
                    IsLoggedIn = true,
                    ServerAction = ServerAction.IsLoggedIn
                });
            }
            
            catch
            {
                actionResult = Redirect("/");
            }

            return actionResult;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            IActionResult actionResult;
            
            try
            {
                actionResult = Ok(await _accountService.LoginAsync(loginRequest.Username!, loginRequest.Password!));
            }

            catch
            {
                actionResult = BadRequest();
            }
            
            return actionResult;
        }

        [Authorize]
        [HttpPost]
        [Route("/logout")]
        public IActionResult Logout()
        {
            IActionResult actionResult;

            try
            {
                actionResult = Ok(new LogoutResponse()
                {
                    IsLoggedIn = false,
                    ServerAction = ServerAction.Logout
                });
            }

            catch
            {
                actionResult = Redirect("/");
            }

            return actionResult;
        }
    }
}
