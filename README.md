# Supermarket API
1. Fork este repositório.
2. Crie uma branch para suas alterações: `git checkout -b minha-branch`.
3. Faça commit de suas alterações: `git commit -m 'Adiciona nova funcionalidade'`.
4. Faça push da sua branch: `git push origin minha-branch`.
5. Abra um Pull Request.

## Licença

Este projeto é licenciado sob os termos da licença MIT.

---

### Informações adicionais

Caso queira adicionar dados de exemplo no banco de dados, forneça um script SQL ou implemente um método `Seed` no Entity Framework para adicionar dados de teste automaticamente ao rodar a aplicação.

### Observação
Se preferir, você também pode configurar variáveis de ambiente para a string de conexão ao banco de dados, o que torna a configuração ainda mais flexível para diferentes ambientes de desenvolvimento. 

### Dados de Exemplo 

INSERT INTO produtos (nome, preco, quantidade) VALUES
('Arroz', 18.50, 30),
('Feijão', 7.90, 50),
('Macarrão', 4.25, 40),
('Açúcar', 5.70, 35),
('Café', 14.80, 20),
('Leite', 6.50, 25),
('Óleo de soja', 9.90, 18),
('Sal', 3.30, 60),
('Farinha de trigo', 4.80, 32),
('Molho de tomate', 3.20, 27),
('Biscoito', 2.90, 45),
('Detergente', 2.10, 80),
('Sabonete', 1.50, 100),
('Papel higiênico', 4.00, 55),
('Amaciante', 8.40, 15),
('Shampoo', 12.30, 22),
('Sabão em pó', 14.50, 28),
('Desodorante', 9.70, 30),
('Escova de dentes', 3.50, 40),
('Creme dental', 6.20, 35);

## Testes de Unidade e Integração

Este projeto inclui testes de unidade para a camada de serviços e testes de integração para os endpoints da API. Abaixo estão os principais tipos de testes implementados e o que cada um verifica.

### Estrutura dos Testes

- **Testes de Integração**: Localizados em `SupermarketAPI.Tests.Integration`, esses testes garantem o funcionamento correto dos endpoints da API, como:
  - `GetAll_ShouldReturnAllProducts`: verifica se o endpoint de listagem de produtos retorna todos os produtos.
  - `GetById_ShouldReturnProduct`: verifica se o endpoint de consulta por ID retorna o produto correto.
  - `Create_ShouldAddProduct`: verifica se um novo produto é criado corretamente.
  - `Update_ShouldModifyProduct`: verifica se um produto existente é atualizado corretamente.
  - `Delete_ShouldRemoveProduct`: verifica se um produto é excluído com sucesso.

- **Testes de Unidade**: Localizados em `SupermarketAPI.Tests`, esses testes validam o comportamento dos métodos dos serviços, como:
  - `GetAll_ShouldReturnAllProducts`: testa se o método de serviço retorna todos os produtos corretamente.
  - `GetById_ShouldReturnProduct_WhenProductExists`: testa se um produto é retornado quando ele existe.
  - `Create_ShouldAddNewProduct`: testa se um produto é criado corretamente.
  - `Update_ShouldModifyExistingProduct`: testa se um produto existente é atualizado.
  - `Delete_ShouldRemoveProduct`: testa se um produto é removido corretamente.

### Executando os Testes
