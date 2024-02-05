using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Entities
{
    public partial class ApplicationUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
        //public string LoginProvider { get; set; } = null!;
        //public string Name { get; set; } = null!;
        //public int UserId { get; set; }
        //public string Value { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
