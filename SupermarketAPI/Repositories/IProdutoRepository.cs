using SupermarketAPI.Models;
using System.Collections.Generic;

namespace SupermarketAPI.Repositories
{
     public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto? GetById(int id);
        void Create(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}
