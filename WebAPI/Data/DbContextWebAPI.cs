using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WebAPI.Model;

namespace WebAPI.Data
{
    public class DbContextWebAPI : IdentityDbContext
    {
        public DbContextWebAPI(DbContextOptions<DbContextWebAPI> contextOptions) : base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasData(
                new Book
                {
                    Id = 1,
                    Title = "Life Of Bebber",
                    Author = "Bebber",
                    Year = 2003,
                    SalesPrice = 100,
                    PurchasePrice = 200,
                    
                },
                new Book
                {
                    Id = 2,
                    Title = "Life Of Findus",
                    Author = "Bebber",
                    Year = 2013,
                    SalesPrice = 170,
                    PurchasePrice = 250,
                });

        }

        public DbSet<Book> Books { get; set; }
    }
}
