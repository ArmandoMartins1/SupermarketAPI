using SupermarketAPI.Models;
using SupermarketAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoResponseDTO> GetAll()
        {
            return _produtoRepository.GetAll()
                .Select(p => new ProdutoResponseDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Quantidade = p.Quantidade
                }).ToList();
        }

        public ProdutoResponseDTO? GetById(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null) return null;

            return new ProdutoResponseDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            };
        }

        public void Create(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Nome = produtoDTO.Nome,
                Preco = produtoDTO.Preco,
                Quantidade = produtoDTO.Quantidade
            };
            _produtoRepository.Create(produto);
        }

        public void Update(int id, ProdutoDTO produtoDTO)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null) return;

            produto.Nome = produtoDTO.Nome;
            produto.Preco = produtoDTO.Preco;
            produto.Quantidade = produtoDTO.Quantidade;

            _produtoRepository.Update(produto);
        }

        public void Delete(int id)
        {
            _produtoRepository.Delete(id);
        }
    }
}
