using System;
using System.Collections.Generic;

namespace RevendooWebAPI.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            VendasProdutos = new HashSet<VendasProdutos>();
        }

        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? Validade { get; set; }
        public string CaminhoFoto { get; set; }

        public virtual ICollection<VendasProdutos> VendasProdutos { get; set; }
    }
}
