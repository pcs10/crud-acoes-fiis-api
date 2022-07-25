using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaRepository _categoriaService;

        public CategoriaController(ICategoriaRepository categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route(template: "categorias")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            try
            {
                return Ok(await _categoriaService.BuscarTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }// listar todos

        [HttpPost(template: "categorias")]
        public async Task<IActionResult> InserirAsync(
          [FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _categoriaService.Inserir(categoriaModel);

                if ((erro == null) || erro == "")
                    return Created($"v1/categorias/{categoriaModel.Id}", categoriaModel);
                else
                    return BadRequest("ERRO -> " + erro.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//inserir

        [HttpPut(template: ("categorias/{id}"))]
        public async Task<IActionResult> AlterarAsync([FromBody] CategoriaModel categoriaModel, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _categoriaService.Alterar(categoriaModel, id);

                if ((erro == null) || erro == "")
                    return Ok(categoriaModel);
                else
                    return BadRequest("ERRO -> " + erro.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        }

        /*
          [HttpGet]
        [Route(template: "alunos")]
        public async Task<ActionResult<IEnumerable<Aluno>>> ListarTodosAsync()
        {
            try
            {
                return Ok(await _alunoService.BuscarTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }// listar todos
*/



    }




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
