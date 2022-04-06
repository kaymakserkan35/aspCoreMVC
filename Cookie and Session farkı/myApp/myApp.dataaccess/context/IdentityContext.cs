
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myApp.entitiy.IdentityEntities;

namespace myApp.dataaccess.context
{
    public class IdentityContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseMySql
                (connectionString:
                "server=localhost;port=3306;database=identitydb;user=root;password=nyks6957!");

        }




    }
}
