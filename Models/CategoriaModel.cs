using System.Collections.Generic;

namespace CrudSimplesApiFiis.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<FundoImobiliarioModel> FundosImobiliarios { get; set; }


    }
}
