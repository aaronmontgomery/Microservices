using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
        //public int RoleId { get; set; }
        //public int UserId { get; set; }

        public virtual ApplicationRole Role { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
