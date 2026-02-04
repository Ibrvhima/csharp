using Microsoft.EntityFrameworkCore;
using CrudMySQL.Classic.Models;

namespace CrudMySQL.Classic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nom).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Prix).IsRequired().HasPrecision(10, 2);
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Categorie).IsRequired();
                entity.Property(p => p.DateCreation).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
