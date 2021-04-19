
# Rodar aplicação com Docker

1. Na pasta raíz do repositório, editar arquivo **.env** e configurar em qual **porta** você quer expôr a aplicação. É importante escolher uma porta que já não esteja alocada em sua máquina.

3. Na pasta raiz do repositório, executar o seguinte comando:

```bash

docker-compose up -d

```

4. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:

```bash

The server is healthy, up and running 🚀

```

5. Acessar o endpoint do SwaggerUI **"GET http /swagger/index.html"**.

  

# Rodar aplicação com .NET 5

1. Buildar o projeto.

```bash

dotnet build -c Release -o output

```

  

2. Executar o projeto. O projeto será iniciado nas portas **5000 (http)** e **5001 (https)**.

```bash

dotnet .\output\MercadoEletronico.Challenge.dll

```

3. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:

```bash

The server is healthy, up and running 🚀

```

4. Acessar no navegador o endpoint do SwaggerUI **"GET http /swagger/index.html"**.

# Arquitetura
O sistema foi construído em 4 camadas seguindo a abordagem Domain-Driven Design.

 1. **API** - Camada responsável por fazer a interface com o mundo externo (protocolo http/https)
 2. **Aplicação** - Camada responsável coordenar chamadas às lógicas de negócio, bem como fazer log, capturar exceções e estruturar a resposta para a(s) camada(s) acima, neste caso apenas a "API".
 3. **Domain** - Lógicas de negócio, entidades e modelos auxiliares.
 4. **Data Access** - Repositórios, ORMs, e acesso a dados persistidos/externos em modo geral.
 5. **Cross-Cutting** - Camada "transversal", responsável por utilitários gerais (não relacionados ao negócio em si).

Além destes projetos existem mais 2 projetos de testes, sendo um de testes unitários (xUnit + MOQ) e outro para testes de integração ([Microsoft. AspNetCore. Mvc. Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing)).