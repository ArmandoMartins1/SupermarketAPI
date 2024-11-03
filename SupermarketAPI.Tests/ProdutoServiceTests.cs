using Moq;
using Xunit;
using SupermarketAPI.Models;
using SupermarketAPI.Repositories;
using SupermarketAPI.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using SupermarketAPI;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SupermarketAPI.Tests
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<ProdutoService>> _loggerMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<ProdutoService>>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnAllProducts()
        {
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Preco = 10.00m, Quantidade = 5 },
                new Produto { Id = 2, Nome = "Produto 2", Preco = 20.00m, Quantidade = 10 }
            };
            _produtoRepositoryMock.Setup(repo => repo.GetAll()).Returns(produtos);

            var result = _produtoService.GetAll().ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Produto 1", result[0].Nome);
            Assert.Equal("Produto 2", result[1].Nome);
        }

        [Fact]
        public void GetById_ShouldReturnProduct_WhenProductExists()
        {
            var produto = new Produto { Id = 1, Nome = "Produto 1", Preco = 10.00m, Quantidade = 5 };
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(produto);

            var result = _produtoService.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Produto 1", result.Nome);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenProductDoesNotExist()
        {
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Produto?)null);

            var result = _produtoService.GetById(1);

            Assert.Null(result);
        }

        [Fact]
        public void Create_ShouldAddNewProduct()
        {
            var produtoDto = new ProdutoDTO { Nome = "Novo Produto", Preco = 15.00m, Quantidade = 20 };

            _produtoService.Create(produtoDto);

            _produtoRepositoryMock.Verify(repo => repo.Create(It.IsAny<Produto>()), Times.Once);
            _loggerMock.Verify(log => log.Log(
                It.Is<LogLevel>(l => l == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Produto criado com sucesso")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
        }

        [Fact]
        public void Create_ShouldThrowArgumentNullException_WhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _produtoService.Create(null));
            _loggerMock.Verify(log => log.Log(
                It.Is<LogLevel>(l => l == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Produto nulo não pode ser criado")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
        }

        [Fact]
        public void Update_ShouldModifyExistingProduct_WhenProductExists()
        {
            var produtoExistente = new Produto { Id = 1, Nome = "Produto Atualizado", Preco = 12.00m, Quantidade = 8 };
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(produtoExistente);
            var produtoDto = new ProdutoDTO { Nome = "Produto Atualizado", Preco = 18.00m, Quantidade = 15 };

            _produtoService.Update(1, produtoDto);

            _produtoRepositoryMock.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
        }
        [Fact]
        public void Update_ShouldThrowArgumentException_WhenProductDoesNotExist()
        {
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Produto?)null);
            var produtoDto = new ProdutoDTO { Nome = "Produto Inexistente", Preco = 20.00m, Quantidade = 10 };

            Assert.Throws<ArgumentException>(() => _produtoService.Update(1, produtoDto));
        }

        [Fact]
        public void Delete_ShouldRemoveProduct_WhenProductExists()
        {
            var produto = new Produto { Id = 1, Nome = "Produto para Deletar", Preco = 10.00m, Quantidade = 5 };
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(produto);

            _produtoService.Delete(1);

            _produtoRepositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
            _loggerMock.Verify(log => log.Log(
                It.Is<LogLevel>(l => l == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("deletado com sucesso")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
        }
        [Fact]
        public void Delete_ShouldNotLog_WhenProductDoesNotExist()
        {
            _produtoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Produto?)null);

            _produtoService.Delete(1);

            _produtoRepositoryMock.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Never);
            _loggerMock.Verify(log => log.Log(
                It.Is<LogLevel>(l => l == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("deletado com sucesso")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never);
        }
    }
}
