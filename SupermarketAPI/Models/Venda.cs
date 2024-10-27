using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }

        public Produto Produto { get; set; }
    }
}