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
            var categoriaFii = await _context
                .Categorias
                .Include(f => f.FundosImobiliarios)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoriaFii == null)
            {
                return "Categoria não encontrada";
            }
            else
            {
                categoriaFii.Nome = categoria.Nome == null ? categoriaFii.Nome : categoria.Nome;
            }

            try
            {
                _context.Categorias.Update(categoriaFii);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar -> " + ex;
            }


        }//alterar

        public async Task<Categoria> BuscarPorId(int id)
        {
            var categoria = await _context
                 .Categorias
                 .Include(f => f.FundosImobiliarios)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return categoria;
        }

        public async Task<IEnumerable<Categoria>> BuscarTodos()
        {
            var categorias = await _context
                            .Categorias
                            //.Include(fii => fii.FundosImobiliarios)
                            .AsNoTracking()
                            .ToListAsync();

            return categorias;
        }// buscar todos

        public async Task<string> Excluir(int id)
        {
            var categoria = await _context
                 .Categorias
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null) return "Categoria não encontrado";

            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir -> " + ex;
            }
        }

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
