using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
        //public string LoginProvider { get; set; } = null!;
        //public string ProviderDisplayName { get; set; } = null!;
        //public string ProviderKey { get; set; } = null!;
        //public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
