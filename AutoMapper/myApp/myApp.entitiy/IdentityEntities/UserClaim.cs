using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;



namespace myApp.entitiy.IdentityEntities
{
    public partial class UserClaim : IdentityUserClaim<int>
    {
        public override int Id { get; set; }
        public override int UserId { get; set; }
        public override string ClaimType { get; set; }
        public override string ClaimValue { get; set; }

        public virtual User User { get; set; }
    }
}
