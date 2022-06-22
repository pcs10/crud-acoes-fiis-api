using CrudSimplesApiFiis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaModel>> BuscarTodos();
    }
}
