using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationUserClaim : IdentityUserClaim<int>
    {
        //public int Id { get; set; }
        //public string ClaimType { get; set; } = null!;
        //public string ClaimValue { get; set; } = null!;
        //public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
