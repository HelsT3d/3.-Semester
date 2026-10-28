using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepititionMinimalAPI.Data
{
    public class MinimalAPIDbContext : IdentityDbContext<IdentityUser>
    {

        public MinimalAPIDbContext(DbContextOptions<MinimalAPIDbContext> options) : base(options)
        {

        }
        public DbSet<Case> Case { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Case>().HasData(
                new Case { Id=1, Name = "Rasmus", LocationFound = "Esbjerg", DateFound = new DateOnly(2026, 10, 1), IsClaimed = false },
                new Case { Id=2, Name = "Rasmus", LocationFound = "Esbjerg", DateFound = new DateOnly(2013, 11, 5), IsClaimed = true },
                new Case { Id=3, Name = "Rasmus", LocationFound = "Rønne", DateFound = new DateOnly(2004, 9, 12), IsClaimed = false }
                );
           
        }
    }
}
