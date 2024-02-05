using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        //public int Id { get; set; }
        //public string ClaimType { get; set; } = null!;
        //public string ClaimValue { get; set; } = null!;
        //public int RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; } = null!;
    }
}
