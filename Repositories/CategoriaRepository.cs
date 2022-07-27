using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Repositories
{

    public class CategoriaRepository : ICategoriaRepository
    {

        //deixar o contexto fora para que nao precise toda horas ficar passando ele entre parametros
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Alterar(Categoria categoria, int id)
        {
            if (await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id) == null)
            {
                return "Categoria não encontrada";
            }

            return "";

        }//alterar

        public async Task<IEnumerable<Categoria>> BuscarTodos()
        {
            var categorias = await _context
                            .Categorias
                            .Include(fii => fii.FundosImobiliarios)
                            .AsNoTracking()
                            .ToListAsync();
            Console.WriteLine(categorias.ToString());
            return categorias;
        }// buscar todos

        public async Task<string> Inserir(Categoria categoria)
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
