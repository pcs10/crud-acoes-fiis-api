using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimplesApiFiis.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           //relacionamento de muitos para muitos
            modelBuilder.Entity<FundoImobiliario>()
                .HasMany(c => c.Categorias)
               .WithMany(fii => fii.FundosImobiliarios)
               .UsingEntity(cf => cf.ToTable("CategoriaFundoImobiliario"));
        }

        //Referenciando models a tabelas do banco
        public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;cache=shared");

    }


}
