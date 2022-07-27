using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class FundoImobiliarioController : ControllerBase
    {

        public readonly IFundoImobiliarioRepository _fundoImobiliarioService;

        public FundoImobiliarioController(IFundoImobiliarioRepository fundoImobiliarioService)
        {
            _fundoImobiliarioService = fundoImobiliarioService;
        }


        [HttpGet]
        [Route(template: "fundos-imobiliarios")]
        public async Task<IActionResult> ListarTodosAsync()
        {
            try
            {
                return Ok(await _fundoImobiliarioService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }//listar todos

        [HttpGet]
        [Route(template: "fundos-imobiliarios/{id}")]
        public async Task<IActionResult> ListarPorIdAsync([FromRoute] int id)
        {
            try
            {
                var fundoImobiliario = await _fundoImobiliarioService.BuscarPorId(id);

                if (fundoImobiliario == null)
                {
                    return BadRequest("ERRO -> Fundo imobiliario não encontrado");
                }
                else
                {
                    return Ok(fundoImobiliario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }//listar um

        [HttpPost(template: "fundos-imobiliarios")]
        public async Task<IActionResult> InserirAsync([FromBody] FundoImobiliario fundoImobiliario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _fundoImobiliarioService.Inserir(fundoImobiliario);

                if ((erro == null) || erro == "")
                    return Created($"v1/fundos-imobiliarios/{fundoImobiliario.Id}", fundoImobiliario);
                else
                    return BadRequest("ERRO -> " + erro.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }
        }//inserir

        [HttpPut(template: ("fundos-imobiliarios/{id}"))]
        public async Task<IActionResult> PutAsync([FromBody] FundoImobiliario fundoImobiliario, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var erro = await _fundoImobiliarioService.Alterar(fundoImobiliario, id);

                if ((erro == null) || erro == "")
                    return Ok();
                else
                    return BadRequest("ERRO -> " + erro);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        }// alterar 

        [HttpDelete(template: "fundos-imobiliarios/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var erro = await _fundoImobiliarioService.Excluir(id);

                if ((erro == null) || erro == "")
                    return Ok("Fundo imobiliario excluido com sucesso");
                else
                    return BadRequest("ERRO -> " + erro);
            }
            catch (Exception ex)
            {
                return BadRequest("ERRO -> " + ex);
            }

        }//excluir

    } //public class FundoImobiliarioController
}
