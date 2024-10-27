
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
   
2. **Crie o banco de dados:**

   Conecte-se ao MySQL e execute o seguinte comando SQL para criar o banco de dados necessário:

   ```sql
   CREATE DATABASE supermarket;
   ```

3. **Criar as tabelas:**

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

### 4. Restaurar dependências

No diretório raiz do projeto, execute o seguinte comando para restaurar as dependências do projeto:

```bash
dotnet restore
```

### 5. Aplicar migrações do banco de dados

O projeto utiliza o Entity Framework Core, então as migrações já estão configuradas para criar as tabelas automaticamente. Para aplicar as migrações e criar as tabelas no banco de dados, execute:

```bash
dotnet ef database update
```

### 6. Rodar o projeto

Agora você pode iniciar a aplicação com o seguinte comando:

```bash
dotnet run
```

Se o projeto compilar e rodar corretamente, a API estará disponível no endereço:

- **Swagger UI**: `http://localhost:5089/swagger` (usado para testar a API)
- **Ambiente de desenvolvimento**: `https://localhost:7204` (ou `http://localhost:5089` para HTTP)


## Resumo de sequências
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

