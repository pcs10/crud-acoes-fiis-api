using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimplesApiFiis.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundoImobiliario>()
                .HasMany(c => c.Categorias)
               .WithMany(fii => fii.FundosImobiliarios)
               .UsingEntity(cf => cf.ToTable("CategoriaFundoImobiliario"));
        }

        public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;cache=shared");

    }


}
