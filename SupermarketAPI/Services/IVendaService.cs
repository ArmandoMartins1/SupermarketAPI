using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Services
{
    public interface IVendaService
    {
        void RegistrarVenda(int produtoId, int quantidade);
        decimal ObterValorTotalVendas(DateTime inicio, DateTime fim);
    }
}