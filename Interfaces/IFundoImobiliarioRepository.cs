using CrudSimplesApiFiis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Interfaces
{
    public interface IFundoImobiliarioRepository
    {
        Task<IEnumerable<FundoImobiliario>> BuscarTodos();
        Task<FundoImobiliario> BuscarPorId(int id);
        Task<string> Inserir(FundoImobiliario fundoImobiliario);
        Task <string> Alterar(FundoImobiliario fundoImobiliario, int id);
        Task<string> Excluir(int id);
    }
}
