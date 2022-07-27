using CrudSimplesApiFiis.Data;
using CrudSimplesApiFiis.Interfaces;
using CrudSimplesApiFiis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Repositories
{
    public class FundoImobiliarioRepository : IFundoImobiliarioRepository
    {
        private readonly AppDbContext _context;
        public FundoImobiliarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Alterar(FundoImobiliario fundoImobiliario, int id)
        {
            var fii = await _context
                .FundosImobiliarios
                .Include(c => c.Categorias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (fii == null)
            {
                return "Fundo Imobiliario não encontrado";
            }
            else
            {
                fii.Papel = fundoImobiliario.Papel == null ? fii.Papel : fundoImobiliario.Papel;
                fii.NomeFundo = fundoImobiliario.NomeFundo;
                fii.Administradora = fundoImobiliario.Administradora;
                fii.ValorPatrimonial = fundoImobiliario.ValorPatrimonial;
                fii.PatrimonioLiquido = fundoImobiliario.PatrimonioLiquido;
                fii.DataIpo = fundoImobiliario.DataIpo;
                fii.CotasEmitidas = fundoImobiliario.CotasEmitidas == null ? fii.CotasEmitidas : fundoImobiliario.CotasEmitidas;
                fii.Cnpj = fundoImobiliario.Cnpj;
                fii.PublicoAlvo = fundoImobiliario.PublicoAlvo;
                fii.TaxaAdministracao = fundoImobiliario.TaxaAdministracao;
                fii.Ativo = fundoImobiliario.Ativo;
                fii.PublicoAlvo = fundoImobiliario.PublicoAlvo;

            }

            try
            {
                _context.FundosImobiliarios.Update(fii);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir -> " + ex;
            }

        }

        public async Task<FundoImobiliario> BuscarPorId(int id)
        {
            var fundoImobiliario = await _context
                .FundosImobiliarios
                .Include(c => c.Categorias)
                .FirstOrDefaultAsync(x => x.Id == id);

            return fundoImobiliario;
        }

        public async Task<IEnumerable<FundoImobiliario>> BuscarTodos()
        {
            var fundosImobiliarios = await _context
                .FundosImobiliarios
                .Include(c => c.Categorias)
                .AsNoTracking()
                .ToListAsync();

            return fundosImobiliarios;
        }

        public async Task<string> Excluir(int id)
        {
            var fundoImobiliario = await _context
                .FundosImobiliarios
                .FirstOrDefaultAsync(x => x.Id == id);

            if (fundoImobiliario == null) return "Fundo Imobiliario não encontrado";

            try
            {
                _context.FundosImobiliarios.Remove(fundoImobiliario);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir -> " + ex;
            }
        }//excluir

        public async Task<string> Inserir(FundoImobiliario fundoImobiliario)
        {
            var fii = new FundoImobiliario
            {
                Papel = fundoImobiliario.Papel,
                NomeFundo = fundoImobiliario.NomeFundo,
                Administradora = fundoImobiliario.Administradora,
                ValorPatrimonial = fundoImobiliario.ValorPatrimonial,
                PatrimonioLiquido = fundoImobiliario.PatrimonioLiquido,
                DataIpo = fundoImobiliario.DataIpo,
                CotasEmitidas = fundoImobiliario.CotasEmitidas,
                Cnpj = fundoImobiliario.Cnpj,
                PublicoAlvo = fundoImobiliario.PublicoAlvo,
                TaxaAdministracao = fundoImobiliario.TaxaAdministracao,
                Ativo = fundoImobiliario.Ativo
            };
            //fazer validações com informações da variavel temporaria

            try
            {
                await _context.FundosImobiliarios.AddAsync(fundoImobiliario);
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao inserir -> " + ex;
            }
        }//inserir
    }
}
