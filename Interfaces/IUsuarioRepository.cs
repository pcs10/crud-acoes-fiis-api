using CrudSimplesApiFiis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscarTodos();
        Task<string> Inserir(Usuario usuario);
        Task<string> Alterar(Usuario usuario, int id);
        Task<Usuario> BuscarPorId(int id);
        Task<string> Excluir(int id);
    }
}
