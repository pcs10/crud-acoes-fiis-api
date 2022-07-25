using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimplesApiFiis.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FundoImobiliarioModel> FundosImobiliarios { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        //public DbSet<Aluno> Alunos { get; set; }
       // public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;cache=shared");


    }
}
