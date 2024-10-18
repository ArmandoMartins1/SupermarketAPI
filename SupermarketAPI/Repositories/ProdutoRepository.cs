using SupermarketAPI.Models;
using SupermarketAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SupermarketContext _context;

        public ProdutoRepository(SupermarketContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto? GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
