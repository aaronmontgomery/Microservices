﻿using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Identity.Services;
using DavesList.Models;
using DavesList.Models.Enums;
using Identity.Entities;

namespace DavesList.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityAccountService _identityAccountService;

        public AccountService(IIdentityAccountService identityAccountService)
        {
            _identityAccountService = identityAccountService;
        }
        
        public async Task<bool> AddTestAccountAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            ApplicationUser defaultApplicationUser;
            ApplicationRole defaultApplicationRole;
            ApplicationUser applicationUser;
            ApplicationRole applicationRole;
            
            defaultApplicationUser = new ApplicationUser()
            {
                UserName = "default",
                Email = "default@email.com",
                PhoneNumber = "000-000-0000",
            };
            
            defaultApplicationRole = new ApplicationRole()
            {
                Name = "Administrators"
            };

            applicationUser = await userManager.FindByNameAsync(defaultApplicationUser.UserName);
            applicationRole = await roleManager.FindByNameAsync(defaultApplicationRole.Name);
            if (applicationUser == null && applicationRole == null)
            {
                await roleManager.CreateAsync(defaultApplicationRole);
                await userManager.CreateAsync(defaultApplicationUser, "Testpassword#1");
                await userManager.AddToRolesAsync(defaultApplicationUser, new string[] { defaultApplicationRole.Name });
            }
            
            return true;
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
