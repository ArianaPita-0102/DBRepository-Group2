using DBRepository_Group2.Models;
using Microsoft.EntityFrameworkCore;


namespace DBRepository_Group2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Guest> Guests => Set<Guest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FullName).IsRequired();
                b.Property(x => x.Confirmed).IsRequired();
            });
        }
    }
}
