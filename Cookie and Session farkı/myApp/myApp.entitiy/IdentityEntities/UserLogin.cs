using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace myApp.entitiy.IdentityEntities
{
    public partial class UserLogin : IdentityUserLogin<int>
    {

        public override string LoginProvider { get; set; }
        public override string ProviderKey { get; set; }
        public override string ProviderDisplayName { get; set; }
        public override int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
