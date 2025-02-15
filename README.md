
# Supermarket API

Este projeto é uma API REST para gerenciamento de produtos de supermercado. Foi desenvolvida utilizando ASP.NET Core 8.0 e MySQL para banco de dados.

## Requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL 8.0 ou superior](https://dev.mysql.com/downloads/installer/)
- [Git](https://git-scm.com/)

## Configuração do Ambiente

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/supermarket-api.git
cd supermarket-api
```

### 2. Configuração do MySQL

1. **Certifique-se de que o MySQL está instalado e rodando em sua máquina.**
   

2. **Criar as tabelas:**

   O Entity Framework Core (EF Core) será utilizado para criar as tabelas automaticamente. Não é necessário criar as tabelas manualmente.

### 3. Configuração do `appsettings.json`

O projeto contém um arquivo de configuração chamado `appsettings.json` e `appsettings.Development.json`. A string de conexão com o banco de dados MySQL deve ser configurada conforme o ambiente.

- Abra o arquivo `appsettings.Development.json` e ajuste as credenciais do MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=supermarket;User=root;Password=sua_senha_local;"
  }
}
```

- Substitua `sua_senha_local` pela senha do usuário root ou outro usuário que você configurou no MySQL.

### 4. Configurações da migração para o Banco de Dados.
CERTIFIQUE-SE DE ESTAR DENTRO DA PASTA CORRETA. (/SupermarketAPI).

Você apaga todos os itens dentro da pasta Migrations e usa:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet build
dotnet run
```
o migrations vai criar os itens.
o database update vai aplicar as configuração do banco.
o build vai dá um check no seu código
e por final o run irá rodar, em seguida abra o Swagger.


### 5. Rodar o projeto

Agora você pode iniciar a aplicação com o seguinte comando:

```bash
dotnet run
```

Se o projeto compilar e rodar corretamente, a API estará disponível no endereço:

- **Swagger UI**: `http://localhost:5089/swagger` (usado para testar a API)
- **Ambiente de desenvolvimento**: `https://localhost:7204` (ou `http://localhost:5089` para HTTP)



## Endpoints da API

Abaixo estão os principais endpoints da API que você pode testar diretamente no Swagger UI.

- **GET /api/produtos** - Retorna todos os produtos.
- **GET /api/produtos/{id}** - Retorna um produto específico pelo ID.
- **POST /api/produtos** - Cria um novo produto.
- **PUT /api/produtos/{id}** - Atualiza um produto existente.
- **DELETE /api/produtos/{id}** - Deleta um produto específico.
- **POST /api/produtos/{id}/entrada** - A entrada serve para modificar a quantidade dos itens existentes com ID’s próprios.
- **POST /api/produtos/{id}/saida** - A SAÍDA serve para modificar o ITEM EXISTENTE com ID’s próprios sem ser pela venda.
- **POST /api/produtos/{id}/vender** - A venda serve para modificar a quantidade dos itens existentes com ID’s próprios.

## Testando a API

Você pode utilizar a interface Swagger para testar os endpoints. Basta abrir o navegador e acessar o seguinte endereço:

```
http://localhost:5089/swagger
```

A partir daí, você pode enviar requisições HTTP para a API e verificar os resultados.

## Problemas comuns

### Erro de conexão com o banco de dados
Se você receber um erro de conexão com o banco de dados, verifique os seguintes pontos:

- O MySQL está rodando na sua máquina?
- O banco de dados `supermarket` foi criado corretamente?
- As credenciais no arquivo `appsettings.Development.json` estão corretas?

### Dependências não restauradas
Se o projeto não compilar, execute o comando:

```bash
dotnet restore
```

## Contribuindo

Se você deseja contribuir para este projeto, siga os passos abaixo:

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

```bash
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
```

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

Para rodar todos os testes de unidade e de integração, execute o seguinte comando no terminal:
Verifique que você esta na pasta do supermarketapi.tests, logo após: 
```bash
dotnet test
```

### Desenvolvedores:
<table style="width:100%">
  <tr align=center>
    <th><strong>Davi Guabiraba</strong></th>
    <th><strong>Armando Alves</strong></th>


  </tr>
  <tr align=center>
    <td>
      <a href="https://github.com/DGuabiraba">
        <img src="https://avatars.githubusercontent.com/u/81264511?v=4">
      </a>
    </td>
    <td>
            <a href="https://github.com/ArmandoMartins1">
        <img src="https://avatars.githubusercontent.com/u/133614695?v=4">
      </a>
    </td>
    <td>

</table>

