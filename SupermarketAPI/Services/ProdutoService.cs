using Microsoft.Extensions.Logging;
using SupermarketAPI.Models;
using SupermarketAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger<ProdutoService> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public IEnumerable<ProdutoResponseDTO> GetAll()
        {
            _logger.LogInformation("Obtendo todos os produtos");
            return _produtoRepository.GetAll()
                .Select(p => new ProdutoResponseDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = Math.Round(p.Preco, 2),
                    Quantidade = p.Quantidade
                }).ToList();
        }

        public ProdutoResponseDTO? GetById(int id)
        {
            _logger.LogInformation($"Obtendo o produto de ID: {id}");
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                _logger.LogWarning($"Produto de ID {id} não encontrado");
                return null;
            }

            return new ProdutoResponseDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = Math.Round(produto.Preco, 2),
                Quantidade = produto.Quantidade
            };
        }

        public void Create(ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                _logger.LogError("Produto nulo não pode ser criado");
                throw new ArgumentNullException(nameof(produtoDTO), "ProdutoDTO não pode ser nulo.");
            }

            _logger.LogInformation("Criando um novo produto");
            var produto = new Produto
            {
                Nome = produtoDTO.Nome,
                Preco = Math.Round(produtoDTO.Preco, 2),
                Quantidade = produtoDTO.Quantidade
            };
            _produtoRepository.Create(produto);
            _logger.LogInformation("Produto criado com sucesso");
        }

        public void Update(int id, ProdutoDTO produtoDTO)
        {
            _logger.LogInformation($"Atualizando o produto de ID: {id}");
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                _logger.LogWarning($"Produto de ID {id} não encontrado");
                throw new ArgumentException($"Produto com ID {id} não encontrado.");
            }

            produto.Nome = produtoDTO.Nome;
            produto.Preco = Math.Round(produtoDTO.Preco, 2);
            produto.Quantidade = produtoDTO.Quantidade;

            _produtoRepository.Update(produto);
            _logger.LogInformation($"Produto de ID {id} atualizado com sucesso");
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"Deletando o produto de ID: {id}");
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                _logger.LogWarning($"Produto de ID {id} não encontrado para deletar");
                return;
            }

            _produtoRepository.Delete(id);
            _logger.LogInformation($"Produto de ID {id} deletado com sucesso");
        }
    }
}
