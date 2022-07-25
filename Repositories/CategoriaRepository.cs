using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Repositories
{
    /* testeeeeee
    public async Task<ICollection<Aluno>> BuscarTodos()
        {

            var alunos = await _context
                            .Alunos
                            .Include(d => d.Disciplinas)
                            .AsNoTracking()
                            //.Where(a => a.Id == 1)
                            .ToListAsync();


            return alunos;
        }
*/
    public class CategoriaRepository : ICategoriaRepository
    {

        //deixar o contexto fora para que nao precise toda horas ficar passando ele entre parametros
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Alterar(CategoriaModel categoria, int id)
        {
            if (await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id) == null)
            {
                return "Categoria não encontrada";
            }

            return "";

        }//alterar

        public async Task<IEnumerable<CategoriaModel>> BuscarTodos()
        {
            var categorias = await _context
                            .Categorias
                            .AsNoTracking()
                            .ToListAsync();
            Console.WriteLine(categorias.ToString());
            return categorias;
        }// buscar todos

        public async Task<string> Inserir(CategoriaModel categoria)
        {
            if ((categoria.Nome == null) || (categoria.Nome == ""))
            {
                return "Nome da categoria não pode ser nulo";
            }
            else
            {
                try
                {
                    await _context.Categorias.AddAsync(categoria);
                    await _context.SaveChangesAsync();
                    return "";
                }
                catch (Exception ex)
                {
                    return "Erro ao inserir -> " + ex;
                }
            }
        }// Inserir
    }
}
