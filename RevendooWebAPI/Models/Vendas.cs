using System;
using System.Collections.Generic;

namespace RevendooWebAPI.Models
{
    public partial class Vendas
    {
        public Vendas()
        {
            VendasProdutos = new HashSet<VendasProdutos>();
        }

        public int VendaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? PrecoTotal { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<VendasProdutos> VendasProdutos { get; set; }
    }
}
