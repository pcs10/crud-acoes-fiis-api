using CrudSimplesApiFiis.Data;
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
        [HttpGet]
        [Route(template: "fundos-imobiliarios")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var fundosImobiliarios = await context
                .FundosImobiliarios
                .AsNoTracking()
                .ToListAsync();
            return Ok(fundosImobiliarios);
        }

        [HttpGet]
        [Route(template: "fundos-imobiliarios/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var fundoImobiliario = await context.FundosImobiliarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return fundoImobiliario == null ? NotFound() : Ok();
        }

        [HttpPost(template: "fundos-imobiliarios")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] FundoImobiliario fiiModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fundoImobiliario = new FundoImobiliario
            {
                /*Nome = fiiModel.Nome,
                ValorPatrimonial = fiiModel.ValorPatrimonial,
                PatrimonioLiquido = fiiModel.PatrimonioLiquido,
                DataIpo = fiiModel.DataIpo,
                CotasEmitidas = fiiModel.CotasEmitidas,
                Cnpj = fiiModel.Cnpj,
                PublicoAlvo = fiiModel.PublicoAlvo,
                TaxaAdministracao = fiiModel.TaxaAdministracao,
                Ativo = fiiModel.Ativo*/
            };

            try
            {
                await context.FundosImobiliarios.AddAsync(fundoImobiliario);
                await context.SaveChangesAsync();
                return Created($"v1/fundos-imobiliarios/{fundoImobiliario.Id}", fundoImobiliario);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Inicio Erro -> " + e);
                return BadRequest();
            }
        }



        [HttpPut(template: ("fundos-imobiliarios/{id}"))]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] FundoImobiliario fiiModel, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fundoImobiliario = await context
                .FundosImobiliarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (fundoImobiliario == null)
                return NotFound();

            try
            {
               /* fundoImobiliario.Nome = fiiModel.Nome;
                fundoImobiliario.ValorPatrimonial = fiiModel.ValorPatrimonial;
                fundoImobiliario.PatrimonioLiquido = fiiModel.PatrimonioLiquido;
                fundoImobiliario.DataIpo = fiiModel.DataIpo;
                fundoImobiliario.CotasEmitidas = fiiModel.CotasEmitidas;
                fundoImobiliario.Cnpj = fiiModel.Cnpj;
                fundoImobiliario.PublicoAlvo = fiiModel.PublicoAlvo;
                fundoImobiliario.TaxaAdministracao = fiiModel.TaxaAdministracao;
                fundoImobiliario.Ativo = fiiModel.Ativo;*/

                //inserindo no banco
                context.FundosImobiliarios.Update(fundoImobiliario);
                await context.SaveChangesAsync();

                return Ok(fundoImobiliario);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Inicio Erro -> " + e);
                return BadRequest();
            }

        }

        [HttpDelete(template: "fundos-imobiliarios/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var fundoImobiliario = await context
                .FundosImobiliarios
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.FundosImobiliarios.Remove(fundoImobiliario);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Inicio Erro -> " + e);
                return BadRequest();
            }
        }


    } //public class FundoImobiliarioController
}
