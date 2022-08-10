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
        [Column(TypeName = "VARCHAR(10)")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "O papel do fundo precisa ter entre 6 e 8 caracteres")]
        public string Papel { get; set; } //antigo Nome - HGLG11

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome do fundo precisa ter entre 5 e 100 caracteres")]
        public string NomeFundo { get; set; } // nome completo do hglg


        public string Administradora { get; set; } //vai virar fk futuramente


        [Required, Column(TypeName = "DECIMAL(18,2)")]
        public decimal ValorPatrimonial { get; set; }


        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal? PatrimonioLiquido { get; set; }


        [Required, Column(TypeName = "DATE")]
        public DateTime? DataIpo { get; set; }

        [Column(TypeName = "INTEGER")]
        public int CotasEmitidas { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(14)")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ precisa ter 14 digitos")]
        public string Cnpj { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O publico alvo precisa ter entre 5 e 50 caracteres")]
        public string PublicoAlvo { get; set; } // vai virar enum futuramente


        public ICollection<Categoria> Categorias { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal? TaxaAdministracao { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(1)")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "O Campo Ativo só pode conter um caracter")]
        public string Ativo { get; set; } //flag pra saber se o fundo está ativo ou inativo - (A / I)

    }
}
