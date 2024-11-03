using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SupermarketAPI;
using SupermarketAPI.Models;
using Xunit;

namespace SupermarketAPI.Tests.Integration
{
    public class ProdutosControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProdutosControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProducts()
        {
            var response = await _client.GetAsync("/api/produtos");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnProduct()
        {
            var newProduto = new ProdutoDTO { Nome = "Produto Teste", Preco = 20.0m, Quantidade = 50 };
            var createResponse = await _client.PostAsJsonAsync("/api/produtos", newProduto);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createdProduto = await createResponse.Content.ReadFromJsonAsync<ProdutoResponseDTO>();
            Assert.NotNull(createdProduto);

            var response = await _client.GetAsync($"/api/produtos/{createdProduto.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


       [Fact]
        public async Task Create_ShouldAddProduct()
        {
            var newProduto = new ProdutoDTO { Nome = "Produto Teste", Preco = 20.0m, Quantidade = 50 };

            var response = await _client.PostAsJsonAsync("/api/produtos", newProduto);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var produtoCriado = await response.Content.ReadFromJsonAsync<ProdutoResponseDTO>();
            Assert.NotNull(produtoCriado);
            Assert.NotNull(produtoCriado.Id);
        }


        [Fact]
        public async Task Update_ShouldModifyProduct()
        {
            var newProduto = new ProdutoDTO { Nome = "Produto Teste", Preco = 20.0m, Quantidade = 50 };
            var createResponse = await _client.PostAsJsonAsync("/api/produtos", newProduto);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createdProduto = await createResponse.Content.ReadFromJsonAsync<ProdutoResponseDTO>();
            Assert.NotNull(createdProduto);

            var updatedProduto = new ProdutoDTO { Nome = "Produto Teste Atualizado", Preco = 25.0m, Quantidade = 60 };

            var updateResponse = await _client.PutAsJsonAsync($"/api/produtos/{createdProduto.Id}", updatedProduto);

            Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
        }



        [Fact]
        public async Task Delete_ShouldRemoveProduct()
        {
            var newProduto = new ProdutoDTO { Nome = "Produto Teste", Preco = 20.0m, Quantidade = 50 };
            var createResponse = await _client.PostAsJsonAsync("/api/produtos", newProduto);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createdProduto = await createResponse.Content.ReadFromJsonAsync<ProdutoResponseDTO>();
            Assert.NotNull(createdProduto);
            Assert.True(createdProduto.Id > 0, "O ID do produto criado deve ser válido.");

            var getResponse = await _client.GetAsync($"/api/produtos/{createdProduto.Id}");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var deleteResponse = await _client.DeleteAsync($"/api/produtos/{createdProduto.Id}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            var checkDeletionResponse = await _client.GetAsync($"/api/produtos/{createdProduto.Id}");
            Assert.Equal(HttpStatusCode.NotFound, checkDeletionResponse.StatusCode);
        }

    }
}
