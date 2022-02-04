
# Arquitetura
O sistema foi construído em 4 camadas seguindo a abordagem Domain-Driven Design.

 - **API** - Camada responsável por fazer a interface com o mundo externo (protocolo http/https)
 - **Business** - Camada responsável pelas lógicas de negócio, bem como fazer log, capturar exceções e estruturar a resposta para a(s) camada(s) acima, neste caso apenas a "Application".
 - **Domain** - Entidades e modelos auxiliares.
 - **Data Access** - Repositórios, ORMs, e acesso a dados persistidos/externos em modo geral.

Além destes projetos existe mais 1 projeto de teste (xUnit + MOQ) que está coberto com um teste apenas, mas
pode ser replicado para os outros tipos de request/response informado na descrição do challenge.

# Postman

- É possível utilizar também o Postman para testar a aplicação. Basta importar o arquivo postmancollection.json para o aplicativo e vai ter todas
collections com dados para testes

# Rodar aplicação com Docker

1. Na pasta raiz do repositório, executar o seguinte comando:

```bash

docker-compose up -d

```

2. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:

```bash

The server is healthy

```

3. Acessar o endpoint do SwaggerUI **"GET http /swagger/index.html"**.

  

# Rodar aplicação com .NET 5

1. Buildar o projeto.

```bash

dotnet build -c Release -o output

```

  

2. Executar o projeto. O projeto será iniciado nas portas **5000 (http)** e **5001 (https)**.

```bash

dotnet .\output\MercadoEletronico.Aplication.dll

```

3. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:

```bash

The server is healthy

```

4. Acessar no navegador o endpoint do SwaggerUI **"GET http /swagger/index.html"**.

# Observações
##### Algumas sugestões e anotações sobre o que é possível fazer com a aplicação

- Implementação de logs, utilizando por exemplo o NewRelic, Elmah.io, dentre outras ferramentas
- Implementação de um middleware para autenticação com JWT, SSO, OAuh
- Implementação de um response padrão para todas as requests
- A forma como foi feito, foi para atender o teste especifico, assim como a estrutura utilizada
- Não existe uma melhor forma de fazer (claro que possui alguns conceitos básicos como Clean Code), mas a melhor forma é que a melhor atende quem for
utilizar
- O padrão é alterado conforme padrões específicos de cada empresa, como nome de variáveis, nomes de métodos, nomes das camadas...
- Na camada de Businesss foi implementado um Notificador, onde é o retorno de algum erro ou infomração para a camada Aplication, mas é possível também
utilizar Exceptions e tratar as mesmas de uma forma geral.