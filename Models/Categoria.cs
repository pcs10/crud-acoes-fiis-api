using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CrudSimplesApiFiis.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O nome da categoria precisa ter entre 2 e 30 caracteres")]
        public string Nome { get; set; }
        public ICollection<FundoImobiliario> FundosImobiliarios { get; set; }

    }
}
