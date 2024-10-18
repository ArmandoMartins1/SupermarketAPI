using SupermarketAPI.Models;
using System.Collections.Generic;

namespace SupermarketAPI.Services
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoResponseDTO> GetAll();
        ProdutoResponseDTO GetById(int id);
        void Create(ProdutoDTO produtoDTO);
        void Update(int id, ProdutoDTO produtoDTO);
        void Delete(int id);
    }
}
