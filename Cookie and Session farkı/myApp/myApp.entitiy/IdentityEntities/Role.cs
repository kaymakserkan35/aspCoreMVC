using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.entitiy.IdentityEntities
{

    public class Role : IdentityRole<int>
    {

        public Role()
        {
            roleclaims = new HashSet<RoleClaim>();
            userRoles = new HashSet<UserRole>();
        }

        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string NormalizedName { get; set; }
        public override string ConcurrencyStamp { get; set; }

        public virtual ICollection<RoleClaim> roleclaims { get; set; }
        public virtual ICollection<UserRole> userRoles { get; set; }


    }
}

