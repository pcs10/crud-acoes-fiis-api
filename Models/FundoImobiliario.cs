using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudSimplesApiFiis.Models
{
    public class FundoImobiliario
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "O papel do fundo precisa ter entre 6 e 8 caracteres")]
        public string Papel { get; set; } //antigo Nome - HGLG11

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome do fundo precisa ter entre 5 e 100 caracteres")]
        public string NomeFundo{ get; set; } // nome completo do hglg


        public string Administradora{ get; set; } //vai virar fk futuramente


        [Required,Column(TypeName = "DECIMAL(18,2)")]
        public decimal ValorPatrimonial { get; set; }


        public decimal PatrimonioLiquido { get; set; }


        [Required, Column(TypeName = "DATE")]
        public DateTime DataIpo { get; set; }


        public string CotasEmitidas {get; set; }


        public string Cnpj { get; set; }


        public string PublicoAlvo { get; set; } // vai virar enum futuramente


        public ICollection<Categoria> Categorias { get; set; }


        public decimal TaxaAdministracao { get; set; }


        public string Ativo { get; set; }

    }
}
