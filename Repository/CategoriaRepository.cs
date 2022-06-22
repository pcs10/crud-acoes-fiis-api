using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        //deixar o contexto fora para que nao precise toda horas ficar passando ele entre parametros
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CategoriaModel>> BuscarTodos()
        {
            var categorias = await _context
                            .Categorias
                            .AsNoTracking()
                            .ToListAsync();
            Console.WriteLine(categorias.ToString());
            return categorias;

        }

    }
}
