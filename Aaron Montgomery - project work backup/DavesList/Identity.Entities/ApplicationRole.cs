using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {
            ApplicationRoleClaims = new HashSet<ApplicationRoleClaim>();
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        //public int Id { get; set; }
        //public string ConcurrencyStamp { get; set; } = null!;
        //public string Name { get; set; } = null!;
        //public string NormalizedName { get; set; } = null!;

        public virtual ICollection<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
