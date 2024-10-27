using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services
{
    public interface IEstoqueService
    {
        void RegistrarEntrada(int produtoId, int quantidade);
        void RegistrarSaida(int produtoId, int quantidade);
        IEnumerable<EstoqueHistorico> ObterHistoricoEstoque(int produtoId);
    }
}