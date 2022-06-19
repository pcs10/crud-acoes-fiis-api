using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using CrudSimplesApiFiis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route(template: "categorias")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var categorias = await context
                .Categorias
                .AsNoTracking()
                .ToListAsync();
            return Ok(categorias);
        }

        [HttpGet]
        [Route(template: "categorias2")]
        public async Task<IActionResult> GetAsync2()
        {
            try
            {
                Console.WriteLine("------------| Entrou 1 |---------------------");
                return Ok (await _categoriaService.BuscarTodos());
               // return Ok(await buscarTodos());

            }
            catch (Exception ex)
            {
                Console.WriteLine("------------| Entrou 4 |---------------------");
                return BadRequest(ex.ToString());
            }
        //
        }

        //depois eu vou externalizar esse método - isso é apenas o começo pra separar a lógica dos controllers
       /* public async Task<IEnumerable<CategoriaModel>> buscarTodos()
        {
            Console.WriteLine("------------| Entrou 9 |---------------------");
            var categorias = await _context
                .Categorias
                .AsNoTracking()
                .ToListAsync();
            Console.WriteLine(categorias.ToString());
            Console.WriteLine("------------| Entrou 10 |---------------------");
            return categorias;
        }
       */

    }




}
