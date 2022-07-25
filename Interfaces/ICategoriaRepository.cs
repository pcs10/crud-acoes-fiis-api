using CrudSimplesApiFiis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaModel>> BuscarTodos();
        Task<string> Inserir(CategoriaModel categoria);
        Task<string> Alterar(CategoriaModel categoria, int id);

        //Task<ICollection<Aluno>> BuscarTodos();
    }
}
