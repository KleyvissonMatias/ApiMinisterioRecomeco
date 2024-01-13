# API Ministerio Recomeço versão escrita em C# (Versão 7.0) com .NET Core, Entity Framework, SQL Server e Migrations

Esta é uma API escrita em C# utilizando .NET Core 7.0, Entity Framework e SQL Server para fornecer endpoints CRUD para quatro entidades principais: Celula, Relatorio, Vida e Voluntario. Este README fornece instruções sobre como configurar o ambiente, migrar o banco de dados e utilizar os endpoints disponíveis.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [.NET Core SDK 7.0](https://dotnet.microsoft.com/download)
- [MySQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

## Configuração do Banco de Dados

1. **Crie um banco de dados MySQL:**
   - Abra o MySQL Server e crie um banco de dados vazio. Anote as credenciais de acesso.

2. **Configure as strings de conexão:**
   - No arquivo `appsettings.json`, substitua as configurações da conexão do banco de dados pelos detalhes do seu banco MySQL.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Initial Catalog=SeuBancoDeDados; Data Source=localhost; Persist Security Info=True; User Id=SeuUsuario; Password=SuaSenha; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=True"
  },
  // outras configurações...
}
```

## Executando as Migrations

1. **Abra um terminal na pasta do projeto:**
   - Execute os seguintes comandos para criar e aplicar as migrações.

```bash
dotnet ef migrations add Inicial
dotnet ef database update
```

Isso irá criar as tabelas necessárias no seu banco de dados.

## Executando a Aplicação

1. **Execute o projeto:**
   - Utilize o seguinte comando para iniciar a aplicação.

```bash
dotnet run
```

A API estará acessível em `https://localhost:5001` por padrão.

## Endpoints CRUD

### Celula

- **GET /api/v1/celula:** Retorna todas as células.
- **GET /api/v1/celula/{id}:** Retorna uma célula específica pelo ID.
- **POST /api/v1/celula:** Adiciona uma nova célula.
- **PUT /api/v1/celula/{id}:** Atualiza os dados de uma célula existente.
- **DELETE /api/v1/celula/{id}:** Remove uma célula pelo ID.

### Relatorio

- **GET /api/v1/relatorio:** Retorna todos os relatórios.
- **GET /api/v1/relatorio/{id}:** Retorna um relatório específico pelo ID.
- **POST /api/v1/relatorio:** Adiciona um novo relatório.
- **PUT /api/v1/relatorio/{id}:** Atualiza os dados de um relatório existente.
- **DELETE /api/v1/relatorio/{id}:** Remove um relatório pelo ID.

### Vida

- **GET /api/v1/vida:** Retorna todas as informações sobre a vida.
- **GET /api/v1/vida/{id}:** Retorna informações específicas sobre a vida pelo ID.
- **POST /api/v1/vida:** Adiciona novas informações sobre a vida.
- **PUT /api/v1/vida/{id}:** Atualiza os dados existentes sobre a vida.
- **DELETE /api/v1/vida/{id}:** Remove informações sobre a vida pelo ID.

### Voluntario

- **GET /api/v1/voluntario:** Retorna todos os voluntários.
- **GET /api/v1/voluntario/{id}:** Retorna um voluntário específico pelo ID.
- **POST /api/v1/voluntario:** Adiciona um novo voluntário.
- **PUT /api/v1/voluntario/{id}:** Atualiza os dados de um voluntário existente.
- **DELETE /api/v1/voluntario/{id}:** Remove um voluntário pelo ID.
