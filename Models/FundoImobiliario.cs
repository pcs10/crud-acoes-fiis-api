using System;

namespace CrudSimplesApiFiis.Models
{
    public class FundoImobiliario
    {
        public int Id { get; set; }
        public string Papel { get; set; } //antigo Nome - HGLG11
        public string NomeFundo{ get; set; } // nome completo do hglg
        public string Administradora{ get; set; } //vai virar fk futuramente
        public decimal ValorPatrimonial { get; set; }
        public decimal PatrimonioLiquido { get; set; }
        public DateTime DataIpo { get; set; }
        public string CotasEmitidas {get; set; }
        public string Cnpj { get; set; }
        public string PublicoAlvo { get; set; } // vai virar enum futuramente
        public string Categoria { get; set; } // vai virar fk futuramente
        public decimal TaxaAdministracao { get; set; }
        public bool Ativo { get; set; }

    }
}
