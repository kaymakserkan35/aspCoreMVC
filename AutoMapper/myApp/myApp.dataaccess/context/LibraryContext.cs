using Microsoft.EntityFrameworkCore;

using myApp.entitiy.LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.dataaccess.context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public LibraryContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseMySql
                (connectionString:
                "server=localhost;port=3306;database=librarydb;user=root;password=nyks6957!");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryBook>()
                .HasKey(x => new { x.BookId, x.CategoryId });

            modelBuilder.Entity<PublisherBook>()
                .HasKey(x => new { x.PublisherId, x.BookId });

        }


    }
}
