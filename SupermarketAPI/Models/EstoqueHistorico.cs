using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Models
{
    public class EstoqueHistorico
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string TipoOperacao { get; set; } 
        public DateTime DataOperacao { get; set; }

        public Produto Produto { get; set; }
    }
}