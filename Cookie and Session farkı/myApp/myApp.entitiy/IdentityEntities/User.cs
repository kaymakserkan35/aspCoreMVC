
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace myApp.entitiy.IdentityEntities
{
    public class User : IdentityUser<int>
    {


        public User()
        {
            userclaims = new HashSet<UserClaim>();
            userlogins = new HashSet<UserLogin>();
            userroles = new HashSet<UserRole>();
            usertokens = new HashSet<UserToken>();
        }

        public override int Id { get; set; }
        public override string UserName { get; set; }
        public override string NormalizedUserName { get; set; }
        public override string Email { get; set; }
        public override string NormalizedEmail { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string PasswordHash { get; set; }
        public override string SecurityStamp { get; set; }
        public override string ConcurrencyStamp { get; set; }
        public override DateTimeOffset? LockoutEnd { get; set; }
        public override string PhoneNumber { get; set; }
        public override bool PhoneNumberConfirmed { get; set; }
        public override bool TwoFactorEnabled { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }

        public virtual ICollection<UserClaim> userclaims { get; set; }
        public virtual ICollection<UserLogin> userlogins { get; set; }
        public virtual ICollection<UserRole> userroles { get; set; }
        public virtual ICollection<UserToken> usertokens { get; set; }

    }
}
