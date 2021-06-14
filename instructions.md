# Minha Aplicação - Ramsés França

# Descrição da solução
Foram desenvolvidas 1 solutions (.sln) e dois projetos (MinhaAplicacao_API - projeto da API) para demonstrar o devido isolamento entre a API.

# Projeto MinhaAplicacao_API (API)
Foi desenvolvida utilizando ASP.NET Core Web API 5 e EF Core com Code-first + Migrations. Para persitência dos dados foi utilizado SQL Server 2017.

Dentre as biliotecas utilizadas estão:

- AutoMapper
- FluentValidation
- Swagger

# Instruções de execução

Todas as dependências dos projetos foram utilizadas com base em pacotes NuGet, sendo necessário apenas o build assim que as solutions sejam abertas.

Foi criando um script para criação do banco (backend-challenge\sql\Scripts\Script_Criacao_Banco.sql)

Como foi utilizado Code-first com Migrations, para geração da base de dados basta executar o comando Update-Database na CLI do Visual Studio, apontando para o projeto que contém o MinhaAplicacaoDbContext (MinhaAplicacao.Infraestrutura). O programa se encarregará de ler as Migrations e criar as tabelas na base de dados. A connection string aponta para a base MinhaAplicacao numa instância local do SQL Server.

# Documentação da API

Toda a documentação encontra-se na URL: (OBS: API tem que estar em execução)

https://localhost:44398/index.html

# Pontos de melhoria

Pretendia-se abordar ainda alguns pontos na implementação, mas por questões de tempo optei por focar no funcionamento principal da solução.
Seguem alguns itens de melhoria:

- O acesso à aplicação só poderá ser realizado por um usuário pré-existente via autenticação **basic**.
- Implementar teste de integração da API em .NET e garantir pelo menos 80% de cobertura de código.
- Implementar utilizando MongoDB ou outro banco de dados NoSQL.
- A aplicação rodando em algum ambiente em nuvem
