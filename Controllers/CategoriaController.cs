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

        [HttpGet]
        [Route(template: "categorias/{id}")]
        public async Task<IActionResult> ListarPorIdAsync([FromRoute] int id)
        {
            try
            {
                var categoria = await _categoriaService.BuscarPorId(id);

                if (categoria == null)
                {
                    return BadRequest("ERRO -> Categoria não encontrada");
                }
                else
                {
                    return Ok(categoria);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }//listar um

        [HttpPost(template: "categorias")]
        public async Task<IActionResult> InserirAsync([FromBody] Categoria categoriaModel)
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
        public async Task<IActionResult> AlterarAsync([FromBody] Categoria categoriaModel, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var categoria = await _categoriaService.Alterar(categoriaModel, id);

                if ((categoria == null) || categoria == "")
                    return Ok(categoria);
                else
                    return BadRequest("ERRO -> " + categoria);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        } //alterar

        [HttpDelete(template: "categorias/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var erro = await _categoriaService.Excluir(id);

                if ((erro == null) || erro == "")
                    return Ok("Categoria excluída com sucesso");
                else
                    return BadRequest("ERRO -> " + erro);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//excluir

    }
}

