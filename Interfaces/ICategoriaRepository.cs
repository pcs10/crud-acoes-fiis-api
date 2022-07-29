using CrudSimplesApiFiis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarTodos();
        Task<string> Inserir(Categoria categoria);
        Task<string> Alterar(Categoria categoria, int id);
        Task<Categoria> BuscarPorId(int id);
        Task<string> Excluir(int id);
    }
}
