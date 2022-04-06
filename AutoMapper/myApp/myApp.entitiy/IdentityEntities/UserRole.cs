using Microsoft.AspNetCore.Identity;
using System;

namespace myApp.entitiy.IdentityEntities
{
    public partial class UserRole : IdentityUserRole<int>
    {
        public override int UserId { get; set; }
        public override int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
