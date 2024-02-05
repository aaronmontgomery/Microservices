using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            ApplicationUserClaims = new HashSet<ApplicationUserClaim>();
            ApplicationUserLogins = new HashSet<ApplicationUserLogin>();
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
            ApplicationUserTokens = new HashSet<ApplicationUserToken>();
        }

        //public int Id { get; set; }
        //public int AccessFailedCount { get; set; }
        //public string ConcurrencyStamp { get; set; } = null!;
        //public string Email { get; set; } = null!;
        //public bool EmailConfirmed { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public DateTimeOffset? LockoutEnd { get; set; }
        //public string NormalizedEmail { get; set; } = null!;
        //public string NormalizedUserName { get; set; } = null!;
        //public string PasswordHash { get; set; } = null!;
        //public string PhoneNumber { get; set; } = null!;
        //public bool PhoneNumberConfirmed { get; set; }
        //public string SecurityStamp { get; set; } = null!;
        //public bool TwoFactorEnabled { get; set; }
        //public string UserName { get; set; } = null!;

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual ICollection<ApplicationUserToken> ApplicationUserTokens { get; set; }
    }
}
