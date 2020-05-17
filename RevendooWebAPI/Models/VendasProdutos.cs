using System;
using System.Collections.Generic;

namespace RevendooWebAPI.Models
{
    public partial class VendasProdutos
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal? PrecoParcial { get; set; }

        public virtual Produtos Produto { get; set; }
        public virtual Vendas Venda { get; set; }
    }
}
