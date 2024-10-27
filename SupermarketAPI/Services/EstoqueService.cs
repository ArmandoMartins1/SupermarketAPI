using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Data;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly SupermarketContext _context;

        public EstoqueService(SupermarketContext context)
        {
            _context = context;
        }

        public void RegistrarEntrada(int produtoId, int quantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null) throw new Exception("Produto não encontrado");

            produto.Quantidade += quantidade;
            _context.EstoqueHistorico.Add(new EstoqueHistorico
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                TipoOperacao = "Entrada",
                DataOperacao = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void RegistrarSaida(int produtoId, int quantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null || produto.Quantidade < quantidade)
                throw new Exception("Produto insuficiente ou não encontrado");

            produto.Quantidade -= quantidade;
            _context.EstoqueHistorico.Add(new EstoqueHistorico
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                TipoOperacao = "Saída",
                DataOperacao = DateTime.Now
            });
            _context.SaveChanges();
        }

        public IEnumerable<EstoqueHistorico> ObterHistoricoEstoque(int produtoId)
        {
            return _context.EstoqueHistorico.Where(e => e.ProdutoId == produtoId).ToList();
        }
    }

    public class VendaService : IVendaService
    {
        private readonly SupermarketContext _context;

        public VendaService(SupermarketContext context)
        {
            _context = context;
        }

        public void RegistrarVenda(int produtoId, int quantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null || produto.Quantidade < quantidade)
                throw new Exception("Produto insuficiente ou não encontrado");

            produto.Quantidade -= quantidade;

            var valorTotal = quantidade * produto.Preco;
            _context.Vendas.Add(new Venda
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                ValorTotal = valorTotal,
                DataVenda = DateTime.Now
            });
            _context.SaveChanges();
        }

        public decimal ObterValorTotalVendas(DateTime inicio, DateTime fim)
        {
            return _context.Vendas
                .Where(v => v.DataVenda >= inicio && v.DataVenda <= fim)
                .Sum(v => v.ValorTotal);
        }
    }
}