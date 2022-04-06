using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelProjesi.Models;

namespace ExcelProjesi.Data
{
    public class ApplicationContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}

